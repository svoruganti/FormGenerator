using System.Collections.Generic;

namespace FormGenerator.ViewModel
{
    public class LoadFormDataViewModel : FormCodeAndAdditionalParametersViewModel
    {
        public IDictionary<string, object> FormData { get; set; }
    }
}