namespace AvaDemo.ViewModels

type MainViewModel() =
  inherit ViewModelBase()

  let currentView: ViewModelBase = ViewModelBase()

  member x.Greeting = "Welcome to Avalonia!"
