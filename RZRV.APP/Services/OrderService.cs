using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RZRV.APP.Data;
using RZRV.APP.Models;
using RZRV.APP.Services.Interfaces;
using RZRV.APP.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RZRV.APP.Services
{
    public class OrderService : GenericService<Order, OrderViewModel>, IOrderService
    {
        private readonly ICacheService _cacheService;
        private const string AllOrdersCacheKey = "AllOrders";
        private const string OrderCacheKeyPrefix = "Order_";
        private readonly IMapper _mapper;
        public OrderService(ApplicationDbContext context, IMapper mapper, ICacheService cacheService) : base(context, mapper)
        {
            _cacheService = cacheService;
        }

        public override async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {
            var orders = await _dbSet.Include(o => o.Customer).Include(o => o.OrderItems).ToListAsync();
            return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
        }


        // TODO
    }
}