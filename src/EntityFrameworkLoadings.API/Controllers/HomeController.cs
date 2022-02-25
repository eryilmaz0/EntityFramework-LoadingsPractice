using EntityFrameworkLoadings.API.Context;
using EntityFrameworkLoadings.API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLoadings.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Seed Data
    [HttpGet]
    [Route("DataSeed")]
    public IActionResult Index()
    {
        List<User> users = new()
        {
            new()
            {
                Name = "User 1",
                LastName = "User 1",
                Email = "Email@gmail.com",
                Password = "1234",
                Orders = new List<Order>()
                {
                    new() { Created = DateTime.Now, Price = 100, OrderItems = "Order Items 1" },
                    new() { Created = DateTime.Now, Price = 200, OrderItems = "Order Items 2" },
                    new() { Created = DateTime.Now, Price = 300, OrderItems = "Order Items 3" },
                }
            },

            new()
            {
                Name = "User 2",
                LastName = "User 2",
                Email = "Email@gmail.com",
                Password = "1234",
                Orders = new List<Order>()
                {
                    new() { Created = DateTime.Now, Price = 100, OrderItems = "Order Items 4" },
                    new() { Created = DateTime.Now, Price = 200, OrderItems = "Order Items 5" },
                    new() { Created = DateTime.Now, Price = 300, OrderItems = "Order Items 6" },
                }
            },

            new()
            {
                Name = "User 3",
                LastName = "User 3",
                Email = "Email@gmail.com",
                Password = "1234",
                Orders = new List<Order>()
                {
                    new() { Created = DateTime.Now, Price = 100, OrderItems = "Order Items 7" },
                    new() { Created = DateTime.Now, Price = 200, OrderItems = "Order Items 8" },
                    new() { Created = DateTime.Now, Price = 300, OrderItems = "Order Items 9" },
                }
            }


        };

        _context.Users.AddRange(users);
        _context.SaveChanges();
        return Ok("Data Seeded.");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var user = _context.Users.First();
        
        //Loading related entities
        _context.Entry(user).Collection(x => x.Orders).Load();
        var orders = user.Orders;
        return Ok();
    }
    
    
}