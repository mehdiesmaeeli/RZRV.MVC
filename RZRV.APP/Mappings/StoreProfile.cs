
using AutoMapper;
using RZRV.APP.Models;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Mappings
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreViewModel>().ReverseMap();
        }
    }
}