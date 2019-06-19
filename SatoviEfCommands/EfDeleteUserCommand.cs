using SatoviApplication.Commands;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly SatoviContext _context;

        public EfDeleteUserCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException("User");
            }

            _context.Users.Remove(user);

            _context.SaveChanges();
        }
    }
}
