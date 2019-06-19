using SatoviApplication.DTO;
using SatoviApplication.Interfaces;
using SatoviApplication.Response;
using SatoviApplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviApplication.Commands
{
    public interface IGetProductCommandPaginate : ICommand<ProductSearches, PagedResponse<GetProductDTO>>
    {
    }
}
