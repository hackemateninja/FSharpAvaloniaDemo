namespace AvaDemo.ViewModels

open AvaDemo.ViewModels
open AvaDemo.Model
open AvaDemo.Services
open Microsoft.FSharp.Control
open ViewModels.CustomerItemViewModel

type CustomersViewModel() =
  inherit ViewModelBase()
  let mutable customers = Unchecked.defaultof<CustomerItemViewModel list>
  let mutable selectedCustomer = Unchecked.defaultof<CustomerItemViewModel>
  let mutable columnNumber = 0
  
  let getCustomersAsync() =
    async {
      try
        let! customersService = CustomerService.getCustomers()
        for customer in customersService do
          customers <- CustomerItemViewModel(customer) :: customers
      with
      | ex -> printfn "Error: %O" ex
    }|>Async.RunSynchronously
    
    
  do
    getCustomersAsync()
  
  member x.Customers
    with get() = customers
    and set value = 
    customers <- value
    x.NotifyPropertyChanged(nameof(x.Customers))

  member x.SelectedCustomer
    with get() = selectedCustomer
    and set value = 
    selectedCustomer <-value
    x.NotifyPropertyChanged(nameof(x.SelectedCustomer))

  member x.ColumnNumber
    with get() = columnNumber
    and set value = 
      columnNumber <- value
      x.NotifyPropertyChanged(nameof(x.ColumnNumber))

  member x.AddCustomer() =
    let newCustomer = CustomerItemViewModel(Customer("", "New", "", true))
    x.Customers  <- newCustomer :: customers
    x.SelectedCustomer <- newCustomer

  member x.DeleteCustomer() =
    x.Customers <- x.Customers|>List.filter(fun x-> x <> selectedCustomer)
   

  member x.MovePanel() =
    if x.ColumnNumber = 0 then x.ColumnNumber <- 2 else x.ColumnNumber <- 0
    


  