using Microsoft.AspNetCore.Mvc;

namespace RZRV.APP.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
