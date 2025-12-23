using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Application.DTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
