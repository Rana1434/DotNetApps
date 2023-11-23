using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DalLib;

namespace Controllers
{
    public class HomeController : Controller
    {
        private readonly SSDbContext _context;

        public HomeController(SSDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Write your description here...";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact";

            return View();
        }

        public async Task<IActionResult> Men()
        {
            ViewData["Message"] = "category - Men";

            return View(await _context.Shoes.ToListAsync());
        }
            
        public async Task<IActionResult> Women()
        {
            ViewData["Message"] = "category  - Women";

            return View(await _context.Shoes.ToListAsync());
        }
        /*public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
        
    }
}
