using System;
using System.Collections.Generic;
using FormGenerator.Mapper;
using FormGenerator.Model;
using FormGenerator.Repository;
using FormGenerator.Service.Interface;
using FormGenerator.ViewModel;

namespace FormGenerator.Service
{
    public class FormGeneratorService : IFormGeneratorService<SaveFormDataViewModel, SubmitFormDataViewModel, CancelFormDataViewModel, GenericActionFormDataViewModel>
    {
        private readonly IFormGeneratorRepository _repository;
        private readonly IFormMapper _formMapper;

        public FormGeneratorService(IFormGeneratorRepository repository, IFormMapper formMapper)
        {
            _repository = repository;
            _formMapper = formMapper;
        }
        public FormViewModel GetForm(FormCodeAndAdditionalParametersViewModel viewModel)
        {
            var form = _repository.GetForm(viewModel.FormCode);
            var formReferenceData = _repository.GetReferenceData(viewModel.FormCode);

            var formViewModel = _formMapper.MapFormViewModel(form, formReferenceData);
            formViewModel.Description = "Additional params: " + viewModel.AdditionalParams.ToQueryString();
            formViewModel.LoadUrl = GetActionUrl(viewModel, "load");
            formViewModel.SaveUrl = GetActionUrl(viewModel, "save");
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

        public IEnumerable<FormReferenceData> GetFormReferenceData(string formCode)
        {
            return _repository.GetReferenceData(formCode);
        }

        public FormGeneratorActionResponse Save<SaveFormDataViewModel>(SaveFormDataViewModel viewModel,
            FormDataViewModel dataViewModel)
        {
            throw new NotImplementedException();
        }

        public FormGeneratorActionResponse Submit<SubmitFormDataViewModel>(SubmitFormDataViewModel viewModel, FormDataViewModel dataViewModel)
        {
            throw new NotImplementedException();
        }


        public FormGeneratorActionResponse Cancel<TC>(TC viewModel, FormDataViewModel dataViewModel)
        {
            throw new NotImplementedException();
        }

        public FormGeneratorActionResponse GenericAction<TA>(TA viewModel, FormDataViewModel dataViewModel)
        {
            throw new NotImplementedException();
        }

        private static string GetActionUrl(FormCodeAndAdditionalParametersViewModel viewModel, string action)
        {
            return $"/form/{viewModel.FormCode}/{action}?{viewModel.AdditionalParams.ToQueryString()}";
        }

    }    
}