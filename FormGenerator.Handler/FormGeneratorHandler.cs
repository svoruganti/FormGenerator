using System;
using System.Collections.Generic;
using FormGenerator.Mapper;
using FormGenerator.Service;
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
        public FormViewModel GetFormViewModel(FormCodeAndAdditionalParametersViewModel viewModel)
        {
            var form = _formGeneratorService.GetFormData(viewModel.FormCode);
            var formReferenceData = _formGeneratorService.GetFormReferenceData(viewModel.FormCode);

            var formViewModel = _formMapper.MapFormViewModel(form, formReferenceData);
            formViewModel.Description = "Additional params: " + viewModel.AdditionalParams.ToQueryString();
            formViewModel.LoadUrl = GetActionUrl(viewModel, "load");
            formViewModel.SaveUrl = GetActionUrl(viewModel, "savetest");
            return formViewModel;
        }

        public LoadFormDataViewModel GetFormData(FormCodeAndAdditionalParametersViewModel viewModel)
        {
            IDictionary<string, object> formData = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
            formData.Add("FBAE03_1", "First name");
            formData.Add("FBAE03_2", "Surname");
            formData.Add("FBAE03_4", "1");
            formData.Add("FBAE03_5", "Date of birth");
            return new LoadFormDataViewModel
            {
                FormData = formData
            };
        }

        private static string GetActionUrl(FormCodeAndAdditionalParametersViewModel viewModel, string action)
        {
            return $"/form/{viewModel.FormCode}/{action}?{viewModel.AdditionalParams.ToQueryString()}";
        }
    }
}