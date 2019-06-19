using SatoviApplication.DTO;
using SatoviApplication.Interfaces;
using SatoviApplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviApplication.Commands
{
    public interface IGetProductCommand : ICommand<ProductSearches, IEnumerable<GetProductDTO>>
    {

    }
}
