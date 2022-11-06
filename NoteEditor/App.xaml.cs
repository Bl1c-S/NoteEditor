using NoteEditorDomain;
using NoteEditorWPF.ViewsModels;
using System.IO;
using System.Windows;

namespace NoteEditor;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
     protected override void OnStartup(StartupEventArgs e)
     {
          string filePath = @"X:\TSNote692.txt";
          int lineIndex = 19;

          string[] text = File.ReadAllLines(filePath);

          MainWindow main = new();
          main.DataContext = new NoteEditedVM(new NoteLogic(text, lineIndex), filePath);
          main.Show();

          base.OnStartup(e);
     }
}