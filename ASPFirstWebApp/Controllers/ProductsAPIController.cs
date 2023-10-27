using ASPFirstWebApp.Models;
using ASPFirstWebApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace ASPFirstWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsAPIController : ControllerBase
    {
        ProductDAO repo = new ProductDAO();
        public ProductsAPIController()
        {
            repo = new ProductDAO();
        }

        /// <summary>
        /// Left off here\ | index
        /// </summary>
        /// <returns></returns>

        //Home
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Index()
        {
            return repo.AllProducts();
        }

        //Searching Methods
        [HttpGet("searchresults/{searchTerm}")]
        public ActionResult<IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            return repo.SearchProducts(searchTerm);
        }

        //END - Searching Methods

        //Details of one product
        [HttpGet("showoneproduct/{Id}")]
        [ResponseType(typeof(ProductDTO))]
        public ActionResult<ProductDTO> ShowOneProduct(int Id)
        {
            //get the correct product from the DB
            ProductModel model = repo.GetProductById(Id);

            //create a new DTO based on product
            ProductDTO productDTO = new ProductDTO(model);
            return productDTO;
        }

        //Update
        [HttpPut("processedit")]
        public ActionResult<IEnumerable<ProductModel>> ProcessEdit(ProductModel product)
        {
            repo.Update(product);
            return repo.AllProducts();
        }

        [HttpPut("processeditreturnoneitem")]
        public ActionResult<ProductModel> ProcessEditReturnOneItem(ProductModel product)
        {
            repo.Update(product);
            return repo.GetProductById(product.Id);
        }

        [HttpDelete("delete/{Id}")]
        public ActionResult<IEnumerable<ProductModel>> ProcessDelete(int Id)
        {
            repo.Delete(Id);
            return repo.AllProducts();
        }
        //show json
        //public IActionResult ShowOneJSON(int Id)
        //{
        //    return Json(repo.GetProductById(Id));
        //}

        //public IActionResult ProcessEditReturnPartial(ProductModel product)
        //{
        //    repo.Update(product);
        //    return PartialView("_productCard", product);
        //}
        //END - Update


    }
}
