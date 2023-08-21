namespace AvaDemo.Command

open System
open System.Windows.Input

type DelegateCommand(execute: obj -> unit, ?canExecute: obj -> bool) as x =
  
  let _execute = execute
  
  let _canExecute = canExecute
  
  let _canExecuteChanged = Event<_, _>()
  
  member x.Execute parameter = _execute parameter
  
  member x.CanExecute parameter =
    match _canExecute with
    |Some objectFunc -> objectFunc parameter
    |None -> true
  
  member x.RaiseCanExecuteChanged() =
    _canExecuteChanged.Trigger(x, EventArgs.Empty)
      
  interface ICommand with
    [<CLIEvent>]
    
    member x.CanExecuteChanged = _canExecuteChanged.Publish
    
    member x.CanExecute parameter = x.CanExecute parameter
    
    member x.Execute parameter = x.Execute parameter



