namespace AvaDemo

open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Markup.Xaml
open AvaDemo.ViewModels
open AvaDemo.Views

type App() =
  inherit Application()

  override x.Initialize() =
    AvaloniaXamlLoader.Load(x)

  override x.OnFrameworkInitializationCompleted() =
    match x.ApplicationLifetime with
    | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
        desktopLifetime.MainWindow <- MainWindow(DataContext = MainViewModel())
    | :? ISingleViewApplicationLifetime as singleViewLifetime ->
        singleViewLifetime.MainView <- MainView(DataContext = MainViewModel())
    | _ -> ()

    base.OnFrameworkInitializationCompleted()
