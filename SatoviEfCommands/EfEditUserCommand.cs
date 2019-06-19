using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoviEfCommands
{
    public class EfEditUserCommand : IEditUserCommand
    {
        private readonly SatoviContext _context;

        public EfEditUserCommand(SatoviContext context)
        {
            _context = context;
        }

        public void Execute(CreateUserDto request)
        {
            var user = _context.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException("User");
            }

            if (!_context.Roles.Any(r => r.Id == request.RoleId))
            {
                throw new EntityNotFoundException("Role");
            }

            user.ModifiedAt = DateTime.Now;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Username = request.Username;
            user.Password = request.Password;
            user.RoleId = request.RoleId;

            _context.SaveChanges();
        }
    }
}
