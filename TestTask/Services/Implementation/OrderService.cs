using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext cont)
        {
            _context = cont;
        }

        public Task<Order> GetOrder()
        {
            Task<Order> order =_context.Orders.OrderByDescending(s => s.Price * s.Quantity).FirstOrDefaultAsync();
            return order;
        }

        public Task<List<Order>> GetOrders()
        {
            Task<List<Order>> orders = _context.Orders.Where(c => c.Quantity > 10).ToListAsync();
            return orders;
        }
    }
}
