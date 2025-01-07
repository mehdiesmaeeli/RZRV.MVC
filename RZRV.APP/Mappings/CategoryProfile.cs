
using AutoMapper;
using RZRV.APP.Models;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}