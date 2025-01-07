
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RZRV.APP.Data;
using RZRV.APP.Models;
using RZRV.APP.Services.Interfaces;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Services
{
    public class StoreService : GenericService<Store, StoreViewModel>, IStoreService
    {

        public StoreService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}