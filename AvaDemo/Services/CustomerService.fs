﻿namespace AvaDemo.Services

open AvaDemo.Model

module CustomerService =
  let getCustomers () =
    async{
      do! Async.Sleep 500
      
      return [
        { Id = "1"; FirstName = "John"; LastName = "Doe"; IsNew = true }
        { Id = "2"; FirstName = "Jane"; LastName = "Smith"; IsNew = false }
        { Id = "3"; FirstName = "Michael"; LastName = "Johnson"; IsNew = true }
      ]
    }
    