using Microsoft.AspNetCore.Mvc;
using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviApplication.Searches;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatoviWebApplication.Controllers
{
        public class ProductController : Controller
        {
            private readonly SatoviContext _context;
            private readonly ICreateProductCommand _createProduct;
            private readonly IGetProductCommand _getProduct;
            private readonly IGetOneProductCommand _getOne;
            private readonly IEditProductCommand _editProduct;
            private readonly IDeleteProductCommand _deleteProduct;

            public ProductController(SatoviContext context, ICreateProductCommand createProduct, IGetProductCommand getProduct, IGetOneProductCommand getOne, IEditProductCommand editProduct, IDeleteProductCommand deleteProduct)
            {
                _context = context;
                _createProduct = createProduct;
                _getProduct = getProduct;
                _getOne = getOne;
                _editProduct = editProduct;
                _deleteProduct = deleteProduct;
            }
            // GET: /<controller>/
            public ActionResult Index(ProductSearches search)
            {
                var result = _getProduct.Execute(search);
                return View(result);
            }

            // GET: Product/Details/5
            public ActionResult Details(int id)
            {
                try
                {
                    var dto = _getOne.Execute(id);
                    return View(dto);
                }
                catch (Exception)
                {
                    return View();
                }
            }

            // GET: Product/Create
            public ActionResult Create()
            {
                ViewBag.Category = _context.Brands.Select(b => new CreateBrandDto
                {
                    Id = b.Id,
                    BrandName = b.BrandName
                });

                ViewBag.Image = _context.Images.Select(i => new CreateImageDto
                {
                    Id = i.Id,
                    Alt = i.Alt
                });
                return View();
            }

            // POST: Product/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(CreateProductDto dto)
            {
                if (!ModelState.IsValid)
                {
                    TempData["greska"] = "Doslo je do greske pri unosu";
                    RedirectToAction("create");
                }

                try
                {
                    _createProduct.Execute(dto);
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

            // GET: Product/Edit/5
            public ActionResult Edit(int id)
            {
                ViewBag.Category = _context.Brands.Select(b => new CreateBrandDto
                {
                    Id = b.Id,
                    BrandName = b.BrandName
                });

                try
                {
                    var dto = _getOne.Execute(id);
                    return View(dto);
                }
                catch (Exception)
                {

                    return RedirectToAction("index");
                }
            }

            // POST: Product/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, CreateProductDto dto)
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                try
                {
                    _editProduct.Execute(dto);
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
                try
                {
                    var dto = _getOne.Execute(id);
                    return View(dto);
                }
                catch (Exception)
                {

                    return RedirectToAction("index");
                }
            }

            // POST: Product/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, CreateProductDto dto)
            {
                try
                {
                    _deleteProduct.Execute(id);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }

        }
    }
