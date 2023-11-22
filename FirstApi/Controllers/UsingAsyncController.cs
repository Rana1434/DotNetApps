using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsingAsyncController : ControllerBase
    {
        public UsingAsyncController()
        {
            System.IO.File.WriteAllText(@"SomeFile.txt", "ha ha ha");
        }
        [HttpGet("/async")]
        public async Task<string> ReadFile()
        {
            using (StreamReader r = new StreamReader(@"SomeFile.txt"))
            {
                return await r.ReadToEndAsync();
            }
        }
    }
}
