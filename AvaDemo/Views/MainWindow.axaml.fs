namespace AvaDemo.Views

open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml

type MainWindow() as x = 
    inherit Window ()

    do x.InitializeComponent()

    member private x.InitializeComponent() =
#if DEBUG
        x.AttachDevTools()
#endif
        AvaloniaXamlLoader.Load(x)