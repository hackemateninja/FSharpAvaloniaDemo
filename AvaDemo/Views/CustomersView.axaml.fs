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
    vm.GetCustomersAsync()|>Async.RunSynchronously
    x.DataContext <- vm

  member x.MovePanelClick(sender: obj) (args: RoutedEventArgs) =
    let listGrid = x.FindControl<Grid>("ListClientsGrid")
    let column = Grid.GetColumn(listGrid)
    let newCol = if column = 0 then 2 else 0
    Grid.SetColumn(listGrid, newCol)
    
  member x.AddClientClick(sender: obj)(args: RoutedEventArgs) =
    ()
