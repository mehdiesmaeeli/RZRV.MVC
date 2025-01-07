
using AutoMapper;
using RZRV.APP.Models;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}