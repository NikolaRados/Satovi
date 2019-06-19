using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviDomain
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
