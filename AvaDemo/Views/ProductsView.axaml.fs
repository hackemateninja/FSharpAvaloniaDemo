namespace AvaDemo.Views

open System.Diagnostics
open AvaDemo.ViewModels
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Markup.Xaml
open Avalonia.Threading

type ProductsView() as x =
  inherit UserControl()
  
  let _vm = ProductsViewModel()
  
  do x.InitializeComponent()
  
  member private x.InitializeComponent() =
    AvaloniaXamlLoader.Load(x)
    x.DataContext <- _vm
    x.Loaded.Add(fun _ -> x.ViewLoaded())
    
  member x.ViewLoaded() =
    let longRunningTask () =
      let progress = x.FindControl<ProgressBar>("ProgressBarLoading")
      let dataGrid = x.FindControl<DataGrid>("DataGridProducts")
      
      progress.IsVisible <- true
      dataGrid.IsVisible <- false
      async {
        do! _vm.GetProductAsync()
        
        Dispatcher.UIThread.Post(fun () ->
          progress.IsVisible <- false
          dataGrid.IsVisible <- true
        )
      } |> Async.StartImmediate

    Dispatcher.UIThread.Post(fun () -> longRunningTask())
