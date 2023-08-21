namespace AvaDemo.ViewModels

open AvaDemo.Services
open AvaDemo.Model

type ProductsViewModel() =
  inherit ViewModelBase()
  
  let mutable _products = Unchecked.defaultof<Product list>
  
  
  member x.Products
    with get() = _products
    and set value =
      _products <- value
      x.NotifyPropertyChanged()
      
  member x.GetProductAsync() =
    async {
      try
        let! prodService = ProductService.getProducts()
        for prod in prodService do
          x.Products <-  prod :: _products
      with
      | ex -> printfn "Error: %O" ex
    }