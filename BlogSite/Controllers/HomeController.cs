using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogSite.Models;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyzer _analyzer;

        public HomeController(IAnalyzer analyzer)
        {
            _analyzer = analyzer;
        }

        public IActionResult Index()
        {
            ViewData["NumberOfBlogs"] = _analyzer.GetCountOfBlogs();
            ViewData["AverageNumberOfPosts"] = _analyzer.GetAveragePostsPerBlogs();

            ViewData["Message"] = "The home page here.";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
