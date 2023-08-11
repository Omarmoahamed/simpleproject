using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simpleproject.models;
using System.Diagnostics;
using System.Xml;

namespace simpleproject.Controllers
{
    [Route("api/[controller]")]
    
    public class productsController : ControllerBase
    {

        private datacontext context;

        public productsController(datacontext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult< IQueryable<ProductBindingTarget>> GetProducts()
        {
            Func<product, ProductBindingTarget> func = p => new ProductBindingTarget() { categoryid = p.categoryid, Name = p.name, Price = p.price, supplierid = p.supplierid };
            var time = new Stopwatch();
            time.Start();
            var pr = context.products.Select(func);
                

            time.Stop();
            return Ok( time.ElapsedMilliseconds);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromServices] ILogger<productsController> logger, long id) {

            logger.LogDebug("getproduct action invoked");
            
            product? p =  await context.products.Where(p=> p.supplierid == id).FirstAsync() ;
            if (p == null) { return NotFound(); }
            return Ok(p);
            
        
        }


        [HttpDelete("{id}")]
        public void deleteproduct(long id) 
        {
            context.products.Remove(new product {productid= id});
            context.SaveChanges();
        }


        [HttpPost]
       
        public async Task<IActionResult> saveproduct([FromBody] ProductBindingTarget target) 
        {
            product? pr = target.toproduct();

            await context.products.AddAsync(pr);
            await context.SaveChangesAsync();

            return Ok(pr);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateproduct(long id) 
        {
            if (ModelState.IsValid)
            {
                var product = await context.products.Where(pro => pro.productid == id).FirstAsync();
                product.price = product.price *(decimal) 0.25+1;
                 context.products.Update(product);
               await context.SaveChangesAsync();
                return Ok(product);
            }

            return BadRequest(ModelState);

        }


        [HttpGet("redirect")]
        public IActionResult redirect() 
        {
            return RedirectToAction("getproduct", new { id = 3 });
        }


        [HttpGet("q/{id}")]

        public  IActionResult getquality(int id) 
        {
            
            var products = context.products.Where(p => p.quality == (product.productquality)id).ToList();
            
            if(products.Count ==0) 
            {
                return NotFound();
            }
            return Ok(products);

        }
    }
}
