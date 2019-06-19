﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviApplication.Searches
{
    public class ProductSearches
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }

        public string BrandName { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int PerPage { get; set; } = 2;

        public int PageNumber { get; set; } = 1;
    }
}
