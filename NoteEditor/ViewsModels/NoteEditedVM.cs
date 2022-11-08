using NoteEditorDomain;
using NoteEditorWPF.Commands;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;

namespace NoteEditorWPF.ViewsModels;

public class NoteEditedVM : ViewModelBase
{
     private NoteLogic _noteLogic;
     private string _editableNote;
     private string _filePath;
     public NoteEditedVM(NoteLogic noteLogic, string filePath)
     {
          _noteLogic = noteLogic;
          _editableNote = noteLogic.UF_OldNote;
          _filePath = filePath;
     }
     public string EditableNote
     {
          get { return _editableNote; }
          set
          {
               _editableNote = value;
               OnPropertyChanged(EditableNote);
          }
     }
     public ICommand SaveChangedButton
     {
          get => new ExecuteCommand(obj => {
               string[] changedText = _noteLogic.InsertInside(_editableNote);
               File.WriteAllLinesAsync(_filePath, changedText);
          });
     }
     public ICommand CancelButton
     {
          get => new ExecuteCommand(obj => { Process.GetCurrentProcess().Kill(); });
     }
}