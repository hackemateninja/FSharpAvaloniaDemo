namespace AvaDemo.ViewModels

open AvaDemo.Command
open AvaDemo.ViewModels
open AvaDemo.Model
open AvaDemo.Services

type CustomersViewModel() =
  inherit ViewModelBase()
  
  let _defaultCustomer = Unchecked.defaultof<CustomerItemViewModel>
  
  let mutable _customers = Unchecked.defaultof<CustomerItemViewModel list>
  
  let mutable _selectedCustomer = _defaultCustomer
 
  let mutable _columnNumber = 0
  
  member x.AddCommand = DelegateCommand x.AddCustomer
  
  member x.MovePanelCommand = DelegateCommand x.MovePanel
  
  member x.DeleteCommand = DelegateCommand(x.DeleteCustomer, x.CanDeleteCustomer)
  
  member x.IsVisibleDetails = x.SelectedCustomer <> _defaultCustomer
  
  member x.Customers
    with get() = _customers
    and set value = 
    _customers <- value
    x.NotifyPropertyChanged()
    x.AddCommand.RaiseCanExecuteChanged()

  member x.SelectedCustomer
    with get() = _selectedCustomer
    and set value = 
    _selectedCustomer <- value
    x.NotifyPropertyChanged()
    x.DeleteCommand.RaiseCanExecuteChanged()

  member x.ColumnNumber
    with get() = _columnNumber
    and set value = 
      _columnNumber <- value
      x.NotifyPropertyChanged()
      x.MovePanelCommand.RaiseCanExecuteChanged()
          
  member x.GetCustomersAsync() =
    async {
      try
        let! _customersService = CustomerService.getCustomers()
        for customer in _customersService do
          x.Customers <- CustomerItemViewModel(customer) :: _customers
      with
      | ex -> printfn "Error: %O" ex
    }
    
  member private x.AddCustomer(__parameter: obj) =
    let newCustomer = CustomerItemViewModel(Customer("", "New", "", true))
    x.Customers  <- newCustomer :: _customers
    x.SelectedCustomer <- newCustomer

  member private x.DeleteCustomer(_parameter: obj) =
    x.Customers <- x.Customers|>List.filter(fun x-> x <> _selectedCustomer)
    x.SelectedCustomer <- _defaultCustomer
    
  member private x.CanDeleteCustomer(_parameter: obj) =
    x.IsVisibleDetails
    
  member private x.MovePanel(_parameter: obj) =
    if x.ColumnNumber = 0 then x.ColumnNumber <- 2 else x.ColumnNumber <- 0
    
    


  