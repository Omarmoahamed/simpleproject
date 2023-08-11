using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simpleproject.models;
using simpleproject.repository;

namespace simpleproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reviewController : ControllerBase
    {
        public irepository<review> repository { get; set; }

        public reviewController(irepository<review> repository) 
        {
            this.repository = repository;
        }
        [HttpGet("string")]
        public string mm() 
        {
            return "heloo";

        }
    }
}
