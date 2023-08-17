namespace AvaDemo.Views

open System.Diagnostics
open AvaDemo.ViewModels
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Markup.Xaml
open Avalonia.Threading

type ProductsView() as x =
  inherit UserControl()
  
  let vm = ProductsViewModel()
  
  do x.InitializeComponent()
  
  member private x.InitializeComponent() =
    AvaloniaXamlLoader.Load(x)
    x.DataContext <- vm
    x.Loaded.Add(x.ViewLoaded())
    
  member  x.ViewLoaded(sender: obj)(args: RoutedEventArgs) =
    Dispatcher.UIThread.InvokeAsync (fun () ->
      vm.GetProductAsync()|>Async.RunSynchronously
    ) |> ignore

