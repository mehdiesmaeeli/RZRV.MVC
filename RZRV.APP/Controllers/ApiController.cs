using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace RZRV.APP.Controllers
{
    [ValidateAntiForgeryToken]
    public class ApiController : Controller
    {
        private readonly IAntiforgery _antiforgery;

        public ApiController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public IActionResult GenerateToken()
        {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            return Ok(new { token = tokens.RequestToken });
        }
    }

}
