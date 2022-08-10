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
               string filePath = @"C:\TSNote692";
               int lineIndex = 1 ;

               try
               {
                    StreamReader StreamReader = new StreamReader(filePath);
                    string? line = StreamReader.ReadLine();
               }
               catch
               {

               }

               base.OnStartup(e);
          }
     }
}
