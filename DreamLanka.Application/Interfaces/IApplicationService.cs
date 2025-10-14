using DreamLanka.Application.DTOs;

namespace DreamLanka.Application.Interfaces;

public interface IApplicationService
{
    // User operations
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<UserDto?> GetUserByIdAsync(int id);
    Task<UserDto?> GetUserByEmailAsync(string email);
    Task<List<UserDto>> GetAllUsersAsync(int pageNumber = 1, int pageSize = 10);
    Task<UserDto> UpdateUserAsync(int id, CreateUserDto updateUserDto);
    Task<bool> DeleteUserAsync(int id);

    // Product operations
    Task<ProductDto> CreateProductAsync(int vendorId, CreateProductDto createProductDto);
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<List<ProductDto>> GetProductsByCategoryAsync(string category, int pageNumber = 1, int pageSize = 10);
    Task<List<ProductDto>> SearchProductsAsync(string searchTerm, int pageNumber = 1, int pageSize = 10);

    // Order operations
    Task<OrderDto> CreateOrderAsync(int customerId, int vendorId, List<OrderItemDto> orderItems, string? customerNotes = null);
    Task<OrderDto?> GetOrderByIdAsync(int id);
    Task<List<OrderDto>> GetOrdersByCustomerAsync(int customerId);
    Task<List<OrderDto>> GetOrdersByVendorAsync(int vendorId);
    Task<bool> UpdateOrderStatusAsync(int orderId, string status, string? notes = null);
}