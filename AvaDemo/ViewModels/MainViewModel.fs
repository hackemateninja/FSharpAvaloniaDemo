namespace AvaDemo.ViewModels

open AvaDemo.Command

type MainViewModel() as x =
  inherit ViewModelBase()

  let mutable currentView = Unchecked.defaultof<ViewModelBase>
  
  do currentView <- x.Customers
  
  member x.Customers = CustomersViewModel()
    
  member x.Products = ProductsViewModel()

  member x.ChangeViewCommand = DelegateCommand(x.ChangeView)
  
  member x.CurrentView
    with get() = currentView
    and set value =
      currentView <- value
      x.NotifyPropertyChanged()
      x.ChangeViewCommand.RaiseCanExecuteChanged()
  
  member private x.ChangeView(parameter: obj) =
    x.CurrentView <- parameter :?> ViewModelBase
    