//using System.Collections.Generic;
//using System.Linq;
//using CustomAttributeExtensions = System.Reflection.CustomAttributeExtensions;
//using PropertyInfo = System.Reflection.PropertyInfo;
//using TypeExtensions = System.Reflection.TypeExtensions;
//
//public class FormGeneratorViewModelConverter : IFormGeneratorViewModelConverter
//{
//    public Dictionary<string, object> ConvertToDictionary<T>(T viewModel)
//    {
//        IEnumerable<PropertyInfo> properties = TypeExtensions.GetProperties(typeof(T))
//            .Where(x => x.IsDefined(typeof(FormGeneratorViewModelPropertyForAttribute)));
//        return properties.ToDictionary(
//            propertyInfo => CustomAttributeExtensions.GetCustomAttribute<FormGeneratorViewModelPropertyForAttribute>(propertyInfo).PropertyName,
//            propertyInfo => propertyInfo.GetValue(viewModel));
//    }
//
//    public T ConvertToViewModel<T>(IDictionary<string, object> formData) where T : new()
//    {
//        var viewModel = new T();
//        foreach (var pair in formData)
//        {
//            PropertyInfo propertyInfo = GetProperty(viewModel, pair.Key);
//        }
//    }
//
//    private PropertyInfo GetProperty(object viewModel, string key)
//    {
//        var propertyInfo = TypeExtensions.GetProperties(viewModel.GetType())
//            .FirstOrDefault(x => x.IsDefined(x, typeof(FormGeneratorViewModelPropertyForAttribute)) &&
//                                 CustomAttributeExtensions.GetCustomAttribute<FormGeneratorViewModelPropertyForAttribute>(x).PropertyName ==
//                                 key);
//
//        return propertyInfo;
//    }
//}