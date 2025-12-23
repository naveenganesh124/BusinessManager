using BusinessManager.Application.DTOs;
using BusinessManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task AddProductAsync(CreateProductDto dto);
        Task<bool> UpdateProductAsync(UpdateProductDto dto);
        Task<bool> DeleteProductAsync(DeleteProductDto dto);
    }
}
