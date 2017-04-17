using FormGenerator.ViewModel;

namespace FormGenerator.Handler
{
    public interface IFormGeneratorHandler
    {
        FormViewModel GetFormViewModel(string formCode);
    }
}