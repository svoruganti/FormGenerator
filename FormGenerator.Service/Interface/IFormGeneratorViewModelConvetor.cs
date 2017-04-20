public interface IFormGeneratorViewModelConverter{
  Dictionary<string, object> ConvertToDictionary<T>(T viewModel);
  T ConvertToViewModel<T>(IDictionary<string, object> formData) where T:new();
}
