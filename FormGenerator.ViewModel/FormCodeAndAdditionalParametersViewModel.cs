using System.Collections.Generic;

namespace FormGenerator.ViewModel
{
    public class FormCodeAndAdditionalParametersViewModel{
        public FormCodeAndAdditionalParametersViewModel(){
            AdditionalParams = new Dictionary<string, string>();
        }
        public string FormCode { get; set;}
        public IDictionary <string, string> AdditionalParams { get; set; }
    }
}