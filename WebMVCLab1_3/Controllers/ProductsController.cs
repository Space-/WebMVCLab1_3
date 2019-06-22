using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebMVCLab1_3.Models;

namespace WebMVCLab1_3.Controllers
{
    public class ProductsController : ApiController
    {
        private NorthwindMvc db = new NorthwindMvc();

        // GET: api/Products
        public HttpResponseMessage GetProducts()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, db.Products);
            return response;
        }

        // GET: api/Products/xxx
        public HttpResponseMessage GetProducts(string msg)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, msg);
            return response;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // topic: Homework2-PATCH實務需求-WebMVCLab1_3 project.md
        // case1: http://localhost:65411/api/products/65/2
        // case2: http://localhost:65411/api/products/65/3,4,5
        [Route("~/api/products/{id:int}/{categories}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PatchProduct(int id, [FromUri] string categories, Product patchData)
        {
            var categoryIds = categories.Split(',');
            // [FromUri]

            // must be deleted
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // must be deleted
            if (id != patchData.ProductID)
            {
                return BadRequest();
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return BadRequest();
            }

            // get all properties in Product
            foreach (var property in product.GetType().GetProperties())
            {
            }

            // update product contents
            if (Array.Exists(categoryIds, i => i == "2"))
            {
                product.ProductName = patchData.ProductName;
            }
            else if (Array.Exists(categoryIds, i => i == "3"))
            {
                product.UnitPrice = patchData.UnitPrice;
            }
            else if (Array.Exists(categoryIds, i => i == "4"))
            {
                product.UnitsInStock = patchData.UnitsInStock;
            }
            else if (Array.Exists(categoryIds, i => i == "5"))
            {
                product.UnitsOnOrder = patchData.UnitsOnOrder;
            }

            db.Entry(product).State = EntityState.Modified;
            //////

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PatchProduct(int id, Product patchData)
        {
            // must be deleted
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // must be deleted
            if (id != patchData.ProductID)
            {
                return BadRequest();
            }

            // update product name
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return BadRequest();
            }

            product.ProductName = patchData.ProductName;
            db.Entry(product).State = EntityState.Modified;
            //////

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}