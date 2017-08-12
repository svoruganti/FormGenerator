using System.Collections.Generic;

namespace FormGenerator.ViewModel
{
    public class SaveFormDataViewModel : FormCodeAndAdditionalParametersViewModel
    {
        public IDictionary<string, object> FormData { get; set; }
    }
}