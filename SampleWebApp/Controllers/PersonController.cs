using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Models;
using System.Net.Cache;

namespace SampleWebApp.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet("/people")]
        public IActionResult GetPeople()
        {
            var people=PersonOperations.GetPeople();
            return View("PeopleList",people);
        }
        [HttpGet("/search/{pAadhar}")]
        public IActionResult GetPersonDetails(String pAadhar)
        {
            var found = PersonOperations.Search(pAadhar);
            return View("Search",found);
        }
        [HttpGet("/people/of/age/{startAge}/{endAge}")]
        public IActionResult GetActionWithinAge(int startAge,int endAge)
        {
            var people = PersonOperations.Range(startAge,endAge);
            return View("Range", people);
        }
        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View("Create",new Person());
        }
        [HttpPost("/create")]
        public IActionResult Create([FromForm]Person p)
        {
            PersonOperations.CreateNew(p);
            return View("PeopleList",PersonOperations.GetPeople());
        }
        [HttpGet("/edit/{pAadhar}")]
        public IActionResult Edit(string pAadhar)
        {
            var found=PersonOperations.Search(pAadhar);
            return View("Edit",found);
        }
        [HttpPost("/edit/{pAadhar}")]
        public IActionResult Edit(string pAadhar ,[FromForm]Person p)
        {
            var found = PersonOperations.Search(p.Aadhar);
            found.Email = p.Email;
            found.Age = p.Age;
            found.Name = p.Name;
            return View("PeopleList",PersonOperations.GetPeople());
        }
    }
}
