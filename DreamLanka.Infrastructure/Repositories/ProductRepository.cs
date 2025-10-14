using DreamLanka.Domain.Entities;
using DreamLanka.Domain.Interfaces;
using DreamLanka.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DreamLanka.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Vendor)
            .Include(p => p.Reviews)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }

    public async Task<IEnumerable<Product>> GetByVendorIdAsync(int vendorId)
    {
        return await _context.Products
            .Include(p => p.Vendor)
            .Include(p => p.Reviews)
            .Where(p => p.VendorId == vendorId && !p.IsDeleted && p.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        return await _context.Products
            .Include(p => p.Vendor)
            .Include(p => p.Reviews)
            .Where(p => p.Category == category && !p.IsDeleted && p.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> SearchAsync(string searchTerm)
    {
        return await _context.Products
            .Include(p => p.Vendor)
            .Include(p => p.Reviews)
            .Where(p => (p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                     && !p.IsDeleted && p.IsActive)
            .ToListAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        product.UpdatedAt = DateTime.UtcNow;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            product.IsDeleted = true;
            product.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Products
            .AnyAsync(p => p.Id == id && !p.IsDeleted);
    }
}
