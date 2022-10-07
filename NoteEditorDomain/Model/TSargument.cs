namespace NoteEditorDomain.Model;

public class NoteService
{
     private readonly string[] _textAllLines;
     private readonly int _lineIndex;
     private readonly string _filePath;
     private string _oldEditableNote;

     public NoteService(string filePath, int lineIndex)
     {
          _lineIndex = lineIndex;
          _textAllLines = File.ReadAllLines(filePath);
          _filePath = filePath;
     }

     #region ReadMethods
     public string ReadFormatNote() => ReadNote().TrimStart('-', '+', '[', ' ');

     private string ReadNote()
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
     private string[] ReplaceText(string changedText)
     {
          string oldNote = ReadNote();
          List<string> textListLines = new(_textAllLines);
          textListLines.RemoveRange(_lineIndex, oldNote.Split().Length - 1);

          if (oldNote.StartsWith("-"))
               changedText = string.Concat("-", changedText);
          if (oldNote.StartsWith("+"))
               changedText = string.Concat("+", changedText);

          textListLines.InsertRange(_lineIndex, new string[] { changedText });
          return textListLines.ToArray();
     }

     public void SaveChanged(string changedNote)
     {
          File.WriteAllLinesAsync(_filePath, ReplaceText(changedNote));
     }
     #endregion
}