using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviDataAccess;
using SatoviDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfCreateImageCommand : ICreateImageCommand
    {
        private readonly SatoviContext _context;

        public EfCreateImageCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(CreateImageDto request)
        {
            _context.Images.Add(new Image
            {

                CreatedAt = DateTime.Now,
                Src = request.Src,
                Alt = request.Alt,
                Title = request.Title
            });

            _context.SaveChanges();
        }
    }
}
