using Mapster;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.OrderModels;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class OrderManager : IOrderManager
{
    private readonly IOrderRepository _OrderRepository;
    private readonly ICustomerRepository _customerRepository;
    public OrderManager(IOrderRepository OrderRepository, ICustomerRepository customerRepository)
    {
        _OrderRepository = OrderRepository;
        _customerRepository = customerRepository;
    }

    public async Task CreateOrder(int customerId, CreateOrder createOrder)
    {
        if (await _customerRepository.GetCustomerById(customerId) == null)
            throw new Exception("Customer is not found");

        var order = createOrder.Adapt<Order>();
        order.CustomerId = customerId;
        
        await _OrderRepository.CreateOrder(order);
    }

    public async Task<Order?> GetOrderById(int OrderId)
    {
        var order = await _OrderRepository.GetOrderById(OrderId);
        return order;
    }

    public async Task<List<Order>?> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _OrderRepository.GetOrdersByCustomerId(customerId);
        return orders;
    }

    public async Task<List<Order>?> GetOrdersByFilter(OrderFilter OrderFilter)
    {
        var orders = await _OrderRepository.GetOrdersByFilter(OrderFilter);
        return orders;
    }

    public async Task UpdateOrder(int customerId, int OrderId, UpdateOrder updateOrder)
    {
        var order = await _OrderRepository.GetOrderById(OrderId);
        if (order == null) 
            throw new Exception("Order is not found");
        
        order.OrderDate = updateOrder.OrderDate;
        order.Price = updateOrder.Price;
        order.Name = updateOrder.Name;

        await _OrderRepository.UpdateOrder(order);
    }
}

