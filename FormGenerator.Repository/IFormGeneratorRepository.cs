using System.Collections.Generic;
using FormGenerator.Model;

namespace FormGenerator.Repository
{
    public interface IFormGeneratorRepository
    {
        Form GetForm(string formCode);
        IEnumerable<FormReferenceData> GetReferenceData(string formCode);
    }
}