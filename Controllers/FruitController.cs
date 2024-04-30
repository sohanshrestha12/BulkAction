using FruitApp.Data;
using FruitApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var data = _dbContext.Fruits.Where(x => x.IsDeleted != true).ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult Create(List<Fruit> Fruit)
        {

/*
            _dbContext.Fruits.RemoveRange(_dbContext.Fruits);
            _dbContext.SaveChanges();
            foreach (var fruit in Fruit)
            {
                fruit.Id = 0;
            }
            _dbContext.Fruits.AddRange(Fruit);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");*/


            foreach(var fruit in Fruit) {
                var existingFruit = _dbContext.Fruits.FirstOrDefault(x => x.Id == fruit.Id);
                if (existingFruit != null)
                {
                     existingFruit.Name = fruit.Name ;
                     existingFruit.Price = fruit.Price ;
                    existingFruit.Category = fruit.Category;
                    existingFruit.Season = fruit.Season;
                }
                else
                {
                    _dbContext.Fruits.Add(fruit);
                }
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(List<Fruit> Fruit)
        {
            /*foreach (var fruit in Fruit)
            {
                var existingFruit = _dbContext.Fruits.FirstOrDefault(f => f.Id == fruit.Id);
                if (existingFruit != null && fruit.IsChecked == true)
                {
                    existingFruit.IsDeleted = true;
                }
            }
            _dbContext.SaveChanges();*/
            foreach (var fruit in Fruit)
            {
                if (fruit.IsChecked == true)
                {
                    var existingFruit = _dbContext.Fruits.FirstOrDefault(f => f.Id == fruit.Id);
                    if (existingFruit != null)
                    {
                        existingFruit.IsDeleted = true;

                    }
                }
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
