namespace AvaDemo.Controls

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type HeaderControl () as this = 
  inherit UserControl ()

  do this.InitializeComponent()

  member private this.InitializeComponent() =
    AvaloniaXamlLoader.Load(this)
