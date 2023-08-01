namespace AvaDemo.Services

open AvaDemo.Model

module CustomerService =
  let getCustomers () =
    async{
      do! Async.Sleep 500
      
      return [
        Customer("1", "John", "Doe", true)
        Customer("2", "HErman", "Doe", false)
        Customer("3", "Orlando", "Doe", true)
        Customer("4", "Manuel", "Doe", false)
        Customer("5", "Baduel", "Doe", true)
      ]
    }
    