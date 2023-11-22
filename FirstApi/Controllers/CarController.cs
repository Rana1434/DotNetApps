using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private IAccessories _accessories;
        private IApiLogger _logger;
        private Car _car;
        public CarController(Car c,IApiLogger logger,IAccessories accessories)
        {
            _accessories = accessories;
            _accessories.Log("Something is created");
            _car = c;
            _logger = logger;
            _logger.Log("CarController instance is created");
        }
        [HttpGet("/drives")]
        public IActionResult Drive()
        {
            _logger.Log("Driving() api called successfully");
            return Ok("Driving at 100kmph");
        }
    }
}
