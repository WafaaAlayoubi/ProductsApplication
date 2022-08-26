using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using ProductsApplication.Models;
using ProductsApplication.Services;

namespace ProductsApplication.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductControllerAPI : ControllerBase
    {
        ProductsDAO repository;
        public ProductControllerAPI()
        {
            repository = new ProductsDAO();
        }

        [HttpGet]
        //this is bc we returned IEnumerable
        [ResponseType(typeof(List<ProductModelDTO>))]
        public IEnumerable<ProductModelDTO> Index()
        {
            List<ProductModel> products = repository.GetAllProducts();
            IEnumerable<ProductModelDTO> productModelDTOs = from p in products select new ProductModelDTO(p);

            return productModelDTOs;
        }

        //Another way that i like
        //[HttpGet]
        //public ActionResult<IEnumerable<ProductModelDTO>> Index()
        //{
        //    List<ProductModel> products = repository.GetAllProducts();
        //    List<ProductModelDTO> productsDTOs = new List<ProductModelDTO>();

        //    foreach (ProductModel item in products)
        //        productsDTOs.Add(new ProductModelDTO(item));


        //    return productsDTOs;
        //}

        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult <IEnumerable<ProductModelDTO>> SearchResults(string searchTerm)
        {
            List<ProductModel> products = repository.SearchProducts(searchTerm);
            List<ProductModelDTO> productsDTOs = new List<ProductModelDTO>();

            foreach (ProductModel item in products)
                productsDTOs.Add(new ProductModelDTO(item));


            return productsDTOs;
          
        }

        [HttpGet("ShowOneProduct/{Id}")]
        public ActionResult<ProductModelDTO> ShowOneProduct(int Id)
        {
            ProductModel p = repository.GetProductById(Id);
            return new ProductModelDTO(p);
        }

        [HttpPost("InsertOne")]
        //post action
        //expecting a product in json format in the body of the request.
        public ActionResult <int> InsertOne(ProductModel product)
        {

            return repository.Insert(product);
           
        }

        [HttpPut("ProcessEdit")]
        public ActionResult <int> ProcessEdit(ProductModel product)
        {
            return repository.Update(product);

        }

        [HttpDelete("Delete/{id}")]
        public ActionResult <int> Delete(int id)
        {
           
            return repository.Delete(repository.GetProductById(id));
            
        }

    }
}