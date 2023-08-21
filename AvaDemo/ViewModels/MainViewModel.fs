namespace AvaDemo.ViewModels

open AvaDemo.Command

type MainViewModel() as x =
  inherit ViewModelBase()

  let mutable _currentView = Unchecked.defaultof<ViewModelBase>
  
  do _currentView <- x.Customers
  
  member x.Customers = CustomersViewModel()
    
  member x.Products = ProductsViewModel()

  member x.ChangeViewCommand = DelegateCommand(x.ChangeView)
  
  member x.CurrentView
    with get() = _currentView
    and set value =
      _currentView <- value
      x.NotifyPropertyChanged()
      x.ChangeViewCommand.RaiseCanExecuteChanged()
  
  member private x.ChangeView(parameter: obj) =
    x.CurrentView <- parameter :?> ViewModelBase
    