
using AutoMapper;
using RZRV.APP.Models;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Mappings
{
    public class ServiceProviderProfile : Profile
    {
        public ServiceProviderProfile()
        {
            CreateMap<Models.ServiceProvider, ServiceProviderViewModel>().ReverseMap();
        }
    }
}