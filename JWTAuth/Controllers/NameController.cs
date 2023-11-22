using JWTAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Controllers
{
    [EnableCors("MyPolicy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class NameController : ControllerBase
    {

        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public NameController(IJWTAuthenticationManager jWTAuthenticationManager)

        {

            this.jWTAuthenticationManager = jWTAuthenticationManager;

        }
        // GET: api/Name
        [HttpGet]
        public IEnumerable<string> Get() 
        { 
            return new string[] { "value1", "value2" }; 
        }
        // GET: api/Name/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]

        public IActionResult Authenticate([FromBody] UserCred userCred)

        {

            var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);



            if (token == null)

                return Unauthorized();



            return Ok(token);

        }
    }
}
