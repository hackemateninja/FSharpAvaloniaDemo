namespace AvaDemo.ViewModels

open AvaDemo.Services
open AvaDemo.Model

type ProductsViewModel() =
  inherit ViewModelBase()
  
  let mutable isLoaded = false
  let mutable products = Unchecked.defaultof<Product list>
  
  member x.IsLoaded
    with get() = isLoaded
    and set (value: bool) =
      isLoaded <- value
      x.NotifyPropertyChanged() 
  
  member x.Products
    with get() = products
    and set value =
      products <- value
      x.NotifyPropertyChanged()
      
  member x.GetProductAsync() =
    async {
      try
        x.IsLoaded <- false
        let! prodService = ProductService.getProducts()
        for prod in prodService do
          products <-  prod :: products
        x.IsLoaded <- true
      with
      | ex -> printfn "Error: %O" ex
    }