
using AutoMapper;
using RZRV.APP.Models;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}