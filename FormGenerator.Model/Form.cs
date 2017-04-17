using System.Collections.Generic;

namespace FormGenerator.Model
{
    public class Form : Entity
    {
        public virtual string Description { get; set; }
        public virtual string Code { get; set; }
        public virtual ICollection<FormConfiguration> FormConfigurations { get; set; }
        public virtual ICollection<FormFieldBranching> FormFieldBranchings { get; set; }
    }
}