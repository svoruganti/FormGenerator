using System;
using System.Collections.Generic;

namespace FormGenerator.Model
{
    public class FormConfiguration : Entity
    {
        public Int32 FormId { get; set; }
        public Form Form { get; set; }
        public Int32 FormFieldId { get; set; }
        public FormField FormField { get; set; }
        public Int32 ControlTypeId { get; set; }
        public ControlType ControlType { get; set; }
        public ICollection<FormFieldValidationRule> ValidationRules { get; set; }
        public int Order { get; set; }
    }
}