using SatoviApplication.DTO;
using SatoviApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviApplication.Commands
{
    public interface ICreateProductCommand : ICommand<CreateProductDto>
    {
    }
}
