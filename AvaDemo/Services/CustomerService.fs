namespace AvaDemo.Services

open AvaDemo.Model

module CustomerService =
  let getCustomers () =
    async{
 
      return [
        Customer("1", "John", "Doe", true)
        Customer("2", "Jane", "Doe", false)
        Customer("3", "Jake", "Doe", true)
        Customer("4", "Juan", "Doe", false)
        Customer("5", "Maria", "Doe", true)
      ]
    }
    