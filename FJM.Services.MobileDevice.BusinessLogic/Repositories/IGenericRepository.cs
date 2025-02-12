using FJM.Services.MobileDevice.Models.DataModels;
using FJM.Services.MobileDevice.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.BusinessLogic.Repositories
{
    public interface IGenericRepository<T> where T : class
    {       
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetUserBynameAndPasswordAsync(string nickname, string hashedPassword, string employeeCode);
        Task<Client> GetClientByAccessIdAsync(int accessId);
        Task<object?> ProcessNVEScanAsync(IncomingGoodsNVERequest request);
        Task<bool> IsNVEAlreadyScanned(string nveBarcode);
        Task<List<DeliveryReceipt>> GetDeliveryReceiptsAsync(string nveBarcode);
        Task<List<GoodsReceived>> GetLastScannedBoxesAsync(string deliveryReceiptNumber);

        //Task AddAsync(T entity);
        //void Update(T entity);
        //void Remove(T entity);
    }
}
