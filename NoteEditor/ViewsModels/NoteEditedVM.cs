using NoteEditorDomain;
using NoteEditorWPF.Commands;

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;

namespace NoteEditorWPF.ViewsModels;

public class NoteEditedVM : ViewModelBase
{
     private NoteLogic _noteLogic;
     private string _editableNote;
     private string _filePath;
    private Action _onClose;
    public NoteEditedVM(NoteLogic noteLogic, string filePath, Action onClose)
    {
        _noteLogic = noteLogic;
        _editableNote = noteLogic.OldNote;
        _filePath = filePath;
        _onClose = onClose;
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
          get => new ExecuteCommand(obj => { _onClose(); });
     }
}