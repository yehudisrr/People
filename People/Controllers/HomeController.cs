using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using People.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace People.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
@"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=true;";

        public IActionResult Index()
        {
            PeopleDb db = new PeopleDb(_connectionString);
            PeopleViewModel vm = new PeopleViewModel();

            vm.People = db.GetPeople();
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            PeopleDb db = new PeopleDb(_connectionString);
            foreach (var person in people)
            {
                db.AddPerson(person);
            }

            string text = "people";
            if(people.Count == 1)
            {
                text = "person";
            }
            TempData["message"] = $"{people.Count} {text} added successfully!";

            return Redirect("/Home/Index");
        }

    }
}
