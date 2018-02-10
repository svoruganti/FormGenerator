using System.Collections.Generic;
using FormGenerator.Model;
using FormGenerator.ViewModel;

namespace FormGenerator.Service.Interface
{
    public interface IFormGeneratorService<in Tsa, in Tsu, in TC, in Tga>
    {
        FormViewModel GetForm(FormCodeAndAdditionalParametersViewModel viewModel);
        LoadFormDataViewModel GetFormData(FormCodeAndAdditionalParametersViewModel viewModel);
        IEnumerable<FormReferenceData> GetFormReferenceData(string formCode);

        FormGeneratorActionResponse Save<Tsa>(Tsa viewModel, FormDataViewModel dataViewModel);

        FormGeneratorActionResponse Submit<Tsu>(Tsu viewModel, FormDataViewModel dataViewModel);

        FormGeneratorActionResponse Cancel<TC>(TC viewModel, FormDataViewModel dataViewModel);

        FormGeneratorActionResponse GenericAction<TA>(TA viewModel, FormDataViewModel dataViewModel);
    }
}