using System;

namespace FormGenerator.Mapper
{
    public class FormGeneratorMapperForAttribute : Attribute
    {
        public string FormCode { get; }

        public FormGeneratorMapperForAttribute(string formCode)
        {
            FormCode = formCode;
        }
    }
}