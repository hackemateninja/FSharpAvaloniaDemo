namespace AvaDemo.Views

open AvaDemo.ViewModels
open Avalonia.Controls
open Avalonia.Markup.Xaml
open Avalonia.Threading

type CustomersView () as x = 
  inherit UserControl ()
  
  let _vm = CustomersViewModel()
  
  do x.InitializeComponent()

  member private x.InitializeComponent() =
    AvaloniaXamlLoader.Load(x)
    x.DataContext <- _vm
    x.Loaded.Add(fun _ -> x.ViewLoaded())
     
  member x.ViewLoaded() =
    let longRunningTask () =
      let progress = x.FindControl<ProgressBar>("ProgressBarLoading")
      let ListBox = x.FindControl<ListBox>("ListBoxCustomers")
      
      progress.IsVisible <- true
      ListBox.IsVisible <- false
      
      async {
        do! _vm.GetCustomersAsync()
        
        Dispatcher.UIThread.Post(fun () ->
          progress.IsVisible <- false
          ListBox.IsVisible <- true
        )
      } |> Async.StartImmediate

    Dispatcher.UIThread.Post(fun () -> longRunningTask())
    
  
