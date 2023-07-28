namespace AvaDemo.ViewModels

open AvaDemo.ViewModels
open System.Collections.ObjectModel
open AvaDemo.Model
open AvaDemo.Services

type CustomersViewModel() as x =
  inherit ViewModelBase()

  let mutable customers = []

  do
    customers <- CustomerService.getCustomers()

  member x.Customers
    with get() = customers