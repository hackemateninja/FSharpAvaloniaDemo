namespace AvaDemo.ViewModels

open System.Collections.Generic
open System.ComponentModel

type ValidationViewModelBase () =
  inherit ViewModelBase()
  
  let _errors = Dictionary<string, List<string>>()
  
  let _errorsChanged = Event<_, _>()
  
  interface INotifyDataErrorInfo with
    [<CLIEvent>]
    member x.ErrorsChanged = _errorsChanged.Publish
    
    member x.GetErrors(propertyName) =
      match _errors.TryGetValue(propertyName) with
      | true, errs -> errs
      | _ -> []
      
    member x.HasErrors = _errors.Count > 0
    
  member private x.OnErrorsChanged e =
    _errorsChanged.Trigger(x, e)
    
  member x.AddError(error: string, propertyName: string) =
    if not (_errors.ContainsKey(propertyName)) then
      _errors.[propertyName] <- List<string>()
    if not (_errors[propertyName].Contains(error)) then
      _errors.[propertyName].Add(error)
      x.OnErrorsChanged(DataErrorsChangedEventArgs(propertyName))
      x.NotifyPropertyChanged("HasErrors")
      
  member x.ClearErrors(propertyName: string) =
    if _errors.ContainsKey(propertyName) then
      _errors.Remove(propertyName) |> ignore
      x.OnErrorsChanged(DataErrorsChangedEventArgs(propertyName))
      x.NotifyPropertyChanged("HasErrors")
      
      

