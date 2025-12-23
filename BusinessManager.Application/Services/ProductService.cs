using BusinessManager.Application.DTOs;
using BusinessManager.Application.Interfaces;
using BusinessManager.Domain.Entities;
using BusinessManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task AddProductAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                Category = dto.Category,
                Brand = dto.Brand,
                Price = dto.Price,
                Stock = dto.Stock,
                IsActive = dto.IsActive
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (product == null)
                return false;

            product.ProductName = dto.ProductName;
            product.Category = dto.Category;
            product.Brand = dto.Brand;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(DeleteProductDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (product == null)
                return false;

            product.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
