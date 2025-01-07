
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RZRV.APP.Services.Interfaces;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Areas.Provider.Controllers
{
    public class StoreController : ProviderBaseController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModels = await _storeService.GetAllAsync();
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await _storeService.GetByIdAsync(id);
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
        public async Task<IActionResult> Create(StoreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _storeService.CreateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _storeService.GetByIdAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StoreViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _storeService.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _storeService.GetByIdAsync(id);
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
            await _storeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}