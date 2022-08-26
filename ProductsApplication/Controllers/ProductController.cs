using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using ProductsApplication.Models;
using ProductsApplication.Services;

namespace ProductsApplication.Controllers
{
    public class ProductController : Controller
    {
        ProductsDAO repository;
        public ProductController()
        {
            repository = new ProductsDAO();
        }
        public IActionResult Index()
        {
            
            return View(repository.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            return View("index",productList);
        }

        public IActionResult ShowDetails(int id)
        {
            ProductsDAO product = new ProductsDAO();
            ProductModel foundProduct = product.GetProductById(id);
            return View(foundProduct);
        }

        public IActionResult Edit(int id)
        {
            ProductsDAO product = new ProductsDAO();
            ProductModel foundProduct = product.GetProductById(id);
            return View("ShowEdit",foundProduct);
        }
        public IActionResult ProcessEdit(ProductModel product)
        {
            
            repository.Update(product);
            return View("Index", repository.GetAllProducts());
        }
        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            
            repository.Update(product);
            return PartialView("_ProductCard", product);
        }

        public IActionResult Delete(ProductModel product)
        {
            
            repository.Delete(product);
            return View("Index", repository.GetAllProducts());
        }


        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ProcessCreate(ProductModel product)
        {
            
            int foundProduct = repository.Insert(product);
            return View("index", repository.GetAllProducts());
        }

        public IActionResult ShowOneProduct(int Id)
        {
            
            return View(repository.GetProductById(Id));
        }
        public IActionResult ShowOneProductJSON(int Id)
        {
             
            return Json(repository.GetProductById(Id));
        }
    }
}