using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviEfCommands
{
    public class EfGetOneUserCommand : IGetOneUserCommand
    {
        private readonly SatoviContext _context;

        public EfGetOneUserCommand(SatoviContext context)
        {
            _context = context;
        }

        public GetUserDto Execute(int request)
        {
            var user = _context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException("User");
            }

            return new GetUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                RoleName = user.Role.RoleName
            };
        }
    }
}
