using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormGenerator.ViewModel
{
    public class FormGeneratorViewModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var viewModel = new FormCodeAndAdditionalParametersViewModel
            {
                FormCode = bindingContext.ActionContext.RouteData.Values["formCode"].ToString()
            };

            var queryStringCollection = bindingContext.HttpContext.Request.Query;
            if (queryStringCollection.Count > 0)
            {
                var queryStringPair = queryStringCollection.Select(x => new {Key = x.Key.ToLower(), x.Value});
                foreach (var pair in queryStringPair)
                {
                    if (pair == null || pair.Key == null) continue;
                    viewModel.AdditionalParams.Add(pair.Key, pair.Value);
                }
            }

            bindingContext.Result = ModelBindingResult.Success(viewModel);
            return Task.CompletedTask;
        }
    }

    public class FormGeneratorViewModelModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ContainerType != null && context.Metadata.ContainerType.IsAssignableFrom(typeof(FormCodeAndAdditionalParametersViewModel)))
            {
                return new FormGeneratorViewModelBinder();
            }
            return null;
        }
    }
}