namespace AvaDemo.ViewModels

open System.ComponentModel

type ViewModelBase()  =
  let propertyChanged = Event<_, _>()
  
  interface INotifyPropertyChanged with
    [<CLIEvent>]
    member this.PropertyChanged = propertyChanged.Publish
  
    
  member this.NotifyPropertyChanged(propertyName : string) =
    propertyChanged.Trigger(this, PropertyChangedEventArgs(propertyName))


  
      