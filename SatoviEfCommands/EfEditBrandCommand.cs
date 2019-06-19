using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfEditCategoryCommand : IEditBrandCommand
    {
        private readonly SatoviContext _context;

        public EfEditCategoryCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(CreateBrandDto request)
        {
            var category = _context.Brands.Find(request.Id);

            if (category == null)
            {
                throw new EntityNotFoundException("Category");
            }

            category.ModifiedAt = DateTime.Now;
            category.BrandName = request.BrandName;


            _context.SaveChanges();
        }
    }
}
