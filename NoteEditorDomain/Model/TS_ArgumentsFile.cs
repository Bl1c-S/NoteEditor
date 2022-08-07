using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NoteEditorDomain.Model
{
     public class TS_ArgumentsFile
     {
          public int _lineIndex { get; }
          public string _filePath { get; }

          public TS_ArgumentsFile(int lineIndex, string filePath)
          {
               _lineIndex = lineIndex;
               _filePath = filePath;
          }
     }
}
