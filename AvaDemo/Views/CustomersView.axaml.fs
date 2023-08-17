namespace AvaDemo.Views

open AvaDemo.ViewModels
open Avalonia.Controls
open Avalonia.Markup.Xaml
open Avalonia.Interactivity
open Avalonia.Threading

type CustomersView () as x = 
  inherit UserControl ()
  
  let vm = CustomersViewModel()
  
  do x.InitializeComponent()

  member private x.InitializeComponent() =
    AvaloniaXamlLoader.Load(x)
    x.DataContext <- vm
    x.Loaded.Add(fun _ -> x.ViewLoaded())
     
  member x.ViewLoaded() =
    Dispatcher.UIThread.InvokeAsync (fun () ->
      vm.GetCustomersAsync() |> Async.RunSynchronously
    ) |> ignore
