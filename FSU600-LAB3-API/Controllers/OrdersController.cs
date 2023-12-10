using FSU600_LAB3_API.Data;
using FSU600_LAB3_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        // Include User and OrderItems (and Product within each OrderItem) if you have such a relationship
        return await _context.Orders
                             .Include(o => o.User)
                             // .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                             .ToListAsync();
    }

    // GET: api/Orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        // Include User and OrderItems (and Product within each OrderItem) if you have such a relationship
        var order = await _context.Orders
                                  .Include(o => o.User)
                                  // .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                                  .SingleOrDefaultAsync(o => o.OrderId == id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }



    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Additional methods can be added here to handle order updates or specific business logic related to orders

    private bool OrderExists(int id)
    {
        return _context.Orders.Any(e => e.OrderId == id);
    }
}
