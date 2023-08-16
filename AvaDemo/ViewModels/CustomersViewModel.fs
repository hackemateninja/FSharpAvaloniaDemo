namespace AvaDemo.ViewModels

open AvaDemo.Command
open AvaDemo.ViewModels
open AvaDemo.Model
open AvaDemo.Services

type CustomersViewModel() =
  inherit ViewModelBase()
  
  let defaultCustomer = Unchecked.defaultof<CustomerItemViewModel>
  
  let mutable isLoaded = false
  
  let mutable customers = Unchecked.defaultof<CustomerItemViewModel list>
  
  let mutable selectedCustomer = defaultCustomer
  
  let mutable columnNumber = 0
  
  member x.AddCommand = DelegateCommand x.AddCustomer
  
  member x.MovePanelCommand = DelegateCommand x.MovePanel
  
  member x.DeleteCommand = DelegateCommand(x.DeleteCustomer, x.CanDeleteCustomer)
  
  member x.IsVisibleDetails = x.SelectedCustomer <> defaultCustomer
  
  member x.IsCustomersLoaded = false
  
  member x.Customers
    with get() = customers
    and set value = 
    customers <- value
    x.NotifyPropertyChanged()
    x.AddCommand.RaiseCanExecuteChanged()

  member x.SelectedCustomer
    with get() = selectedCustomer
    and set value = 
    selectedCustomer <- value
    x.NotifyPropertyChanged()
    x.DeleteCommand.RaiseCanExecuteChanged()

  member x.ColumnNumber
    with get() = columnNumber
    and set value = 
      columnNumber <- value
      x.NotifyPropertyChanged()
      x.MovePanelCommand.RaiseCanExecuteChanged()
      
  member x.IsLoaded
    with get() = isLoaded
    and set value=
      isLoaded <- value
      x.NotifyPropertyChanged()
          
  member x.GetCustomersAsync() =
    async {
      try
        x.IsLoaded <- false
        let! customersService = CustomerService.getCustomers()
        for customer in customersService do
          customers <- CustomerItemViewModel(customer) :: customers
        x.IsLoaded <- true
      with
      | ex -> printfn "Error: %O" ex
    }
    
  member private x.AddCustomer(__parameter: obj) =
    let newCustomer = CustomerItemViewModel(Customer("", "New", "", true))
    x.Customers  <- newCustomer :: customers
    x.SelectedCustomer <- newCustomer

  member private x.DeleteCustomer(_parameter: obj) =
    x.Customers <- x.Customers|>List.filter(fun x-> x <> selectedCustomer)
    x.SelectedCustomer <- defaultCustomer
    
  member private x.CanDeleteCustomer(_parameter: obj) =
    x.IsVisibleDetails
    
  member private x.MovePanel(_parameter: obj) =
    if x.ColumnNumber = 0 then x.ColumnNumber <- 2 else x.ColumnNumber <- 0
    
    


  