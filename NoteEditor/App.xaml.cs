using NoteEditorDomain.Model;
using NoteEditorWPF.Views;
using NoteEditorWPF.ViewsModels;
using System;
using System.IO;
using System.Windows;

namespace NoteEditor
{
     /// <summary>
     /// Interaction logic for App.xaml
     /// </summary>
     public partial class App : Application
     {
          protected override void OnStartup(StartupEventArgs e)
          {
               string filePath = @"C:\TSNote692.txt";
               int lineIndex = 5;
               TSargument txtFile = new(filePath, lineIndex);

               MainWindowVM mainVM = new();
               NoteEditedVM noteEditorView = new(txtFile);

               MainWindow main = new();
               NoteEditedView noteEdited = new();

               main.DataContext = noteEditorView;
               noteEdited.DataContext = noteEditorView;
               main.Show();

               base.OnStartup(e);
          }
     }
}
