using System;
using System.Collections.Generic;

namespace FormGenerator.ViewModel
{
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
}