using EntityManagementAspNet.Business.Dtos;
using EntityManagementAspNet.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntityManagementAspNet.Controllers.Controllers
{
    [ApiController]
    [Route("api/webService")]
    public class WebOperationController : ControllerBase
    {
        private readonly IWebOperationService _webOperationService;

        public WebOperationController(IWebOperationService webOperationService)
        {
            _webOperationService = webOperationService;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var operations = _webOperationService.getAll();
            return Ok(operations);
        }

        [HttpGet("search/{name}")]
        public IActionResult Search(string name)
        {
            var results = _webOperationService.search(name);
            return Ok(results);
        }

        [HttpPost("add")]
        public IActionResult Add(CreateWebServiceOperationRequest request)
        {
            _webOperationService.add(request);
            return Ok();
        }

        [HttpDelete("delete/{name}")]
        public IActionResult Delete(string name)
        {
            _webOperationService.delete(name);
            return Ok();
        }
    }
}
