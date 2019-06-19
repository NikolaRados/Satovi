using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviDataAccess;
using SatoviDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfCreateBrandCommand : ICreateBrandCommand
    {

        private readonly SatoviContext _context;

        public EfCreateBrandCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(CreateBrandDto request)
        {
            _context.Brands.Add(new Brand
            {
                CreatedAt = DateTime.Now,
                BrandName = request.BrandName
            }) ;


            _context.SaveChanges();
        }
    }
}
