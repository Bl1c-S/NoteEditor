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

          public TSargument(string filePath, int lineIndex)
          {
               _filePath = filePath;
               _lineIndex = lineIndex;
          }
          public string ReadText()
          {
               string[] textAllLines = File.ReadAllLines(_filePath);
               string resultText;

               try
               {
                    resultText = textAllLines[_lineIndex];
                    resultText = resultText.TrimStart('-', '+', '[', ' ');
               }
               catch { return null!; }

               bool readToNextLine = true;
               for (int lineIndexNow = _lineIndex + 1; readToNextLine; ++lineIndexNow)
               {
                    string line;
                    try { line = textAllLines[lineIndexNow]; }
                    catch { return resultText; }

                    if (string.IsNullOrEmpty(line) || line.Contains("-") || line.Contains("+") || line.Contains("["))
                    {
                         readToNextLine = false;
                    }
                    else
                    {
                         resultText += $"\n{line}";
                         readToNextLine = true;
                    }
               }
               return resultText;
          }
          public void SaveChanged(string updateNote)
          {
          }
     }
}