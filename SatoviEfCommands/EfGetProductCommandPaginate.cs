using Microsoft.EntityFrameworkCore;
using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Response;
using SatoviApplication.Searches;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoviEfCommands
{
    public class EfGetProductCommandPaginate : IGetProductCommandPaginate
    {
        private readonly SatoviContext _context;

        public EfGetProductCommandPaginate(SatoviContext context)
        {
            _context = context;
        }

        public PagedResponse<GetProductDTO> Execute(ProductSearches request)
        {
            var product = _context.Products.Include(b => b.Brand).AsQueryable();

            if (request.MinPrice.HasValue)
            {
                product = product.Where(p => p.Price >= request.MinPrice);
            }

            if (request.MaxPrice.HasValue)
            {
                product = product.Where(p => p.Price <= request.MaxPrice);
            }

            if (request.ProductName != null)
            {
                product = product.Where(p => p.ProductName.ToLower() == request.ProductName.Trim().ToLower());
            }

            if (request.BrandName != null)
            {
                product = product.Where(p => p.Brand.BrandName.ToLower() == request.BrandName.Trim().ToLower());
            }

            var totalCount = product.Count();

            product = product.Skip((request.PageNumber - 1) * request.PerPage)
                             .Take(request.PerPage);


            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var respones = new PagedResponse<GetProductDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = product.Select(x => new GetProductDTO
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    Price = x.Price,
                    Src = x.Image.Src,
                    BrandName = x.Brand.BrandName
                })
            };
            return respones;
        }
    }
}
