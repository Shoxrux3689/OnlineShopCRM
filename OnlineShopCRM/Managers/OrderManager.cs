﻿using Mapster;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Filters;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Models.OrderModels;
using OnlineShopCRM.Repositories.Interfaces;

namespace OnlineShopCRM.Managers;

public class OrderManager : IOrderManager
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    public OrderManager(IOrderRepository orderRepository, ICustomerRepository customerRepository)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
    }

    public async Task CreateOrder(int customerId, CreateOrderModel createOrder)
    {
        if (await _customerRepository.GetCustomerById(customerId) == null)
            throw new Exception("Customer is not found");

        var order = createOrder.Adapt<Order>();
        order.CustomerId = customerId;
        
        await _orderRepository.CreateOrder(order);
    }

    public async Task<Order?> GetOrderById(int OrderId)
    {
        var order = await _orderRepository.GetOrderById(OrderId);
        return order;
    }

    public async Task<List<Order>?> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderRepository.GetOrdersByCustomerId(customerId);
        return orders;
    }

    public async Task<List<Order>?> GetOrdersByFilter(OrderFilter orderFilter)
    {
        var orders = await _orderRepository.GetOrdersByFilter(orderFilter);
        return orders;
    }

    public async Task UpdateOrder(int customerId, int orderId, UpdateOrderModel updateOrder)
    {
        var order = await _orderRepository.GetOrderById(orderId);
        if (order == null) 
            throw new Exception("Order is not found");
        
        order = updateOrder.Adapt<Order>();

        await _orderRepository.UpdateOrder(order);
    }
}

