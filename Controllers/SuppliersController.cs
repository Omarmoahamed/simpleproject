using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simpleproject.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using simpleproject.repository;
using System.Diagnostics;

namespace simpleproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private datacontext context;
        private irepository<supplier> repo;
        public SuppliersController(datacontext context, irepository<supplier> repo)
        {
            this.repo = repo;
            this.context = context;
        }


        [HttpGet]
        public ActionResult< IEnumerable<supplier>> getall() 
        {
            Func<supplier, supplierbinding> func = s => new supplierbinding() { name = s.name };
            var time = new Stopwatch();
            time.Start();
            var supplier = context.suppliers.ToList();
            time.Stop();
            return Ok(time.ElapsedMilliseconds);
            
        }




            

        [HttpGet("{id}")]
        public async Task<product?> getsupplier(int id) 
        {

            var supplier = await  repo.Query().Include(s => s.products).FirstAsync();

            var product = supplier.products!.FirstOrDefault(p=> p.productid== id);

      
            return product;
        }


        [HttpPatch("{id}")]
        public async Task<supplier?> patchsupplier(long id,[FromServices] JsonPatchDocument<supplier> patchdoc) 
        {
            supplier? supplier = await context.suppliers.FindAsync(id);
            if (supplier != null) 
            {
                patchdoc.ApplyTo(supplier);
                await context.SaveChangesAsync();
            }
            return supplier;
        }
    }
}
