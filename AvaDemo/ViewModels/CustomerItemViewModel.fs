namespace ViewModels.CustomerItemViewModel

open AvaDemo.ViewModels
open AvaDemo.Model



type CustomerItemViewModel(model: Customer) as x =
  inherit ViewModelBase()

  let mutable  _model = model

  member x.Id
    with get() = _model.Id
    and set value =
      _model.Id <- value
      x.NotifyPropertyChanged(nameof(x.Id))

  member x.FirstName
    with get() = _model.FirstName
    and set value =
    _model.FirstName <- value
    x.NotifyPropertyChanged(nameof(x.FirstName))

  member x.LastName
    with get() = _model.LastName
    and set value =
    _model.LastName <- value
    x.NotifyPropertyChanged(nameof(x.LastName))

  member x.IsNew
    with get() = _model.IsNew
    and set value =
    _model.IsNew <- value
    x.NotifyPropertyChanged(nameof(x.IsNew))
