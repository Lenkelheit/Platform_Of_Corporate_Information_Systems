using DataControl.Interfaces;
using DataControl.Services;
using DataControl.WpfCommands;

using Shapes.Models;

using System.ComponentModel;


namespace DataControl
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        // FIELDS
        UndoRedoManager manager;
        ShapeBase selectedShape;
        Canvas canvas;

        IFileService fileService;
        IDialogService dialogService;

        bool dataChanged;
        string currentFileName;

        RelayCommand newFile;
        RelayCommand saveFile;
        RelayCommand saveAsFile;
        RelayCommand exit;
        RelayCommand deleteShape;
        RelayCommand undoAction;
        RelayCommand redoAction;
        RelayCommand undoManyAction;
        RelayCommand redoManyAction;
        RelayCommand changeShapeColoe;
        RelayCommand changeShapeOpacity;
        RelayCommand changeShapeStrokeColor;
        RelayCommand changeStrokeWidth;
        RelayCommand changeShapeLocation;

        // EVENT
        public event PropertyChangedEventHandler PropertyChanged;

        // CONSTRUCTORS
        public ApplicationViewModel()
            : this(new XmlFileService(), new DefaultDialogService()) { }

        public ApplicationViewModel(IFileService fileService, IDialogService dialogService)
        {
            this.fileService = fileService;
            this.dialogService = dialogService;

            manager = new UndoRedoManager();
            selectedShape = null;
            canvas = new Canvas();

            dataChanged = false;
            currentFileName = null;

            newFile = new RelayCommand(NewFile);

            throw new System.NotImplementedException();
        }

        // PROPERTIES
        public string FileName
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public ShapeBase SelectedShape
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public Canvas Canvas
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand SaveFile
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand SaveAsFile
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand Exit
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand DeleteShape
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand UndoAction
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand RedoAction
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand UndoManyAction
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand RedoManyAction
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand ChangeShapeColoe
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand ChangeShapeOpacity
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand ChangeShapeStrokeColor
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand ChangeStrokeWidth
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public RelayCommand ChangeShapeLocation
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        // METHODS
        private void NewFile(object o)
        {
            throw new System.NotImplementedException();
        }
        // your methods here
    }
}
