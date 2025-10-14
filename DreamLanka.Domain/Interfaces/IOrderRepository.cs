using DreamLanka.Domain.Entities;

namespace DreamLanka.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
    Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId);
    Task<IEnumerable<Order>> GetByVendorIdAsync(int vendorId);
    Task<IEnumerable<Order>> GetByDeliveryPartnerIdAsync(int deliveryPartnerId);
    Task<Order> AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}