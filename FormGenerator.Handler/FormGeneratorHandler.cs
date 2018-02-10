using System;
using System.Linq;
using System.Reflection;
using FormGenerator.Mapper;
using FormGenerator.Service;
using FormGenerator.Service.Interface;
using FormGenerator.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace FormGenerator.Handler
{
    public class FormGeneratorHandler : IFormGeneratorHandler
    {
        private readonly IFormGeneratorService<SaveFormDataViewModel, SubmitFormDataViewModel, CancelFormDataViewModel, GenericActionFormDataViewModel> _formGeneratorService;
        private readonly IFormGeneratorViewModelMapper _formGeneratorViewModelMapper;
        private readonly IServiceProvider _serviceProvider;

        public FormGeneratorHandler(IFormGeneratorService<SaveFormDataViewModel, SubmitFormDataViewModel, CancelFormDataViewModel, GenericActionFormDataViewModel> formGeneratorService, IFormGeneratorViewModelMapper formGeneratorViewModelMapper, IServiceProvider serviceProvider)
        {
            _formGeneratorService = formGeneratorService;
            _formGeneratorViewModelMapper = formGeneratorViewModelMapper;
            _serviceProvider = serviceProvider;
        }

        public FormViewModel GetFormViewModel(FormCodeAndAdditionalParametersViewModel viewModel)
        {
            return GetFormGeneratorService(viewModel.FormCode).GetForm(viewModel);
        }

        public LoadFormDataViewModel GetFormData(FormCodeAndAdditionalParametersViewModel viewModel)
        {
            return GetFormGeneratorService(viewModel.FormCode).GetFormData(viewModel);
        }

        public FormGeneratorActionResponse SaveFormData(SaveFormDataViewModel viewModel)
        {
            var service = GetSpecialisedService(viewModel.FormCode);
            
            //If no specialised service exists for the form then call save method of default service implementation
            if (service == null)
                return _formGeneratorService.Save(viewModel, viewModel);

            //Check custom mapper
            var customMapper = GetSpecialisedMapper(viewModel.FormCode);
            
            //If custom mapper exists then use it to convert submitted form data to appropriate view model
            if (customMapper != null)
            {
                var vm = customMapper.MapToSaveViewModel(viewModel);
                return service.Save(vm, viewModel);
            }
            
            //If no custom mapper exists then use default form generator view model converter
            var saveMethodInfo = service.GetType().GetTypeInfo().GetMethod("Save");
            
            if (saveMethodInfo == null)
                throw new MissingMethodException($"Save method is not found in {service.GetType().FullNmae}");
       
            ParameterInfo saveViewModelParameterInfo = saveMethodInfo.GetParameters()[0];
            
            //If the passed in view model is of type SaveFormDataViewModel, no conversion is required
            if (saveViewModelParameterInfo.ParameterType == typeof(SaveFormDataViewModel))
                return service.Save(viewModel, viewModel);
            
            //If the passed in view model is not of type SaveFormDataViewModel
            var v = _formGeneratorViewModelMapper.ConvertToViewModel(Activator.CreateInstance(saveViewModelParameterInfo.ParameterType),
                viewModel.FormData);
            return service.Save(v, viewModel);

        }

        private dynamic GetFormGeneratorService(string formCode)
        {
            var service = GetSpecialisedService(formCode);
            return service ?? _formGeneratorService;
        }

        private dynamic GetSpecialisedService(string formCode)
        {
            var services = _serviceProvider.GetServices(typeof(IFormGeneratorService<,,,>));
            var service = services.FirstOrDefault(x =>
                x.GetType().GetTypeInfo().GetCustomAttribute<FormGeneratorServiceForAttribute>() != null &&
                x.GetType().GetTypeInfo().GetCustomAttribute<FormGeneratorServiceForAttribute>().FormCode
                    .Equals(formCode, StringComparison.CurrentCultureIgnoreCase));
            return service;
        }

        private dynamic GetSpecialisedMapper(string formCode)
        {
            var mappers = _serviceProvider.GetServices(typeof(IFormGeneratorMapper<>));
            var mapper = mappers.FirstOrDefault(x =>
                x.GetType().GetTypeInfo().GetCustomAttribute<FormGeneratorMapperForAttribute>() != null &&
                x.GetType().GetTypeInfo().GetCustomAttribute<FormGeneratorMapperForAttribute>().FormCode
                    .Equals(formCode, StringComparison.CurrentCultureIgnoreCase));
            return mapper;
        }
    }
}