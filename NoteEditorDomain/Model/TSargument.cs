namespace NoteEditorDomain.Model;

public class TSargument
{
     private readonly string[] _textAllLines;
     private readonly int _lineIndex;
     private string _oldEditableText;
     private string _filePath;

     public TSargument(string filePath, int lineIndex)
     {
          _lineIndex = lineIndex;
          _textAllLines = File.ReadAllLines(filePath);
          _filePath = filePath;
     }

     private string[] ReplaceText(string changedText)
     {
          List<string> textListLines = new(_textAllLines);
          textListLines.RemoveRange(_lineIndex, _oldEditableText.Split().Length);

          textListLines.InsertRange(_lineIndex, new string[] { changedText });
          return textListLines.ToArray();
     }

     public string ReadTextInNote()
     {
          string resultText;

          try { resultText = _textAllLines[_lineIndex]; }
          catch { return null!; }

          bool readToNextLine = true;
          for (int lineIndexNow = _lineIndex + 1; readToNextLine; ++lineIndexNow)
          {
               string line;
               try { line = _textAllLines[lineIndexNow]; }
               catch { return resultText; }

               if (string.IsNullOrEmpty(line) || line.StartsWith("-") || line.StartsWith("+") || line.StartsWith("["))
                    readToNextLine = false;
               else
               {
                    resultText += $"\n{line}";
                    readToNextLine = true;
               }
          }
          _oldEditableText = resultText;
          resultText = resultText.TrimStart('-', '+', '[', ' ');

          return resultText;
     }

     public void SaveChanged(string changedNote)
     {
          File.WriteAllLinesAsync(_filePath, ReplaceText(changedNote));
     }
}