namespace AvaDemo.Views

open AvaDemo.ViewModels
open Avalonia.Controls
open Avalonia.Markup.Xaml
open Avalonia.Interactivity

type CustomersView () as x = 
  inherit UserControl ()
  
  let vm = CustomersViewModel()
  
  do x.InitializeComponent()

  member private x.InitializeComponent() =
    AvaloniaXamlLoader.Load(x)
    x.DataContext <- vm
    x.Loaded.Add(x.ViewLoaded())
     
  member  x.ViewLoaded(sender: obj)(args: RoutedEventArgs) =
    vm.GetCustomersAsync()|>Async.RunSynchronously
