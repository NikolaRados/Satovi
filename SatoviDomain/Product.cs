using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviDomain
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
