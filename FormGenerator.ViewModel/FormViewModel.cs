using System;
using System.Collections.Generic;

namespace FormGenerator.ViewModel
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            FormFieldViewModels = new List<FormFieldViewModel>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public IList<FormFieldViewModel> FormFieldViewModels { get; set; }
        public string Parent { get; set; }
    }

    public class FormFieldViewModel
    {
        public FormFieldViewModel()
        {
            ReferenceDataViewModels = new List<ReferenceDataViewModel>();
            ParentForBranching = new List<FormFieldBrachingViewModel>();
        }

        public Int32 Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string ControlType { get; set; }
        public int Columns { get; set; }
        public IEnumerable<ReferenceDataViewModel> ReferenceDataViewModels { get; set; }
        public IEnumerable<FormFieldBrachingViewModel> ParentForBranching { get; set; }
        public int Order { get; set; }
    }

    public class FormFieldBrachingViewModel
    {
        public Int32 Id { get; set; }
        public string ParentCode { get; set; }
        public string BranchingValue { get; set; }
    }


    public class ReferenceDataViewModel
    {
        public Int32 Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string TableName { get; set; }
        public string WhereClause { get; set; }
    }
}