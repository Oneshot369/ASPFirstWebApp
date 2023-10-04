using ASPFirstWebApp.Models;
using ASPFirstWebApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace ASPFirstWebApp.Controllers
{
    public class ProductsController : Controller
    {
        
        public IActionResult Index()
        {
            HardCodedSampleDataRepository repo = new HardCodedSampleDataRepository();
            
            return View(repo.AllProducts());
        }

        public IActionResult Movie()
        {
            HardCodedSampleDataRepositoryMovie repo = new HardCodedSampleDataRepositoryMovie();
            return View(repo.AllProducts());
        }
    }
}
