using NoteEditorDomain.Model;
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
               string filePath = "c" ;
               int lineIndex = 1 ;
               TS_ArgumentsFile argumentsFile = new(lineIndex, filePath);

               base.OnStartup(e);
          }
     }
}
