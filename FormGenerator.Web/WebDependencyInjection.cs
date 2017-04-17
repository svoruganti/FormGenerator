using Microsoft.Extensions.DependencyInjection;

namespace FormGenerator.Web
{
    public class WebDependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddAntiforgery(x =>
            {
                x.HeaderName = "__RequestionValidationHeader";
            });
        }
    }
}