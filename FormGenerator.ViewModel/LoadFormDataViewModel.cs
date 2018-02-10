using System.Collections.Generic;

namespace FormGenerator.ViewModel
{
    public class LoadFormDataViewModel : FormDataViewModel
    {
    }

    public class SubmitFormDataViewModel : FormDataViewModel
    {
        
    }

    public class NextFormDataViewModel : FormDataViewModel
    {
        
    }

    public class PreviousFormDataViewModel : FormDataViewModel
    {
        
    }

    public class CancelFormDataViewModel : FormDataViewModel
    {
        
    }

    public class GenericActionFormDataViewModel : FormDataViewModel
    {
        
    }

    public class FormDataViewModel : FormCodeAndAdditionalParametersViewModel
    {
        public IDictionary<string, object> FormData { get; set; }
    }
}