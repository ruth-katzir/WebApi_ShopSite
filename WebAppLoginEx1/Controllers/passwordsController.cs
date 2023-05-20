using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class passwordsController : ControllerBase
    {

        IPasswordsService service;

        public passwordsController(IPasswordsService service)
        {
            this.service = service;
        }

        // POST api/<passwordsController>
        [HttpPost]
        public int Post([FromBody] Password password)
        {
            return service.getPasswordRate(password);
        }
    }
}
