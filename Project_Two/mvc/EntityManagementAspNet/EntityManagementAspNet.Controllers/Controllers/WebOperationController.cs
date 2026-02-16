using EntityManagementAspNet.Business.Dtos;
using EntityManagementAspNet.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntityManagementAspNet.Controllers.Controllers
{
    public class WebOperationController : Controller
    {
        private readonly IWebOperationService _webOperationService;

        public WebOperationController(IWebOperationService webOperationService)
        {
            _webOperationService = webOperationService;
        }

        public IActionResult Index()
        {
            var people = _webOperationService.getAll();
            return View(people);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            var results = _webOperationService.search(name);
            return View("Index", results);
        }

        [HttpPost]
        public IActionResult Add(CreateWebServiceOperationRequest request)
        {
            _webOperationService.add(request);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string name)
        {
            _webOperationService.delete(name);
            return RedirectToAction("Index");
        }
    }
}
