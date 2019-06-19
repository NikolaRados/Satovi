using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SatoviApplication.DTO
{

        public class CreateProductDto
        {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }


            [Required]
            public string ProductName { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public decimal Price { get; set; }

            [Required]
            public int BrandId { get; set; }

            [Required]
            public int ImageId { get; set; }
        }
    }
