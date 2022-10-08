using NoteEditorDomain.Model;
using System;

namespace NoteEditorWPF.Commands;

public class ExecuteCommand : CommandBase
{
     private Action<object> execute;
     private Func<object, bool> _canExecute;

     public ExecuteCommand(Action<object> execute, Func<object, bool> canExecute = null)
     {
          this.execute = execute;
          this._canExecute = canExecute;
     }
     public override bool CanExecute(object? parameter)
     {
          return this._canExecute == null || this._canExecute(parameter);
     }
     public override void Execute(object parameter)
     {
          this.execute(parameter);
     }
}