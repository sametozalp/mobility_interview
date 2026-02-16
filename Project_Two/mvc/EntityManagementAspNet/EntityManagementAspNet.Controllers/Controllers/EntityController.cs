using EntityManagementAspNet.Business.Dtos;
using EntityManagementAspNet.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntityManagementAspNet.Controllers.Controllers
{
    public class EntityController : Controller
    {
        private readonly IPersonService _personService;

        public EntityController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            var people = _personService.getAll();
            return View(people);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            var results = _personService.search(name);
            return View("Index", results);
        }

        [HttpPost]
        public IActionResult Add(CreatePersonRequest request)
        {
            _personService.add(request);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string name)
        {
            _personService.delete(name);
            return RedirectToAction("Index");
        }

    }
}
