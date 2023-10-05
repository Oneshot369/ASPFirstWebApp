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
        //Home
        public IActionResult Index()
        {
            return View(repo.AllProducts());
        }

        //Searching Methods
        public IActionResult SearchResults(string searchTerm)
        {
            return View("Index", repo.SearchProducts(searchTerm));
        }

        public IActionResult SearchForm()
        {
            return View();
        }
        //END - Searching Methods

        //Details of one product
        public IActionResult ShowOneProduct(int Id)
        {
            return View(repo.GetProductById(Id));
        }

        //Update
        public IActionResult ShowEditForm(int Id)
        {
            return View(repo.GetProductById(Id));
        }
        public IActionResult ProcessEdit(ProductModel product)
        {
            repo.Update(product);
            return View("Index", repo.AllProducts());
        }
        //END - Update
        public IActionResult ProcessDelete(int Id)
        {
            repo.Delete(Id);
            return View("Index", repo.AllProducts());
        }
        //Update

        //END - Update

        //movie
        public IActionResult Movie()
        {
            HardCodedSampleDataRepositoryMovie repo = new HardCodedSampleDataRepositoryMovie();
            return View(repo.AllProducts());
        }
    }
}
