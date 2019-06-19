using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviApplication.Searches;
using SatoviDataAccess;
using SatoviEfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatoviWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly SatoviContext _context;
        private readonly ICreateBrandCommand _createBrand;
        private readonly IGetBrandCommand _getBrand;
        private readonly IEditBrandCommand _editBrand;
        private readonly IGetOneBrandCommand _getOneBrand;

        public CategoryController(SatoviContext context, ICreateBrandCommand createBrand, IGetBrandCommand getBrand, IEditBrandCommand editBrand)
        {
            _context = context;
            _createBrand = createBrand;
            _getBrand = getBrand;
            _editBrand = editBrand;
        }

        // GET: /<controller>/
        public IActionResult Index(BrandSearches searches)
        {
            var result = _getBrand.Execute(searches);
            return View(result);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var dto = _getOneBrand.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {
                return View();
            }
        }


        // GET: Category/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBrandDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["greska"] = "Doslo je do greske pri unosu";
                RedirectToAction("create");
            }
            try
            {
                _createBrand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException ex)
            {
                TempData["greska"] = ex.Message;

            }
            catch (Exception)
            {
                TempData["greska"] = "Doslo je do greske.";
            }
            return View();
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                var dto = _getOneBrand.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateBrandDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                _editBrand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Proizvod sa istim imenom vec postoji.";
                return View(dto);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
