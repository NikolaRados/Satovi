using Microsoft.EntityFrameworkCore;
using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Searches;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoviEfCommands
{
    public class EfGetProductCommand : IGetProductCommand
    {

        private readonly SatoviContext _context;

        public EfGetProductCommand(SatoviContext context)
        {
            _context = context;
        }

        public IEnumerable<GetProductDTO> Execute(ProductSearches request)
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


            return product.Select(x => new GetProductDTO
            {
                Id = x.Id,
                ProductName = x.ProductName,
                Description = x.Description,
                Price = x.Price,
                Src = x.Image.Src,
                BrandName = x.Brand.BrandName
            });
        }

    }
}
