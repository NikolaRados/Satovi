using SatoviApplication.Commands;
using SatoviApplication.DTO;
using SatoviApplication.Exceptions;
using SatoviApplication.Interfaces;
using SatoviDataAccess;
using SatoviDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SatoviEfCommands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly SatoviContext _context;
        private readonly IEmail _email;

        public EfCreateUserCommand(SatoviContext context, IEmail email)
        {
            _context = context;
            _email = email;
        }

        public void Execute(CreateUserDto request)
        {
            if (!_context.Roles.Any(r => r.Id == request.RoleId))
            {
                throw new EntityNotFoundException("Role");
            }

            _context.Users.Add(new User
            {
                CreatedAt = DateTime.Now,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                RoleId = request.RoleId
            });

            _context.SaveChanges();


            _email.Subject = "Uspesno ste se registrovali";
            _email.Body = "Uspesno ste se registrovali na sajt Satovi.";
            _email.ToEmail = "nikola.radosavljevic.29.14@ict.edu.rs";
            _email.Send();
        }
    }
}
