using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteEditorDomain.Model
{
    public class NoteLogic
    {
        private char[] startOfTextChars = new char[] { '-', '+', '['};
        public (string note, int endIndex) GetNoteInfo(string[] lines, int lineIndex)
        {
            if (lineIndex > lines.Length - 1 || lineIndex < 0)
                throw new IndexOutOfRangeException();

            var sb = new StringBuilder();

            for (int i = lineIndex; i < lines.Length; i++)
            {
                string line = lines[i];
                bool isNewText = IsNewText(line);

                if (isNewText)
                    return (sb.ToString(), i);
                else
                    sb.AppendLine(line);
            }

            return (string.Empty, -1);
        }

        public bool IsNewText(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            char first = line[0];
            bool resul = startOfTextChars.Contains(first);
            return resul;
        }
    }
}
