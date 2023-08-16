namespace AvaDemo.Model

type Product(id: string, name: string, description: string) =

  let mutable id = id
  let mutable name = name
  let mutable description = description

  member x.Id with get() = id; and set value = id <- value

  member x.Name with get() = name; and set value = name <- value

  member x.Description with get() = description; and set value = description <- value

