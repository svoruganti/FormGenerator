namespace FormGenerator.Model
{
    public class FormFieldValidationRule : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int FormFieldId { get; set; }
        public FormField FormField { get; set; }
        public int FormConfigurationId { get; set; }
        public FormConfiguration FormConfiguration { get; set; }
    }
}