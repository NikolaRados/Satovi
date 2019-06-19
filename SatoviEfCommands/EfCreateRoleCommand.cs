using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviDataAccess;
using SatoviDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfCreateRoleCommand : ICreateRoleCommand
    {
        private readonly SatoviContext _context;

        public EfCreateRoleCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(CreateRoleDto request)
        {
            _context.Roles.Add(new Role
            {
                CreatedAt = DateTime.Now,
                RoleName = request.RoleName
            });

            _context.SaveChanges();
        }
    }
}
