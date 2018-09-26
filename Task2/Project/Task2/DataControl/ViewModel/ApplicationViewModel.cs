using System.ComponentModel;

namespace DataControl
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public WpfCommands.DelegateCommand UndoRedoManagerChanged;
        Interfaces.IFileService fileService;
        Interfaces.IDialogService dialogService;

        public event PropertyChangedEventHandler PropertyChanged;
        public WpfCommands.DelegateCommand ChangeColor;
        public WpfCommands.DelegateCommand OpenFileDialog;
        /*all the others command*/
    }
}
