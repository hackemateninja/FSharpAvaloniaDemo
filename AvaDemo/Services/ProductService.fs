namespace AvaDemo.Services

open AvaDemo.Model

module ProductService =
  let getProducts () =
    async{
      do! Async.Sleep(3000)
      return [
        { Id = "001"; Name = "Customer 1"; Description = "A loyal customer with great feedback." }
        { Id = "002"; Name = "Customer 2"; Description = "A valued customer who appreciates quality." }
        { Id = "003"; Name = "Customer 3"; Description = "An enthusiastic customer who loves our products." }
        { Id = "004"; Name = "Customer 4"; Description = "A satisfied customer who recommends us to others." }
        { Id = "005"; Name = "Customer 5"; Description = "A repeat customer who trusts our services." }
        { Id = "006"; Name = "Customer 6"; Description = "A dedicated customer who enjoys our offers." }
        { Id = "007"; Name = "Customer 7"; Description = "A supportive customer who engages with us." }
        { Id = "008"; Name = "Customer 8"; Description = "An engaged customer who provides valuable feedback." }
        { Id = "009"; Name = "Customer 9"; Description = "A happy customer who spreads positive word-of-mouth." }
        { Id = "010"; Name = "Customer 10"; Description = "An influential customer who is part of our community." }
      ]
    }
    