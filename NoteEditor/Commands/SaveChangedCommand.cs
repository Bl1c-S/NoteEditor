using NoteEditorDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteEditorWPF.Commands
{
     public class SaveChangedCommand : CommandBase
     {
          private readonly TSargument _tsargument;
          private string _updateNote;

          public SaveChangedCommand(TSargument tsargument, string updateNote)
          {
               _tsargument = tsargument;
               _updateNote = updateNote;
          }

          public override void Execute(object? parameter)
          {
               _tsargument.SaveChanged(_updateNote);
          }
     }
}
