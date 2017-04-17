using FormGenerator.Handler;
using Microsoft.AspNetCore.Mvc;

namespace FormGenerator.Web.Controllers
{
    [Route("form")]
    public class FormGeneratorController : Controller
    {
        private readonly IFormGeneratorHandler _formGeneratorService;

        public FormGeneratorController(IFormGeneratorHandler formGeneratorService)
        {
            _formGeneratorService = formGeneratorService;
        }

        [Route("{formCode}"), HttpGet]
        public IActionResult Get(string formCode)
        {
            var formFields = _formGeneratorService.GetFormViewModel(formCode);
            return View("Index", formFields);
        }
    }
}