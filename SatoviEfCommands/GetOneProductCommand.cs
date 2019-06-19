using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfGetOneProductCommand : IGetOneProductCommand
    {
        private readonly SatoviContext _context;

        public EfGetOneProductCommand(SatoviContext context)
        {
            _context = context;
        }

        public GetProductDTO Execute(int request)
        {

            var product = _context.Products.Find(request);

            if (product == null)
            {
                throw new EntityNotFoundException("Product");
            }

            return new GetProductDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}
