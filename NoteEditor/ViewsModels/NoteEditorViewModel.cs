namespace NoteEditorWPF.ViewsModels
{
     public class NoteEditorViewModel : ViewModelBase
     {
          public NoteEditorViewModel(string oldEditableNote) =>_oldEditableNote = oldEditableNote;

          private string _oldEditableNote;
          public string OldEditableNote
          {
               get { return _oldEditableNote; }
          }
          private int _updateEditableNote;
          public int UpdateEditableNote
          {
               set
               {
                    _updateEditableNote = value;
                    OnPropertyChanged(nameof(UpdateEditableNote));
               }
          }
          //private int myVar;
          //public int MyProperty
          //{
          //     get
          //     {
          //          return myVar;
          //     }
          //     set
          //     {
          //          myVar = value;
          //          OnPropertyChanged(nameof(MyProperty));
          //     }
          //}
     }
}
