using FJM.Services.MobileDevice.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.BusinessLogic.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        #region Fields
        private readonly MobileDeviceDbContext _context;
        public IGenericRepository<User> _users { get; }
        public IGenericRepository<Client> _clients { get; }
        public IGenericRepository<GoodsReceived> _goodsReceived { get; }
        public IGenericRepository<DeliveryReceipt> _deliveryReceipt { get; }
        #endregion

        #region Constructor
        public RepositoryManager(MobileDeviceDbContext context)
        {
            _context = context;
            _users = new GenericRepository<User>(_context);
            _clients = new GenericRepository<Client>(_context);
            _goodsReceived = new GenericRepository<GoodsReceived>(_context);
            _deliveryReceipt = new GenericRepository<DeliveryReceipt>(_context);
        }
        #endregion

        #region Methods
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
