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

        //Home
        [HttpGet]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> Index()
        {
            List<ProductModel> proudctModels = repo.AllProducts();
            //make it into a DTO
            IEnumerable<ProductDTO> productDTOList = from p in proudctModels
                                                     select
                                                     new ProductDTO(p);

            return productDTOList;
        }

        //Searching Methods
        [HttpGet("searchresults/{searchTerm}")]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> SearchResults(string searchTerm)
        {
            List<ProductModel> proudctModels = repo.SearchProducts(searchTerm);
            //make it into a DTO
            IEnumerable<ProductDTO> productDTOList = from p in proudctModels
                                                     select
                                                     new ProductDTO(p);
            return productDTOList;
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
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> ProcessEdit(ProductModel product)
        {
            repo.Update(product);
            List<ProductModel> proudctModels = repo.AllProducts();
            //make it into a DTO
            IEnumerable<ProductDTO> productDTOList = from p in proudctModels
                                                     select
                                                     new ProductDTO(p);

            return productDTOList;
        }

        [HttpPut("processeditreturnoneitem")]
        public ProductDTO ProcessEditReturnOneItem(ProductModel product)
        {
            repo.Update(product);
            ProductModel proudctModel = repo.GetProductById(product.Id);
            //make it into a DTO
            ProductDTO productDTO = new ProductDTO(proudctModel);

            return productDTO;
        }

        //[HttpDelete("delete/{Id}")]
        //public ActionResult<IEnumerable<ProductModel>> ProcessDelete(int Id)
        //{
        //    repo.Delete(Id);
        //    return repo.AllProducts();
        //}
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
