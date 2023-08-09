using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 4)
        {
            var paginatedCategories = await _categoryService.GetCategoriesPaginated(pageNumber, pageSize);
            return View(paginatedCategories);
        }

        [HttpGet()]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid) 
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto == null)
            {
                return NotFound();
            }

            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDto);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto == null)
            {
                return NotFound();
            }

            return View(categoryDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto == null)
            {
                return NotFound();
            }

            return View(categoryDto);
        }
    }
}
