using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfEditRoleCommand : IEditRoleCommand
    {
        private readonly SatoviContext _context;

        public EfEditRoleCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(CreateRoleDto request)
        {
            var role = _context.Roles.Find(request.Id);

            if (role == null)
            {
                throw new EntityNotFoundException("Role");
            }

            role.ModifiedAt = DateTime.Now;
            role.RoleName = request.RoleName;


            _context.SaveChanges();

        }
    }
}
