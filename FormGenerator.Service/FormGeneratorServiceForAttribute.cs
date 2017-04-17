using System;

namespace FormGenerator.Service
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FormGeneratorServiceForAttribute : Attribute
    {
        public string FormCode { get; }

        public FormGeneratorServiceForAttribute(string formCode)
        {
            FormCode = formCode;
        }
    }
}