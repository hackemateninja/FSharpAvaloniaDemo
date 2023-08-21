namespace AvaDemo.ViewModels

open System.ComponentModel

type ViewModelBase()  =
  let _propertyChanged = Event<_, _>()
  
  interface INotifyPropertyChanged with
    [<CLIEvent>]
    member x.PropertyChanged = _propertyChanged.Publish
    
  member x.NotifyPropertyChanged(?propertyName : string) =
    let name = defaultArg propertyName "" 
    _propertyChanged.Trigger(x, PropertyChangedEventArgs(name))


  
      