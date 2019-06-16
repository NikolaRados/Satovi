using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviDomain
{
    public class Image : BaseEntity
    {
        public string Src { get; set; }

        public string Alt { get; set; }

        public string Title { get; set; }

        public Product Product { get; set; }
    }
}
