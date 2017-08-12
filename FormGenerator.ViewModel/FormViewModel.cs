using System.Collections.Generic;

namespace FormGenerator.ViewModel
{
    public class FormViewModel : FormCodeAndAdditionalParametersViewModel
    {
        public FormViewModel()
        {
            FormFieldViewModels = new List<FormFieldViewModel>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public IList<FormFieldViewModel> FormFieldViewModels { get; set; }
        public string LoadUrl { get; set; }
        public string SaveUrl { get; set; }
    }
}