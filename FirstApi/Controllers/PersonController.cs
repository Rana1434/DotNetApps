using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IApiLogger _logger;
        public PersonController(IApiLogger logger)
        {
            _logger = logger;
        }

        [HttpGet("/api/people")]
        public IActionResult GetPeople()
        {
            _logger.Log("Start logging GetPeople()!");
            _logger.Log("GetPeople() api call successful!");
            return Ok(PersonOperations.GetPeople());

        }
        [HttpPost("/api/create")]
        public IActionResult CreatePerson([FromForm]Person p)
        {
            PersonOperations.CreateNew(p);
            _logger.Log("CreatePerson() api call successful!");
            return Created($"Created person with aadhar { p.Aadhar} successfully",p);
        }
        [HttpPut("/api/update/{pAadhar}")]
        public IActionResult UpdatePerson([FromRoute]string pAadhar, [FromBody]Person updatedPerson)
        {
            try
            {
                PersonOperations.Update(pAadhar, updatedPerson);
                _logger.Log("UpdatePerson() api call successful!");
                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
        [HttpDelete("/api/delete")]
        public IActionResult DeletePerson([FromQuery]string pAadhar)
        {
            try
            {
                PersonOperations.Delete(pAadhar);
                return Ok("Deleted Successfully");
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
    }
}
