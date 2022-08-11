using NoteEditorWPF.Commands;
using System.Windows.Input;

namespace NoteEditorWPF.ViewsModels
{
     public class NoteEditorViewModel : ViewModelBase
     {
          public NoteEditorViewModel(string oldEditableNote)
          {
               _oldEditableNote = oldEditableNote;
               SaveChangedButton = new SaveChangedCommand();
          }

          private string _oldEditableNote;
          public string OldEditableNote
          {
               get
               {
                    return _oldEditableNote;
               }
          }

          private string _updateEditableNote;
          public string UpdateEditableNote
          {
               set
               {
                    _updateEditableNote = value;
                    OnPropertyChanged(nameof(UpdateEditableNote));
               }
          }
          public ICommand SaveChangedButton { get; }
     }
}
