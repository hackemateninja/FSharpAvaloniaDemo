namespace AvaDemo.ViewModels

open System.ComponentModel

type ViewModelBase()  =
  let propertyChanged = Event<_, _>()
  
  interface INotifyPropertyChanged with
    [<CLIEvent>]
    member x.PropertyChanged = propertyChanged.Publish
    
  member x.NotifyPropertyChanged(?propertyName : string) =
    let name = defaultArg propertyName "" 
    propertyChanged.Trigger(x, PropertyChangedEventArgs(name))


  
      