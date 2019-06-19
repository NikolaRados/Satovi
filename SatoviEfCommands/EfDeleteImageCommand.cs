using SatoviApplication.Commands;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfDeleteImageCommand : IDeleteImageCommand
    {
        private readonly SatoviContext _context;

        public EfDeleteImageCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var image = _context.Images.Find(request);

            if (image == null)
            {
                throw new EntityNotFoundException("Image");
            }

            _context.Images.Remove(image);

            _context.SaveChanges();
        }
    }
}
