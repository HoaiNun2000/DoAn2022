﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogService.Api.Data;
using MyProjectMVC.Models;
using MyProjectMVC.ViewModels;
using MyProjectMVC.Mapper;

namespace MyProjectMVC.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly DataContext _context;

        public ProductCategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: ProductCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCategorys.ToListAsync());
        }

        public async Task<IActionResult> UpdateStatus(int? id)
        {
            var productCategory = _context.ProductCategorys.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            productCategory.Active = !productCategory.Active;
            _context.Entry(productCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategorys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategoryView productCategoryView)
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Map(productCategoryView);
            if (ModelState.IsValid)
            {
                _context.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategorys.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Edit(int id, ProductCategoryView productCategoryView)
        {
            var productCategory = _context.ProductCategorys.Find(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productCategory.Map(productCategoryView);
                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategorys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory != null)
            {
                _context.ProductCategorys.Remove(productCategory);
                await _context.SaveChangesAsync();
                
            }
            return RedirectToAction(nameof(Index));
        }
        
        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategorys.Any(e => e.Id == id);
        }
    }
}
