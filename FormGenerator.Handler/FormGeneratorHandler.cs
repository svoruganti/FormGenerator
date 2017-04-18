using System;
using System.Collections.Generic;
using FormGenerator.Mapper;
using FormGenerator.Service.Interface;
using FormGenerator.ViewModel;

namespace FormGenerator.Handler
{
    public class FormGeneratorHandler : IFormGeneratorHandler
    {
        private readonly IFormGeneratorService _formGeneratorService;
        private readonly IFormMapper _formMapper;
        private readonly IServiceProvider _serviceProvider;

        public FormGeneratorHandler(IFormGeneratorService formGeneratorService, IFormMapper formMapper)
        {
            _formGeneratorService = formGeneratorService;
            _formMapper = formMapper;
        }
        public FormViewModel GetFormViewModel(string formCode)
        {
            var form = _formGeneratorService.GetFormData(formCode);
            var formReferenceData = _formGeneratorService.GetFormReferenceData(formCode);
            return _formMapper.MapFormViewModel(form, formReferenceData);
        }

        public LoadFormDataViewModel GetFormData(string formCode)
        {
            IDictionary<string, object> formData = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
            formData.Add("FBAE03_1", "First name");
            formData.Add("FBAE03_2", "Surname");
            formData.Add("FBAE03_4", "1");
            return new LoadFormDataViewModel
            {
                FormData = formData
            };
        }
    }
}