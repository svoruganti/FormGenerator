namespace FormGenerator.Model
{
    public class FormFieldBranching : Entity
    {
        public virtual int ChildFieldId { get; set; }
        public virtual int ParentFieldId { get; set; }
        public virtual int FormId { get; set; }
        public virtual FormField ChildField { get; set; }
        public virtual FormField ParentField { get; set; }
        public virtual Form Form { get; set; }
        public virtual string BranchingValue { get; set; }
    }
}