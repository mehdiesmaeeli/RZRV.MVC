using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RZRV.APP.Areas.Store.Controllers
{
    [Area("Store")]
    [Authorize(Roles = "Store")]
    public class StoreBaseController : Controller
    {
    }
}
