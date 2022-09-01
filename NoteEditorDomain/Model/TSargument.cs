using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteEditorDomain.Model
{
     public class TSargument
     {
          private string _filePath { get; set; }
          private int _lineIndex { get; set; }
          public string EditebleNote;

          public TSargument(string filePath, int lineIndex)
          {
               _filePath = filePath;
               _lineIndex = lineIndex;
               ReadText();
          }
          public void ReadText()
          {
               string[] lines = File.ReadAllLines(_filePath);
               bool readToNext = true;

               for (int lineIndexNow = 0; lineIndexNow <= lines.Length; lineIndexNow++)
               {
                    foreach (string line in lines)
                    {
                         if (line.Contains("-") || line.Contains("+") || line.Contains("["))
                              readToNext = false;

                         if (lineIndexNow >= _lineIndex && readToNext)
                              EditebleNote = EditebleNote + $"\n{line}";
                    }
                    if (EditebleNote == null)
                         EditebleNote = "eror find";
               }
          }
          public void SaveChanged(string updateNote)
          {
          }
     }
}
