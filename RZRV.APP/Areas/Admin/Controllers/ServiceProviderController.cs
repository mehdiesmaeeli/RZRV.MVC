
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RZRV.APP.Services.Interfaces;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Areas.Admin.Controllers
{
    public class ServiceProviderController : AdminBaseController
    {
        private readonly IServiceProviderService _serviceproviderService;

        public ServiceProviderController(IServiceProviderService serviceproviderService)
        {
            _serviceproviderService = serviceproviderService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModels = await _serviceproviderService.GetAllAsync();
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await _serviceproviderService.GetByIdAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceProviderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _serviceproviderService.CreateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _serviceproviderService.GetByIdAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceProviderViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceproviderService.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _serviceproviderService.GetByIdAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceproviderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}