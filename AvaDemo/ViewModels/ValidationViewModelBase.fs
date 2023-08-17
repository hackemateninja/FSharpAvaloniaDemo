namespace AvaDemo.ViewModels

open System.Collections.Generic
open System.ComponentModel

type ValidationViewModelBase () =
  inherit ViewModelBase()
  
  let errors = Dictionary<string, List<string>>()
  
  let errorsChanged = Event<_, _>()
  
  interface INotifyDataErrorInfo with
    [<CLIEvent>]
    member this.ErrorsChanged = errorsChanged.Publish
    
    member this.GetErrors(propertyName) =
      match errors.TryGetValue(propertyName) with
      | true, errs -> errs
      | _ -> []
      
    member this.HasErrors = errors.Count > 0
    
  member private this.OnErrorsChanged e =
    errorsChanged.Trigger(this, e)
    
  member this.AddError(error: string, propertyName: string) =
    if not (errors.ContainsKey(propertyName)) then
      errors.[propertyName] <- List<string>()
    if not (errors[propertyName].Contains(error)) then
      errors.[propertyName].Add(error)
      this.OnErrorsChanged(DataErrorsChangedEventArgs(propertyName))
      this.NotifyPropertyChanged("HasErrors")
      
  member this.ClearErrors(propertyName: string) =
    if errors.ContainsKey(propertyName) then
      errors.Remove(propertyName) |> ignore
      this.OnErrorsChanged(DataErrorsChangedEventArgs(propertyName))
      this.NotifyPropertyChanged("HasErrors")
      
      

