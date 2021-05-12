using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.DataAccessLayer;
using FrontToBack.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var slider = _dbContext.Slider.FirstOrDefault();
            var sliderImages = _dbContext.SliderImages.ToList();
            var categories = _dbContext.Categories.ToList();
            var products = _dbContext.Products.Include(x => x.Category).ToList();
            var about = _dbContext.About.FirstOrDefault();
            var aboutPolicies = _dbContext.AboutPolicies.ToList();

            var homeViewModel = new HomeViewModel
            {
                Slider = slider,
                SliderImages = sliderImages,
                Categories = categories,
                Products = products,
                About = about,
                AboutPolicies = aboutPolicies
            };

            return View(homeViewModel);
        }
    }
}
