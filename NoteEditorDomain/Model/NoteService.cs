namespace NoteEditorDomain.Model;

public class NoteService
{
     private readonly string[] _textAllLines;
     private readonly int _lineIndex;
     private readonly string _filePath;

     public NoteService(string filePath, int lineIndex)
     {
          _lineIndex = lineIndex;
          _textAllLines = File.ReadAllLines(filePath);
          _filePath = filePath;
     }

     #region ReadMethods
     public string ReadUnFormatNote() => ReadNoteFromLineIndex().TrimStart('-', '+', '[', ' ');

     private string ReadNoteFromLineIndex()
     {
          string resultNote;

          try { resultNote = _textAllLines[_lineIndex]; }
          catch { return null!; }

          bool readToNextLine = true;
          for (int lineIndexNow = _lineIndex + 1; readToNextLine; ++lineIndexNow)
          {
               string line;
               try { line = _textAllLines[lineIndexNow]; }
               catch { return resultNote; }

               if (string.IsNullOrEmpty(line) || line.StartsWith("-") || line.StartsWith("+") || line.StartsWith("["))
                    readToNextLine = false;
               else
               {
                    resultNote += $"\n{line}";
                    readToNextLine = true;
               }
          }
          return resultNote;
     }
     #endregion

     #region SaveMethods
     private string BeackUpFormatNote(string changedText)
     {
          string oldNote = ReadNoteFromLineIndex();

          if (oldNote.StartsWith("+"))
               return changedText = string.Concat("+", changedText);
          else
               return changedText = string.Concat("-", changedText);
     }

     public string[] InsertInside(string changedNote)
     {
        string note = ReadNoteFromLineIndex();
        int numbLN = note.Split('\n').Length; // number of lines in the old note

          List<string> allTextList = new(_textAllLines);

          List<string> firstRange = new(allTextList.GetRange(0, _lineIndex));

          List<string> finalText = new(firstRange);

          List<string> correctedChangedNote = new();
         
          foreach (string line in changedNote.Split("\n"))
               correctedChangedNote.Add(line.TrimEnd('\r'));

          finalText.AddRange(correctedChangedNote);
          finalText.AddRange(allTextList.GetRange(firstRange.Count + numbLN, _textAllLines.Length - firstRange.Count - numbLN));

          return finalText.ToArray();
     }

     public void SaveChanged(string changedNote)
     {
        string returnFormatNote = BeackUpFormatNote(changedNote);
        string[] restoredText = InsertInside(returnFormatNote);
        File.WriteAllLinesAsync(_filePath, restoredText);
     }
     #endregion
}