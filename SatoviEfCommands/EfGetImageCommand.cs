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
    public class EfGetImageCommand : IGetImageCommand
    {
        private readonly SatoviContext _context;

        public EfGetImageCommand(SatoviContext context)
        {
            _context = context;
        }

        public IEnumerable<GetImageDto> Execute(ImageSearches request)
        {
            var image = _context.Images.AsQueryable();

            if (request.Alt != null)
            {
                image = image.Where(i => i.Alt.ToLower() == request.Alt.Trim().ToLower());
            }

            return image.Select(i => new GetImageDto
            {
                Id = i.Id,
                Src = i.Src,
                Alt = i.Alt,
                Title = i.Title
            });

        }
    }
}
