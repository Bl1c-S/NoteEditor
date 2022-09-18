using System.ComponentModel;

namespace NoteEditorWPF.ViewsModels;

public class ViewModelBase : INotifyPropertyChanged
{
     public event PropertyChangedEventHandler? PropertyChanged;

     protected void OnPropertyChanged(string propertyName)
     {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
     }
}
