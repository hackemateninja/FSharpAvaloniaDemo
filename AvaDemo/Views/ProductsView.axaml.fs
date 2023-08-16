namespace AvaDemo.Views

open System.Diagnostics
open AvaDemo.ViewModels
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Markup.Xaml

type ProductsView() as x =
  inherit UserControl()
  
  let vm = ProductsViewModel()
  
  do x.InitializeComponent()
  
  member private x.InitializeComponent() =
    AvaloniaXamlLoader.Load(x)
    x.DataContext <- vm
    x.Loaded.Add(x.ViewLoaded())
    Debug.WriteLine vm.Products
    
  member  x.ViewLoaded(sender: obj)(args: RoutedEventArgs) =
    vm.GetProductAsync()|>Async.RunSynchronously

