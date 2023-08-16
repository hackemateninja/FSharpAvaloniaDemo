namespace AvaDemo.Services

open AvaDemo.Model

module ProductService =
  let getProducts () =
    async{      
      return [
        Product("001", "Product 1", "A fantastic product with amazing features.")
        Product("002", "Product 2", "An innovative solution for your needs.")
        Product("003", "Product 3", "The perfect choice to enhance your experience.")
        Product("004", "Product 4", "Unleash the power of this cutting-edge product.")
        Product("005", "Product 5", "Elevate your productivity with this product.")
        Product("006", "Product 6", "Experience a new level of performance.")
        Product("007", "Product 7", "A reliable companion for your tasks.")
        Product("008", "Product 8", "Stay ahead with this advanced product.")
        Product("009", "Product 9", "Transform your workflow with this tool.")
        Product("010", "Product 10", "Efficiency meets style in this product.")
      ]
    }
    