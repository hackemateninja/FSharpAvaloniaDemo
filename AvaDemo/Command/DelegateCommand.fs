namespace AvaDemo.Command

open System
open System.Windows.Input

type DelegateCommand(execute: obj -> unit, ?canExecute: obj -> bool) as x =
  
  let _execute = execute
  
  let _canExecute = canExecute
  
  let canExecuteChanged = Event<_, _>()
  
  member x.Execute parameter = _execute parameter
  
  member x.CanExecute parameter =
    match _canExecute with
    |Some objectFunc -> objectFunc parameter
    |None -> true
  
  member x.RaiseCanExecuteChanged() =
    canExecuteChanged.Trigger(x, EventArgs.Empty)
      
  interface ICommand with
    [<CLIEvent>]
    
    member x.CanExecuteChanged = canExecuteChanged.Publish
    
    member x.CanExecute parameter = x.CanExecute parameter
    
    member x.Execute parameter = x.Execute parameter



