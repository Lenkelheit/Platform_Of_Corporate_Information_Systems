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
        RelayCommand openFile;
        RelayCommand saveFile;
        RelayCommand saveAsFile;
        RelayCommand exit;

        RelayCommand undoAction;
        RelayCommand redoAction;
        RelayCommand undoManyAction;
        RelayCommand redoManyAction;

        RelayCommand addVertex;
        RelayCommand deleteShape;
        RelayCommand changeShapeColor;
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

            newFile = new RelayCommand(NewFileMethod);

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
            set
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
        public System.Collections.Generic.IEnumerable<string> shapeNames
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public System.Collections.Generic.IEnumerable<string> undoActionNames
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public System.Collections.Generic.IEnumerable<string> redoActionNames
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

  

        public RelayCommand NewFile => newFile;

        public RelayCommand OpenFile => openFile;

        public RelayCommand SaveFile => saveFile;

        public RelayCommand SaveAsFile => saveAsFile;

        public RelayCommand Exit => exit;

        public RelayCommand DeleteShape => deleteShape;

        public RelayCommand UndoAction => undoAction;

        public RelayCommand RedoAction => redoAction;

        public RelayCommand UndoManyAction => undoManyAction;

        public RelayCommand RedoManyAction => redoManyAction;

        public RelayCommand AddVertex => addVertex;

        public RelayCommand ChangeShapeColor => changeShapeColor;

        public RelayCommand ChangeShapeOpacity => changeShapeOpacity;

        public RelayCommand ChangeShapeStrokeColor => changeShapeStrokeColor;

        public RelayCommand ChangeStrokeWidth => changeStrokeWidth;

        public RelayCommand ChangeShapeLocation => changeShapeLocation;

        // METHODS
        private void NewFileMethod(object o)
        {
            throw new System.NotImplementedException();
        }
        // your methods here
    }
}
