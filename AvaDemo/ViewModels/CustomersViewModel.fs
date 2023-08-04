namespace AvaDemo.ViewModels

open AvaDemo.Command
open AvaDemo.ViewModels
open AvaDemo.Model
open AvaDemo.Services
open ViewModels.CustomerItemViewModel

type CustomersViewModel() =
  inherit ViewModelBase()
  
  let mutable customers = Unchecked.defaultof<CustomerItemViewModel list>
  
  let mutable selectedCustomer = Unchecked.defaultof<CustomerItemViewModel>
  
  let mutable columnNumber = 0
  
  member x.AddCommand = DelegateCommand x.AddCustomer
  
  member x.MovePanelCommand = DelegateCommand x.MovePanel
  
  member x.DeleteCommand = DelegateCommand(x.DeleteCustomer, x.CanDeleteCustomer)
  
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
      
  member x.GetCustomersAsync() =
    async {
      try
        let! customersService = CustomerService.getCustomers()
        for customer in customersService do
          customers <- CustomerItemViewModel(customer) :: customers
      with
      | ex -> printfn "Error: %O" ex
    }
    
  member private x.AddCustomer(parameter: obj) =
    let newCustomer = CustomerItemViewModel(Customer("", "New", "", true))
    x.SelectedCustomer <- newCustomer
    x.Customers  <- newCustomer :: customers    

  member private x.DeleteCustomer(parameter: obj) =
    x.Customers <- x.Customers|>List.filter(fun x-> x <> selectedCustomer)
    x.SelectedCustomer <- Unchecked.defaultof<CustomerItemViewModel>
    
  member private x.CanDeleteCustomer(parameter: obj) =
    x.SelectedCustomer <> Unchecked.defaultof<CustomerItemViewModel> 
    
  member private x.MovePanel(parameter: obj) =
    if x.ColumnNumber = 0 then x.ColumnNumber <- 2 else x.ColumnNumber <- 0
    
    


  