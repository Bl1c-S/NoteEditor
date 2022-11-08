using System.Text;

namespace NoteEditorDomain;
public class NoteLogic
{
     public readonly string UF_OldNote;

     private readonly string[] _text;
     private readonly char[] _endNoteAttribute;
     private readonly char? _startAttribute;

     private readonly int _startIndex;
     private readonly int _endIndex;

     public NoteLogic(string[] text, int lineIndex)
     {
          _endNoteAttribute = new char[] { '+', '-', '[' };
          _startIndex = lineIndex;
          _text = text;

          var (oldNote, endIndex, startAttribute) = GetNote();
          UF_OldNote = oldNote;
          _endIndex = endIndex;
          _startAttribute = startAttribute;
     }

     private (string, int, char?) GetNote()
     {
          if (_startIndex >= _text.Length)
               throw new ArgumentOutOfRangeException();

          int endIndex = _startIndex + 1;
          string startLine = _text[_startIndex];
          StringBuilder sb = new(startLine);

          char? startAttrubute = null;
          if (_endNoteAttribute.Contains(startLine[0]))
          startAttrubute = startLine[0];

          for (; endIndex < _text.Length; ++endIndex)
          {
               string line = _text[endIndex];

               if (_endNoteAttribute.Contains(line[0]))
                    break;

               sb.AppendLine($"\n{line}");
          }

          string ufNote = GetUnFormatNote(sb.ToString());
          return (ufNote, endIndex, startAttrubute);
     }

     private string GetUnFormatNote(string note)
     {
          note = note.TrimEnd('\n', '\r');
          return note.TrimStart(_endNoteAttribute);
     }
     private List<string> GetFormatNote(string changedNote)
     {
          string startFormatNote = _startAttribute + changedNote;

          List<string> formattedChangedNote = new();

          foreach (string line in startFormatNote.Split("\n"))
               formattedChangedNote.Add(line.TrimEnd('\r'));

          return formattedChangedNote;
     }

     public string[] InsertInside(string changedNote)
     {
          List<string> allTextList = new(_text);
          List<string> finalText = new(allTextList.GetRange(0, _startIndex));

          List<string> formattedChangedNote = GetFormatNote(changedNote);
          finalText.AddRange(formattedChangedNote);

          int countEndRange = _text.Length - _endIndex;
          List<string> endOfTextRange = allTextList.GetRange(_endIndex, countEndRange);
          finalText.AddRange(endOfTextRange);

          return finalText.ToArray();
     }
}