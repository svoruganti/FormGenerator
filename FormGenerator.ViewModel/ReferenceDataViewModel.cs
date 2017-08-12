using System;

namespace FormGenerator.ViewModel
{
    public class ReferenceDataViewModel
    {
        public Int32 Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string TableName { get; set; }
        public string WhereClause { get; set; }
    }
}