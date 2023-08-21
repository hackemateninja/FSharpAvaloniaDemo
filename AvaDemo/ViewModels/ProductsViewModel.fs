namespace AvaDemo.ViewModels

open AvaDemo.Services
open AvaDemo.Model

type ProductsViewModel() =
  inherit ViewModelBase()
  
  let mutable products = Unchecked.defaultof<Product list>
  
  
  member x.Products
    with get() = products
    and set value =
      products <- value
      x.NotifyPropertyChanged()
      
  member x.GetProductAsync() =
    async {
      try
        let! prodService = ProductService.getProducts()
        for prod in prodService do
          x.Products <-  prod :: products
      with
      | ex -> printfn "Error: %O" ex
    }