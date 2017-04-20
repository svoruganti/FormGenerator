using System;
public class FormGeneratorViewModelPropertyForAttribute : Attribute{
  public FormGeneratorViewModelPropertyForAttribute(string propertyName){
    PropertyName = propertyName;
  } 
  
  public string PropertyName { get; private set;}
}
