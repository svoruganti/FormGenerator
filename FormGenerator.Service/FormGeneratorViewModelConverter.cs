public class FormGeneratorViewModelConverter : IFormGeneratorViewModelConverte{
  public Dictionary<string, object> ConvertToDictionary<T>(T viewModel){
    IEnumerable<PropertyInfo> properties = typeof (T).GetProperties().Where(x => Attribute.IsDefined(x, typeof(FormGeneratorViewModelPropertyForAttribute))));
    return properties.ToDictionary(
      propertyInfo => propertyInfo.GetCustomAttribute<FormGeneratorViewModelPropertyForAttribute>().PropertyName,
      propertyInfo => propertyInfo.GetValue(viewModel));
  }
  
  public T ConvertToViewModel<T>(Dictionary<string, object> formData) where T: new(){
    var viewModel = new T();
    foreach(var pair in formData){
      PropertyInfo propertyInfo = GetProperty(viewModel, pair.Key);
    }
  }
  
  private PropertyInfo GetProperty(object viewModel, string key){
    var propertyInfo = viewModel.GetType().GetProperties().FirstOrDefault(x => Attribute.IsDefined(x, typeof(FormGeneratorViewModelPropertyForAttribute)) &&
      x.GetCustomAttribute<FormGeneratorViewModelPropertyForAttribute>().propertyName == key);
    
    return propertyInfo;
  }
}
