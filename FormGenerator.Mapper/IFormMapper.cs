using System.Collections.Generic;
using FormGenerator.Model;
using FormGenerator.ViewModel;

namespace FormGenerator.Mapper
{
    public interface IFormMapper
    {
        FormViewModel MapFormViewModel(Form form, IEnumerable<FormReferenceData> formReferenceData);
    }
}