using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoiseMeterLib.BusinessModels;
using NoiseMeterLib.Contexts;
using NoiseMeterLib.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoiseMeterRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly InMemoryDBContext context;
        public LoginController(InMemoryDBContext context)
        {
            this.context = context;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await context.Users.ToListAsync();
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] UserBusiness value)
        {

            if (value == null)
            {
                return BadRequest(false);
            }
            var founduser = context.Users.FirstOrDefault(x => x.Username == value.Username);
            if (founduser is not null) 
            {
                if (founduser.Password == value.Password)
                {
                    return Ok(true);
                }
            }

            return Ok(false);
        }

        // PUT api/<LoginController>/5 - Mikail
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5 - Mahir
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

     
        // Audhubillah api/<LoginController>/5 - Adem
        [HttpDelete("{id}")]
        public void Audhubillah(int id)
        {
        }



    }
}
