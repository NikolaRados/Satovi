using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoviEfCommands
{
    public class EfEditProductCommand : IEditProductCommand
    {
        private readonly SatoviContext _context;

        public EfEditProductCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(CreateProductDto request)
        {
            var product = _context.Products.Find(request.Id);

            if (product == null)
            {
                throw new EntityNotFoundException("Product");
            }

            if (!_context.Brands.Any(c => c.Id == request.BrandId))
            {
                throw new EntityNotFoundException("Brand");
            }


            if (!_context.Images.Any(i => i.Id == request.ImageId))
            {
                throw new EntityNotFoundException("Image");
            }

            product.ModifiedAt = DateTime.Now;
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.Description = request.Description;
            product.ImageId = request.ImageId;
            product.BrandId = request.BrandId;

            _context.SaveChanges();
        }
    }
}
