namespace AvaDemo.ViewModels

open AvaDemo.Model

type ProductItemViewModel(model: Product) as x =
  inherit ViewModelBase()

  let mutable  _model = model

  member x.Id
    with get() = _model.Id
    and set value =
      _model.Id <- value
      x.NotifyPropertyChanged()

  member x.Name
    with get() = _model.Name
    and set value =
    _model.Name <- value
    x.NotifyPropertyChanged()

  member x.Description
    with get() = _model.Description
    and set value =
    _model.Description <- value
    x.NotifyPropertyChanged()
