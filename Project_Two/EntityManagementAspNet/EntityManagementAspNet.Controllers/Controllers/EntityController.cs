using EntityManagementAspNet.Business.Dtos;
using EntityManagementAspNet.Business.Service;
using EntityManagementAspNet.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EntityManagementAspNet.Controllers.Controllers
{
    [Route("api/entity")]
    public class EntityController : Controller
    {

        private IPersonService _personService;
        public EntityController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var people = _personService.getAll();
            return View(people);
        }

        [HttpGet("search/{name}")]
        public IActionResult Search(string name)
        {
            var results = _personService.search(name);
            return View("List", results);
        }

        [HttpPost("add")]
        public IActionResult Add(CreatePersonRequest request)
        {
            _personService.add(request);
            return RedirectToAction(nameof(List));
        }

        [HttpPost("delete/{name}")]
        [HttpDelete("delete/{name}")]
        public IActionResult Delete(string name)
        {
            _personService.delete(name);
            return RedirectToAction(nameof(List));
        }
    }
}