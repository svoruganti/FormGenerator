//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//
//public class FormGeneratorViewModel : DefaultModelBinder{
//  public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext){
//      var viewModel =
//          new FormCodeAndAdditionalParametersViewModel
//          {
//              FormCode = controllerContext.RouteData.Values["formCode"].ToString()
//          };
//      var queryStringCollection = controllerContext.HttpContext.Request.Query;
//    if (queryStringCollection.Count == 0) return viewModel;
//
//    var queryStringPair = queryStringCollection.Select(x => new {Key = x.Key.ToLower(), x.Value});
//    foreach(var pair in queryStringPair){
//      if (pair == null || pair.Key == null) continue;
//      viewModel.AdditionalParams.Add(pair.Key, pair.Value);
//    }
//  }
//}
//
//public class FormCodeAndAdditionalParametersViewModel{
//  public FormCodeAndAdditionalParametersViewModel(){
//    AdditionalParams = new Dictionary<string, object>();
//  }
//  public string FormCode { get; set;}
//  public IDictionary <string, object> AdditionalParams { get; set; }
//}
