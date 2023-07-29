namespace AvaDemo.ViewModels

open AvaDemo.ViewModels
open AvaDemo.Model
open AvaDemo.Services
open Microsoft.FSharp.Control

type CustomersViewModel() =
  inherit ViewModelBase()
  let mutable customers = Unchecked.defaultof<Customer list>
  let mutable selectedCustomer = Unchecked.defaultof<Customer>
  
  let getCustomersAsync() =
    async {
      try
        let! customersService = CustomerService.getCustomers()
        customers <- customersService
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
    
  member x.AddCustomer() =
    let newCustomer = {Id = ""; FirstName = "New"; LastName = "" ; IsNew = true }
    x.Customers  <- newCustomer :: customers
    x.SelectedCustomer <- newCustomer


  