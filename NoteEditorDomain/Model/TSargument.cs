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
               EditebleNote = ReadText();
          }
          public string ReadText()
          {
               string[] lines = File.ReadAllLines(_filePath);
               bool readToNextLine = true;

               string returnVelue = lines[_lineIndex];

               for (int lineIndexNow = _lineIndex + 1; readToNextLine; ++lineIndexNow)
               {
                    string line;
                    try { line = lines[lineIndexNow]; }
                    catch { line = null!; }

                    if (line.Contains("-") || line.Contains("+") || line.Contains("[") || string.IsNullOrEmpty(line))
                    {
                         readToNextLine = false;
                    }
                    else
                    {
                         returnVelue += $"\n{line}";
                         readToNextLine = true;
                    }
               }
               return returnVelue;
          }
          public void SaveChanged(string updateNote)
          {
          }
     }
}