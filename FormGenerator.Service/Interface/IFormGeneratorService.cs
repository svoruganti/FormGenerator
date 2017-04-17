using System.Collections.Generic;
using FormGenerator.Model;

namespace FormGenerator.Service.Interface
{
    public interface IFormGeneratorService
    {
        Form GetFormData(string formCode);
        IEnumerable<FormReferenceData> GetFormReferenceData(string formCode);
    }
}