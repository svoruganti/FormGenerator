using System.Collections.Generic;
using System.Linq;
using FormGenerator.Model;
using Microsoft.EntityFrameworkCore;

namespace FormGenerator.Repository
{
    public class FormGeneratorRepository : IFormGeneratorRepository
    {
        private readonly FormGeneratorDbContext _context;

        public FormGeneratorRepository(FormGeneratorDbContext context)
        {
            _context = context;
        }
        public Form GetForm(string formCode)
        {
            var form = _context.Set<Form>().AsNoTracking()
                .Include(x => x.FormConfigurations)
                .Include(x => x.FormConfigurations).ThenInclude(x => x.ControlType)
                .Include(x => x.FormConfigurations).ThenInclude(x => x.FormField)
                .Include(x => x.FormFieldBranchings).ThenInclude(x => x.ParentField)
                .FirstOrDefault(x => x.Code == formCode);
            return form;

        }

        public IEnumerable<FormReferenceData> GetReferenceData(string formCode)
        {
            return _context.Set<FormReferenceData>().FromSql($"call spGetFormReferenceData ('{formCode}')").ToList();
        }
    }
}