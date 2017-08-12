using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace FormGenerator.Mapper
{
    public class FormGeneratorViewModelMapper : IFormGeneratorViewModelMapper
    {
        public T ConvertToViewModel<T>(T viewModel, IDictionary<string, object> dictionary)
        {
            var json = JsonConvert.SerializeObject(dictionary);
            return JsonConvert.DeserializeAnonymousType(json, viewModel);
        }

        public IDictionary<string, object> ConvertToDictionary(object viewModel)
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
            foreach (var propertyInfo in viewModel.GetType().GetTypeInfo().GetProperties())
            {
                var customPropertyName = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                dictionary.Add(customPropertyName == null ? propertyInfo.Name : customPropertyName.PropertyName,
                    propertyInfo.GetValue(viewModel));
            }
            return dictionary;
        }
    }
}