namespace AvaDemo.Views

open Avalonia.Controls
open Avalonia.Markup.Xaml

type MainView () as x = 
  inherit UserControl ()

  do x.InitializeComponent()

  member private x.InitializeComponent() =
    AvaloniaXamlLoader.Load(x)
  


