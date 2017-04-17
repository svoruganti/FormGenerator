namespace FormGenerator.Model
{
    public class FormReferenceData : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string TableName { get; set; }
        public string WhereClause { get; set; }
        public int FormFieldId { get; set; }
    }
}