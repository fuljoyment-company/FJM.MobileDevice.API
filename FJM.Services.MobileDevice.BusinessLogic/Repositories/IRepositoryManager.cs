using FJM.Services.MobileDevice.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.BusinessLogic.Repositories
{
    public interface IRepositoryManager
    {
        IGenericRepository<User> _users { get; }
        IGenericRepository<Client> _clients { get; }
        IGenericRepository<DeliveryReceipt> _deliveryReceipt { get; }
        IGenericRepository<GoodsReceived> _goodsReceived { get; }
    }
}
