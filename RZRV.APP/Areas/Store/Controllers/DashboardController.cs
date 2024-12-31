using Microsoft.AspNetCore.Mvc;

namespace RZRV.APP.Areas.Store.Controllers
{
    public class DashboardController : StoreBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
