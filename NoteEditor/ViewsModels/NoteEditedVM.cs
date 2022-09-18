using NoteEditorDomain.Model;
using NoteEditorWPF.Commands;
using System.Windows;
using System.Windows.Input;

namespace NoteEditorWPF.ViewsModels;

internal class NoteEditedVM : ViewModelBase
{
     private string _changedNote;
     private string _editableNote;
     public ICommand SaveChangedButton { get; set; }
     public NoteEditedVM(TSargument tsArgument)
     {
          SaveChangedButton = new SaveChangedCommand(tsArgument);
          _editableNote = tsArgument.ReadTextInNote();
     }
     public string EditableNote
     {
          get { return CheckText(); }
          set
          {
               _changedNote = value;
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
