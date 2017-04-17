using System.Collections.Generic;
using FormGenerator.Model;
using FormGenerator.Repository;
using FormGenerator.Service.Interface;

namespace FormGenerator.Service
{
    public class FormGeneratorService : IFormGeneratorService
    {
        private readonly IFormGeneratorRepository _repository;

        public FormGeneratorService(IFormGeneratorRepository repository)
        {
            _repository = repository;
        }
        public Form GetFormData(string formCode)
        {
            return _repository.GetForm(formCode);
        }

        public IEnumerable<FormReferenceData> GetFormReferenceData(string formCode)
        {
            return _repository.GetReferenceData(formCode);
        }
    }
}