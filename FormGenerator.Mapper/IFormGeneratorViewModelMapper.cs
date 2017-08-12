using System.Collections.Generic;

namespace FormGenerator.Mapper
{
    public interface IFormGeneratorViewModelMapper
    {
        T ConvertToViewModel<T>(T viewModel, IDictionary<string, object> dictionary);
        IDictionary<string, object> ConvertToDictionary(object viewModel);
    }
}