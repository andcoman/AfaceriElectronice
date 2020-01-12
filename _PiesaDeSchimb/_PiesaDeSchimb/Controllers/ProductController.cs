using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Shop.Administration;
using System.Linq;

namespace _PiesaDeSchimb.Controllers
{
    public class ProductController : Controller
    {
        public string SearchTerm { get; set; }

        private readonly InMemoryProduct inMemoryProduct;

        private readonly List<Product> productsList;
        public IEnumerable<Product> Products { get; set; }

        public ProductController(InMemoryProduct inMemoryProduct)
        {
            this.inMemoryProduct = inMemoryProduct;
        }
 
        // GET: Products
        public ActionResult Index()
        {
            return View(inMemoryProduct.GetAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = inMemoryProduct.GetById(id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]                
        public ActionResult Create(Product product)
        {
           if(ModelState.IsValid)
            {
                inMemoryProduct.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var product = inMemoryProduct.GetById(id);

            if(product == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Product product)
        {
            if(id != product.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                inMemoryProduct.Update(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {

            var product = inMemoryProduct.GetById(id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var product = inMemoryProduct.GetById(id);
                inMemoryProduct.Delete(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}