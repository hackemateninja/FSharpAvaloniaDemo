namespace AvaDemo.Views

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml
open Avalonia.Interactivity
open Avalonia.Diagnostics

type CustomersView () as x = 
  inherit UserControl ()

  do x.InitializeComponent()

  member private x.InitializeComponent() =
    AvaloniaXamlLoader.Load(x)

  member x.MovePanelClick(sender: obj) (args: RoutedEventArgs) =
    let listGrid = x.FindControl<Grid>("ListClientsGrid")
    let column = Grid.GetColumn(listGrid)
    let newCol = if column = 0 then 2 else 0
    Grid.SetColumn(listGrid, newCol)
