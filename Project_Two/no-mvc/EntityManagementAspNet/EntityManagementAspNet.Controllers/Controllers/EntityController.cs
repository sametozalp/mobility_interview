using EntityManagementAspNet.Business.Dtos;
using EntityManagementAspNet.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntityManagementAspNet.Controllers.Controllers
{
    [ApiController]
    [Route("api/entity")]
    public class EntityController : ControllerBase
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
            return Ok(people);
        }

        [HttpGet("search/{name}")]
        public IActionResult Search(string name)
        {
            var results = _personService.search(name);
            return Ok(results);
        }

        [HttpPost("add")]
        public IActionResult Add(CreatePersonRequest request)
        {
            _personService.add(request);
            return Ok();
        }

        [HttpDelete("delete/{name}")]
        public IActionResult Delete(string name)
        {
            _personService.delete(name);
            return Ok();
        }
    }
}