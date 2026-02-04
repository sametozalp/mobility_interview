using EntityManagementAspNet.Business.Dtos;
using EntityManagementAspNet.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntityManagementAspNet.Controllers.Controllers
{
    [Route("api/weboperation")]
    public class WebOperationController : Controller
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
            return View(operations);
        }

        [HttpGet("search/{name}")]
        public IActionResult Search(string name)
        {
            var results = _webOperationService.search(name);
            return View("List", results);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CreateWebServiceOperationRequest request)
        {
            _webOperationService.add(request);
            return RedirectToAction(nameof(List));
        }

        [HttpPost("delete/{name}")]
        [HttpDelete("delete/{name}")]
        public IActionResult Delete(string name)
        {
            _webOperationService.delete(name);
            return RedirectToAction(nameof(List));
        }
    }
}
