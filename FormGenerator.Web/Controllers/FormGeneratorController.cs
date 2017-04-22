using System.Collections.Generic;
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

        [Route("{formCode}/load"), HttpGet]
        public IActionResult Load(string formCode)
        {
            var formData = _formGeneratorService.GetFormData(formCode);
            return Json(formData);
        }

        [Route("{formCode}/save")]
        public IActionResult Post()
        {
            Response.StatusCode = 422;
            var errors = new Dictionary<string, string>
            {
                {"FBAE03_1", "Is required"},
                {"FBAE03_2", "Is too long"},
                {"FBAE03_5", "Is too short"}
            };
            return Json(errors);
        }
    }
}