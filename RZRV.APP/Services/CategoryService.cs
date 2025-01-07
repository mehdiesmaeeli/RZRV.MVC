
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RZRV.APP.Data;
using RZRV.APP.Models;
using RZRV.APP.Services.Interfaces;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Services
{
    public class CategoryService : GenericService<Category, CategoryViewModel>, ICategoryService
    {
        public CategoryService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}