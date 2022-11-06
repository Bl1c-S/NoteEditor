using System.Text;

namespace NoteEditorDomain;
public class NoteLogic
{
     private readonly char[] _endNoteAttribute;
     private readonly int _lineIndex;
     private readonly string[] _text;
     private readonly string _oldNote;

     public NoteLogic(string[] text, int lineIndex)
     {
          _endNoteAttribute = new char[] { '+', '-', '[' };
          _lineIndex = lineIndex;
          _text = text;
          _oldNote = GetNote().TrimEnd('\n','\r');
     }

     public string GetUnFormatNote() => _oldNote.TrimStart(_endNoteAttribute);

     private List<string> GetFormatNote(string changedNote)
     {
          StringBuilder sb;
          if (_oldNote.StartsWith("+"))
               sb = new($"+{changedNote}");
          else if (_oldNote.StartsWith("-"))
               sb = new($"-{changedNote}");
          else
               sb = new(changedNote);

          List<string> formattedChangedNote = new();

          foreach (string line in sb.ToString().Split("\n"))
               formattedChangedNote.Add(line.TrimEnd('\r'));

          return formattedChangedNote;
     }

     private string GetNote()
     {
          if (_lineIndex >= _text.Length)
               throw new ArgumentOutOfRangeException();

          StringBuilder sb = new(_text[_lineIndex]);

          for (int i = _lineIndex + 1; i < _text.Length; i++)
          {
               string line = _text[i];

               foreach (var endchar in _endNoteAttribute)
               {
                    if (line.StartsWith(endchar))
                         return sb.ToString();
               }
               sb.AppendLine($"\n{line}");
          }
          return sb.ToString();
     }

     public string[] InsertInside(string changedNote)
     {
          List<string> allTextList = new(_text);
          List<string> finalText = new(allTextList.GetRange(0, _lineIndex));

          List<string> formattedChangedNote = GetFormatNote(changedNote);
          finalText.AddRange(formattedChangedNote);

          int endOfNoteIndex = _lineIndex + _oldNote.Split("\n").Length;
          int countLineOfEndRange = _text.Length - endOfNoteIndex;

          List<string> endOfTextRange = allTextList.GetRange(endOfNoteIndex, countLineOfEndRange);
          finalText.AddRange(endOfTextRange);

          return finalText.ToArray();
     }
}