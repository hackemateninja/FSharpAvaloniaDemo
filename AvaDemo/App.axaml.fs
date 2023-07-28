namespace AvaDemo

open System
open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Markup.Xaml
open AvaDemo.ViewModels
open AvaDemo.Views

type App() =
  inherit Application()

  override this.Initialize() =
    AvaloniaXamlLoader.Load(this)

  override this.OnFrameworkInitializationCompleted() =
    match this.ApplicationLifetime with
    | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
        desktopLifetime.MainWindow <- MainWindow(DataContext = MainViewModel())
    | :? ISingleViewApplicationLifetime as singleViewLifetime ->
        singleViewLifetime.MainView <- MainView(DataContext = MainViewModel())
    | _ -> ()

    base.OnFrameworkInitializationCompleted()
