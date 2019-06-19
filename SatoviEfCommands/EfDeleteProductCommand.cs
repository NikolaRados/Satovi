using SatoviApplication.Commands;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfDeleteProductCommand : IDeleteProductCommand
    {
        private readonly SatoviContext _context;

        public EfDeleteProductCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var product = _context.Products.Find(request);

            if (product == null)
            {
                throw new EntityNotFoundException("Product");
            }

            _context.Products.Remove(product);

            _context.SaveChanges();
        }
    }
}
