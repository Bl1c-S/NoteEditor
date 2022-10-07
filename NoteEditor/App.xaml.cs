﻿using NoteEditorDomain.Model;
using NoteEditorWPF.Views;
using NoteEditorWPF.ViewsModels;
using System.Windows;

namespace NoteEditor;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
     protected override void OnStartup(StartupEventArgs e)
     {
          string filePath = @"C:\TSNote692.txt";
          int lineIndex = 5;

          MainWindow main = new();
          main.DataContext = new NoteEditedVM(new NoteService(filePath, lineIndex));
          main.Show();

          base.OnStartup(e);
     }
}
