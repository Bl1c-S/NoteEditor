using NoteEditorDomain.Model;
using NoteEditorWPF.Commands;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace NoteEditorWPF.ViewsModels;

public class NoteEditedVM : ViewModelBase
{
     private NoteService _tsArgument;
     private string _editableNote;
     public NoteEditedVM(NoteService tsArgument)
     {
          _tsArgument = tsArgument;
          _editableNote = tsArgument.ReadUnFormatNote();
          CheckText();
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
          get => new ExecuteCommand(obj => { _tsArgument.SaveChanged(_editableNote); });
     }
     public ICommand CancelButton
     {
          get => new ExecuteCommand(obj => { Process.GetCurrentProcess().Kill(); });
     }
     private void CheckText()
     {
          if (_editableNote == null)
          {
               MessageBox.Show("Dont can find text");
               Process.GetCurrentProcess().Kill();
          }
     }
}