using Microsoft.EntityFrameworkCore;
using RZRV.APP.Data;
using RZRV.APP.Models;
using RZRV.APP.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RZRV.APP.Services
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly ICacheService _cacheService;
        private const string AllOrdersCacheKey = "AllOrders";
        private const string OrderCacheKeyPrefix = "Order_";
        public OrderService(ApplicationDbContext context, ICacheService cacheService) : base(context)
        {
            _cacheService = cacheService;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet.Include(o => o.Customer).Include(o => o.OrderItems).ToListAsync();
        }

        public override async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        // TODO
    }
}