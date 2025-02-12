using FJM.Services.MobileDevice.Models.DataModels;
using FJM.Services.MobileDevice.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.BusinessLogic.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Fields
        private readonly MobileDeviceDbContext _context;
        private readonly DbSet<T> _dbSet;
        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(MobileDeviceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Retrieves all records from the database asynchronously.
        /// </summary>
        /// <returns>A collection of all records in the database.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Retrieves a record by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the record.</param>
        /// <returns>The record with the specified ID, or null if not found.</returns>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Retrieves a client entity based on the provided access ID asynchronously.
        /// </summary>
        /// <param name="accessId">The access ID associated with the client.</param>
        /// <returns>The client entity if found; otherwise, null.</returns>
        public async Task<Client?> GetClientByAccessIdAsync(int accessId)
        {
            var clientDbSet = _context.Set<Client>();
            return await clientDbSet
                .Where(client => client.accessID == accessId)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retrieves a user entity by nickname and password or by employee code asynchronously.
        /// </summary>
        /// <param name="nickname">The user's nickname.</param>
        /// <param name="hashedPassword">The hashed password of the user.</param>
        /// <param name="employeeCode">The employee code associated with the user.</param>
        /// <returns>The user entity if found; otherwise, null.</returns>
        public async Task<T?> GetUserBynameAndPasswordAsync(string nickname, string hashedPassword, string employeeCode)
        {
            if (typeof(T) == typeof(User)) 
            {
                var userDbSet = _context.Set<User>();

                if (!string.IsNullOrWhiteSpace(nickname) && !string.IsNullOrWhiteSpace(hashedPassword))
                {
                    return await userDbSet
                        .FromSqlRaw("SELECT TOP 1 * FROM Users WHERE nickname = {0} AND mobilePassword = {1}", nickname, hashedPassword)
                        .FirstOrDefaultAsync() as T;
                }
                else if (!string.IsNullOrWhiteSpace(employeeCode))
                {
                    return await userDbSet
                        .FromSqlRaw("SELECT TOP 1 * FROM Users WHERE identCardNumber = {0}", employeeCode)
                        .FirstOrDefaultAsync() as T;
                }
            }

            return null;
        }


        /// <summary>
        /// Check if the NVE is already scanned in GoodsReceived
        /// </summary>
        public async Task<bool> IsNVEAlreadyScanned(string deliveryReceiptId)
        {
            return await _context.Set<GoodsReceived>()
                .AnyAsync(x => x.deliveryReceipt.ToString() == deliveryReceiptId);
        }

        /// <summary>
        /// Get DeliveryReceipts matching NVE Barcode
        /// </summary>
        public async Task<List<DeliveryReceipt>> GetDeliveryReceiptsAsync(string nveBarcode)
        {
            DateTime dt2Compare = DateTime.Now.AddMonths(-8);
            return await _context.Set<DeliveryReceipt>()
                .Where(i => i.receiptDetailNumber == nveBarcode && i.creationDate > dt2Compare)
                .ToListAsync();
        }

        /// <summary>
        /// Get Last 4 Scanned Boxes
        /// </summary>
        public async Task<List<GoodsReceived>> GetLastScannedBoxesAsync(string deliveryReceiptNumber)
        {
            throw new NotImplementedException();
            //return await _context.Set<GoodsReceived>()
            //    .Include(x => x.deliveryReceipt)
            //    .Where(x => x.deliveryReceipt.Value == deliveryReceiptNumber)
            //    .OrderByDescending(x => x.scanDate)
            //    .Take(4)
            //    .ToListAsync();
        }

        /// <summary>
        /// Process NVE Scan by checking DeliveryReceipts and GoodsReceived
        /// </summary>
        public async Task<object?> ProcessNVEScanAsync(IncomingGoodsNVERequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NVEBarcode))
                throw new ArgumentException("NVE Barcode is required");

            var deliveryReceipts = await GetDeliveryReceiptsAsync(request.NVEBarcode);

            // Perform validation checks
            if (!deliveryReceipts.Any())
            {
                return new MessageTransferObject
                {
                    Message = request.Language.ToUpper().Equals("EN") ? "Deliverynote not found." : "Lieferschein nicht gefunden.",
                    Type = MessageType.Error
                };
            }
            
            var firstReceipt = deliveryReceipts.First();

            // Check if NVE is already scanned
            if (await IsNVEAlreadyScanned(firstReceipt.id.ToString()))
            {
                return new
                {
                    Message = "This NVE/Box is already scanned!",
                    IsSuccess = false
                };
            }

            // Construct response object
            var response = new
            {
                Message = "Scan successful",
                IsSuccess = true,
                Data = firstReceipt
            };

            return response;
        }

        #endregion
    }
}
