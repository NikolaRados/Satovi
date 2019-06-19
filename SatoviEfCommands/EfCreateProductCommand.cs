using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using SatoviDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoviEfCommands
{
    public class EfCreateProductCommand : ICreateProductCommand
    {
        private readonly SatoviContext _context;

        public EfCreateProductCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(CreateProductDto request)
        {
            if (!_context.Brands.Any(c => c.Id == request.BrandId))
            {
                throw new EntityNotFoundException("Category");

            }

            if (!_context.Images.Any(i => i.Id == request.ImageId))
            {
                throw new EntityNotFoundException("Image");

            }

            _context.Products.Add(new Product
            {
                CreatedAt = DateTime.Now,
                ProductName = request.ProductName,
                Description = request.Description,
                Price = request.Price,
                BrandId = request.BrandId,
                ImageId = request.ImageId
            });

            _context.SaveChanges();
        }
    }
}
