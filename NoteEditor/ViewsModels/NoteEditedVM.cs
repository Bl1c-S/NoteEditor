using NoteEditorDomain.Model;
using NoteEditorWPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NoteEditorWPF.ViewsModels
{
     internal class NoteEditedVM : ViewModelBase
     {
          private string _editableNote;
          private string _updateEditableNote;
          public ICommand SaveChangedButton { get; }
          public NoteEditedVM(TSargument tsArgument)
          {
               SaveChangedButton = new SaveChangedCommand(tsArgument, _updateEditableNote);
               _editableNote = tsArgument.ReadText();
          }
          public string EditableNote
          {
               get { return CheckText(); }
               set
               {
                    _updateEditableNote = value;
                    OnPropertyChanged(EditableNote);
               }
          }
          private string CheckText()
          {
               if (_editableNote != null)
                    return _editableNote;

               MessageBox.Show("Dont can find text");
               return null!;
          }
     }
}
