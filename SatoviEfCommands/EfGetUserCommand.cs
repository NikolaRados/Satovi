using Microsoft.EntityFrameworkCore;
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
    public class EfGetUserCommand : IGetUserCommand
    {
        private readonly SatoviContext _context;

        public EfGetUserCommand(SatoviContext context)
        {
            _context = context;
        }

        public IEnumerable<GetUserDto> Execute(UserSearches request)
        {
            var user = _context.Users.Include(r => r.Role).AsQueryable();

            if (request.FirstName != null)
            {
                user = user.Where(u => u.FirstName.ToLower() == request.FirstName.Trim().ToLower());
            }

            if (request.LastName != null)
            {
                user = user.Where(u => u.LastName.ToLower() == request.LastName.Trim().ToLower());
            }

            if (request.RoleName != null)
            {
                user = user.Where(u => u.Role.RoleName.ToLower() == request.RoleName.Trim().ToLower());
            }

            return user.Select(a => new GetUserDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                Username = a.Username,
                Password = a.Password,
                RoleName = a.Role.RoleName
            });
        }
    }
}
