using System.Net;

namespace FormGenerator.ViewModel
{
    public class FormGeneratorActionResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}