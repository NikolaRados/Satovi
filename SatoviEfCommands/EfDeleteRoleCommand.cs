using SatoviApplication.Commands;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfDeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly SatoviContext _context;

        public EfDeleteRoleCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var role = _context.Roles.Find(request);

            if (role == null)
            {
                throw new EntityNotFoundException("Role");
            }

            _context.Roles.Remove(role);

            _context.SaveChanges();


        }
    }
}
