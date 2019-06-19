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
    public class EfGetRoleCommand : IGetRoleCommand
    {
        private readonly SatoviContext _context;

        public EfGetRoleCommand(SatoviContext context)
        {
            _context = context;
        }

        public IEnumerable<GetRoleDto> Execute(RoleSearches request)
        {
            var role = _context.Roles.Include(r => r.Users).AsQueryable();

            if (request.RoleName != null)
            {
                role = role.Where(r => r.RoleName.ToLower() == request.RoleName.Trim().ToLower());
            }

            if (request.FirstName != null)
            {
                role = role.Where(r => r.Users.Any(u => u.FirstName.ToLower() == request.FirstName.Trim().ToLower()));
            }

            if (request.LastName != null)
            {
                role = role.Where(r => r.Users.Any(u => u.LastName.ToLower() == request.LastName.Trim().ToLower()));
            }

            return role.Select(b => new GetRoleDto
            {
                Id = b.Id,
                RoleName = b.RoleName,
                Users = b.Users.Select(c => new GetUserDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Username = c.Username
                }).ToList()

            }).ToList();
        }
    }
}
