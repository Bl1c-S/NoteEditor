using NoteEditorDomain.Model;
using NoteEditorWPF.Commands;
using System.Windows;
using System.Windows.Input;

namespace NoteEditorWPF.ViewsModels;

public class NoteEditedVM : ViewModelBase
{
     private NoteService _tsArgument;
     private string _changedNote;
     private string _editableNote;
     public NoteEditedVM(NoteService tsArgument)
     {
          _tsArgument = tsArgument;
          _editableNote = tsArgument.ReadFormatNote();
     }
     public string EditableNote
     {
          get { return CheckText(); }
          set
          {
               _changedNote = value;
               //OnPropertyChanged(EditableNote);
          }
     }
     public ICommand SaveChangedButton
     {
          get
          {
               return new SaveChangedCommand(obj =>
               {
                    _tsArgument.SaveChanged(_changedNote);
               });
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