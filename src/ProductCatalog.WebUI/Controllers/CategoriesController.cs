﻿using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 4, string filter = null)
        {
            if (pageNumber < 1) return NotFound();

            var paginatedCategories = await _categoryService.GetCategoriesPaginated(pageNumber, pageSize, filter);
            return View("Index", paginatedCategories);
        }

        [HttpGet()]
        public IActionResult Create() 
        {
            return View("Create");
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
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Failed to update");
                }
            }

            return View("Edit", categoryDto);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _categoryService.GetById(id);
            
            if (category == null)
            {
                return NotFound();
            }

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
