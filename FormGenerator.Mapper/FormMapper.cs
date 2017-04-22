using System;
using System.Collections.Generic;
using System.Linq;
using FormGenerator.Model;
using FormGenerator.ViewModel;

namespace FormGenerator.Mapper
{
    public class FormMapper : IFormMapper
    {
        public FormViewModel MapFormViewModel(Form form, IEnumerable<FormReferenceData> formReferenceData)
        {
            var viewModel = new FormViewModel
            {
                Id = form.Id,
                Code = form.Code,
                Description = form.Description,
                LoadUrl = $"/form/{form.Code}/load",
                SaveUrl = $"/form/{form.Code}/save"
            };

            foreach (var formConfiguration in form.FormConfigurations)
            {
                viewModel.FormFieldViewModels.Add(GetFormFieldViewModel(formConfiguration, formReferenceData, form));
            }
            return viewModel;
        }

        private static FormFieldViewModel GetFormFieldViewModel(FormConfiguration formConfiguration,
            IEnumerable<FormReferenceData> formReferenceData, Form form)
        {
            return new FormFieldViewModel
            {
                Code = formConfiguration.FormField.Code,
                ControlType = formConfiguration.ControlType.Code,
                Id = formConfiguration.FormFieldId,
                Label = formConfiguration.FormField.Label,
                Columns = 12,
                Order = formConfiguration.Order,
                ParentForBranching = GetBranchingViewModels(formConfiguration.FormFieldId, form),
                ReferenceDataViewModels =
                    GetFormFieldReferenceDataViewModels(formConfiguration.FormFieldId, formReferenceData)
            };
        }

        private static IEnumerable<FormFieldBrachingViewModel> GetBranchingViewModels(int formConfigurationFormFieldId,
            Form form)
        {
            return form.FormFieldBranchings.Where(x => x.ChildFieldId == formConfigurationFormFieldId)
                .Select(x => new FormFieldBrachingViewModel {Id = x.Id, ParentCode = x.ParentField.Code, BranchingValue = x.BranchingValue})
                .ToList();
        }

        private static IEnumerable<ReferenceDataViewModel> GetFormFieldReferenceDataViewModels(
            Int32 formConfigurationFormFieldId, IEnumerable<FormReferenceData> formReferenceData)
        {
            var referenData = formReferenceData.Where(x => x.FormFieldId == formConfigurationFormFieldId)
                .Select(x => new ReferenceDataViewModel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                    TableName = x.TableName,
                    WhereClause = x.WhereClause
                });
            return referenData;
        }
    }
}