namespace AvaDemo.ViewModels

open System.Collections.Generic
open System.ComponentModel

type ValidationViewModelBase () =
  inherit ViewModelBase()
  
  let errors = Dictionary<string, List<string>>()
  
  let errorsChanged = Event<_, _>()
  
  interface INotifyDataErrorInfo with
    [<CLIEvent>]
    member x.ErrorsChanged = errorsChanged.Publish
    
    member x.GetErrors(propertyName) =
      match errors.TryGetValue(propertyName) with
      | true, errs -> errs
      | _ -> []
      
    member x.HasErrors = errors.Count > 0
    
  member private x.OnErrorsChanged e =
    errorsChanged.Trigger(x, e)
    
  member x.AddError(error: string, propertyName: string) =
    if not (errors.ContainsKey(propertyName)) then
      errors.[propertyName] <- List<string>()
    if not (errors[propertyName].Contains(error)) then
      errors.[propertyName].Add(error)
      x.OnErrorsChanged(DataErrorsChangedEventArgs(propertyName))
      x.NotifyPropertyChanged("HasErrors")
      
  member x.ClearErrors(propertyName: string) =
    if errors.ContainsKey(propertyName) then
      errors.Remove(propertyName) |> ignore
      x.OnErrorsChanged(DataErrorsChangedEventArgs(propertyName))
      x.NotifyPropertyChanged("HasErrors")
      
      

