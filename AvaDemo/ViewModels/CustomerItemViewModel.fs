﻿namespace AvaDemo.ViewModels

open AvaDemo.Model

type CustomerItemViewModel(model: Customer) as x =
  inherit ValidationViewModelBase()

  let mutable  _model = model

  member x.Id
    with get() = _model.Id
    and set value =
      _model.Id <- value
      x.NotifyPropertyChanged()

  member x.FirstName
    with get() = _model.FirstName
    and set value =
    _model.FirstName <- value
    x.NotifyPropertyChanged()
    if model.FirstName.Length <= 0 then
      x.AddError("Firstname is required", nameof(x.FirstName))
    else
      x.ClearErrors(nameof(x.FirstName))

  member x.LastName
    with get() = _model.LastName
    and set value =
    _model.LastName <- value
    x.NotifyPropertyChanged()
    if model.LastName.Length <= 0 then
      x.AddError("LastName is required", nameof(x.LastName))
    else
      x.ClearErrors(nameof(x.LastName))

  member x.IsNew
    with get() = _model.IsNew
    and set value =
    _model.IsNew <- value
    x.NotifyPropertyChanged()
