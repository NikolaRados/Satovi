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
    public class EfGetBrandCommand : IGetBrandCommand
    {

        private readonly SatoviContext _context;

        public EfGetBrandCommand(SatoviContext context)
        {
            _context = context;
        }

        public IEnumerable<GetBrandDTO> Execute(BrandSearches request)
        {
            var category = _context.Brands.AsQueryable();

            if (request.BrandName != null)
            {
                category = category.Where(b => b.BrandName.ToLower() == request.BrandName.Trim().ToLower());
            }

            return category.Select(b => new GetBrandDTO
            {
                Id = b.Id,
                BrandName = b.BrandName
            });
        }
    }
}
