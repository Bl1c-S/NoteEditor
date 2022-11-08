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
        MainWindow main = new();        
        main.Show();
        main.Init();
        base.OnStartup(e);
    }
}