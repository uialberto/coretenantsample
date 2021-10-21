using AppWeb.DataAccess.Context;
using AppWeb.Helpers;
using AppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SingleTenantDbContext _context;
        public HomeController(ILogger<HomeController> logger, SingleTenantDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var count = _context.Products.Count();
            var productos = _context.Products;
            ViewData["TenantName"] = HttpContext.GetTenant<TenantDto>()?.Items["Name"];
            return View(productos);
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