using FruitApp.Data;
using FruitApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitApp.Controllers
{
    public class FruitController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public FruitController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var data = _dbContext.Fruits.ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult Create(List<Fruit> Fruit)
        {
            _dbContext.Fruits.AddRange(Fruit);
            _dbContext.SaveChanges();
            return Redirect("Index");
        }
    }
}
