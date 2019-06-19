using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfGetOneCategoryCommand : IGetOneBrandCommand
    {
        private readonly SatoviContext _context;

        public EfGetOneCategoryCommand(SatoviContext context)
        {
            _context = context;
        }

        public GetBrandDTO Execute(int request)
        {
            var brand = _context.Brands.Find(request);

            if (brand== null)
            {
                throw new EntityNotFoundException("Brand");
            }

            return new GetBrandDTO
            {
                Id = brand.Id,
                BrandName = brand.BrandName
            };
        }
    }
}
