using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    public class FirstController : Controller
    {
        [HttpGet("/hack")]
        public IActionResult Hack()
        {
            return Ok("Hello, Vidya is a Hacker!!");
        }
        [HttpGet("/simplegreet/{pName}")]
        public string SimpleGreet(string pName)
        {
            return $"Welcome to MVC , {pName}";
        }
        [HttpGet ("/getname")]
        public List<string> GetNames()
        {
            var names = new List<string>() { "Aaaa","Bbbb", "Cccc" };
            return names;
        }
        [HttpGet ("/add/{pname}/{pMarks}/{isPassed?}")]
        public string AddData(string pName,int pMarks,bool isPassed=true)
        {
            return $"{pName} secured {pMarks} in the exam and status of Passing is {isPassed}";
        }
        [HttpGet("/main")]
        public IActionResult GetIndexPage()
        {
            ViewBag.ReturnValue = "Something was said I did't listen";
            return View("MainPage");
        }
    }
}
