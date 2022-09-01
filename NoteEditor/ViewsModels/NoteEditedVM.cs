using NoteEditorDomain.Model;
using NoteEditorWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteEditorWPF.ViewsModels
{
     internal class NoteEditedVM : ViewModelBase
     {
          public NoteEditedVM(TSargument tsArgument)
          {
               SaveChangedButton = new SaveChangedCommand(tsArgument, _updateEditableNote);
               _editableNote = tsArgument.EditebleNote;
          }
          private string _editableNote;
          private string _updateEditableNote;
          public string EditableNote
          {
               get { return _editableNote; }
               set
               {
                    _updateEditableNote = value;
                    OnPropertyChanged(EditableNote);
               }
          }
          public ICommand SaveChangedButton { get; }
     }
}
