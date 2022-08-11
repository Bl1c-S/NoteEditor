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
               int lineIndex = 1;

               try
               {
                    StreamReader TxtReader = new StreamReader(filePath);
                         string line = TxtReader.ReadLine();
                         NoteEditorViewModel NoteEditor = new(line);
               }
               catch { MessageBox.Show("Eror: Read file path"); }

               base.OnStartup(e);
               }
               }
          }
