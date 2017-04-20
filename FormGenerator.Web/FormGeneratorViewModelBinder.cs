//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//
//public class FormGeneratorViewModel : DefaultModelBinder{
//  public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext){
//    var viewModel = new FormCodeAndAddionalParametersViewModel();
//    viewModel.FormCode = controllerContext.RouteData.Values["formCode"].ToString();
//    var queryStringCollection = controllerContext.HttpContext.Request.QueryString;
//    if (queryStringCollection.Count == 0) return viewModel;
//
//    var queryStringPair = queryStringCollection.AllKeys.SelectMany(queryStringCollection.GetValues, (k, v) => new {Key = k.ToLower(), Value = v});
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
