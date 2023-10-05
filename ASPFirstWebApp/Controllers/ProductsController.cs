using ASPFirstWebApp.Models;
using ASPFirstWebApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace ASPFirstWebApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductDAO repo = new ProductDAO();
        public ProductsController()
        {
            repo = new ProductDAO();
        }
        public IActionResult Index()
        {
            return View(repo.AllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            return View("Index", repo.SearchProducts(searchTerm));
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult Movie()
        {
            HardCodedSampleDataRepositoryMovie repo = new HardCodedSampleDataRepositoryMovie();
            return View(repo.AllProducts());
        }
    }
}
