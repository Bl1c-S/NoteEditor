using NoteEditorDomain;

using NoteEditorWPF.ViewsModels;

using System.IO;
using System.Windows;

namespace NoteEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Init()
        {
            string filePath = @"X:\TSNote692.txt";
            int lineIndex = 19;

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"File {filePath} not found");
                Close();
                return;
            }

            string[] text = File.ReadAllLines(filePath);

            DataContext = new NoteEditedVM(new NoteLogic(text, lineIndex), filePath, Close);
        }

    }
}
