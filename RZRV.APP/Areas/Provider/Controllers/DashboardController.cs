using Microsoft.AspNetCore.Mvc;

namespace RZRV.APP.Areas.Provider.Controllers
{
    public class DashboardController : ProviderBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
