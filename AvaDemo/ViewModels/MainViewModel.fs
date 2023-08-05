namespace AvaDemo.ViewModels

open AvaDemo.Command

type MainViewModel() as x =
  inherit ViewModelBase()

  let mutable currentView = Unchecked.defaultof<ViewModelBase>
  
  let customers = CustomersViewModel()
  
  let products = ProductsViewModel()
  
  do currentView <- customers

  member x.ChangeViewCommand = DelegateCommand(x.ChangeView)
  
  member x.CurrentView
    with get() = currentView
    and set value =
      currentView <- value
      x.NotifyPropertyChanged()
      x.ChangeViewCommand.RaiseCanExecuteChanged()
  
  member private x.ChangeView(_parameter: obj) =
    if x.CurrentView = customers then x.CurrentView <- products else x.CurrentView <- customers
  