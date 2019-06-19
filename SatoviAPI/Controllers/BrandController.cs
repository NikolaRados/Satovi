using Microsoft.AspNetCore.Mvc;
using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviApplication.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatoviAPI.Controllers
{
        [Route("api/[controller]")]
        public class BrandController : Controller
        {

            private readonly IGetBrandCommand _getBrand;
            private readonly IDeleteBrandCommand _deleteBrand;
            private readonly ICreateBrandCommand _createBrand;
            private readonly IEditBrandCommand _editBrand;

            public BrandController(IGetBrandCommand getBrand, IDeleteBrandCommand deleteBrand, ICreateBrandCommand createBrand, IEditBrandCommand editBrand)
            {
            _getBrand = getBrand;
            _deleteBrand = deleteBrand;
            _createBrand = createBrand;
            _editBrand = editBrand;
            }





            // GET: api/<controller>
            [HttpGet]
            public ActionResult<IEnumerable<GetBrandDTO>> Get([FromQuery] BrandSearches search)
            {
                try
                {
                    var category = _getBrand.Execute(search);
                    return Ok(category);
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }

            // GET api/<controller>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/<controller>
            [HttpPost]
            public IActionResult Post([FromBody] CreateBrandDto dto)
            {
                try
                {
                _createBrand.Execute(dto);
                    return StatusCode(201);
                }
                catch (EntityNotFoundException e)
                {
                    return UnprocessableEntity(e.Message);
                }

                catch (Exception)
                {
                    return StatusCode(500);
                }
            }

            // PUT api/<controller>/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] CreateBrandDto dto)
            {
                dto.Id = id;
                try
                {

                _editBrand.Execute(dto);
                    return NoContent();
                }
                catch (EntityNotFoundException e)
                {
                    if (e.Message == "Category doesn't exist.")
                    {
                        return NotFound(e.Message);
                    }

                    return UnprocessableEntity(e.Message);

                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }

            // DELETE api/<controller>/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                _deleteBrand.Execute(id);
                    return NoContent();
                }
                catch (EntityNotFoundException e)
                {
                    return NotFound(e.Message);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Došlo je do greške, molimo pokušajte kasnije.");
                }
            }
        }
    }