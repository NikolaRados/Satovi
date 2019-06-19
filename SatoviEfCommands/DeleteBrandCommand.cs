using SatoviApplication.Commands;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfDeleteCategoryCommand : IDeleteBrandCommand
    {
        private readonly SatoviContext _context;

        public EfDeleteCategoryCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var brand = _context.Brands.Find(request);

            if (brand == null)
            {
                throw new EntityNotFoundException("Brand");
            }

            _context.Brands.Remove(brand);

            _context.SaveChanges();
        }
    }
}
