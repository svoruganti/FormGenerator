using FormGenerator.ViewModel;

namespace FormGenerator.Handler
{
    public interface IFormGeneratorHandler
    {
        FormViewModel GetFormViewModel(FormCodeAndAdditionalParametersViewModel viewModel);
        LoadFormDataViewModel GetFormData(FormCodeAndAdditionalParametersViewModel viewModel);
        FormGeneratorActionResponse SaveFormData(SaveFormDataViewModel viewModel);
    }
}