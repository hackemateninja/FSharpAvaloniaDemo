namespace AvaDemo.Model

type Customer(id: string, firstName: string, lastName: string, isNew: bool) as x =

  let mutable id = id
  let mutable firstName = firstName
  let mutable lastName = lastName
  let mutable isNew = isNew

  member x.Id with get() = id; and set value = id <- value

  member x.FirstName with get() = firstName; and set value = firstName <- value

  member x.LastName with get() = lastName; and set value = lastName <- value

  member x.IsNew with get() = isNew; and set value = isNew <- value
