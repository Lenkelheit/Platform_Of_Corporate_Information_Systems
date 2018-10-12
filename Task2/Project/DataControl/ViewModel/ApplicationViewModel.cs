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


            changeShapeColor = new RelayCommand(ChangeColorMethod);
            changeShapeOpacity = new RelayCommand(ChangeOpacityMethod);
            changeShapeStrokeColor = new RelayCommand(ChangeStrokeColorMethod);
            changeStrokeWidth = new RelayCommand(ChangeStrokeWidthMethod);
            changeShapeLocation = new RelayCommand(ChangeLocationMethod);

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
        /// <summary>
        /// Property that enable to interract with ChangeShapeColor command.
        /// </summary>
        public RelayCommand ChangeShapeColor => changeShapeColor;
        /// <summary>
        /// Property that enable to interract with ChangeShapeOpacity command.
        /// </summary>
        public RelayCommand ChangeShapeOpacity => changeShapeOpacity;
        /// <summary>
        /// Property that enable to interract with ChangeShapeStrokeColor command.
        /// </summary>
        public RelayCommand ChangeShapeStrokeColor => changeShapeStrokeColor;
        /// <summary>
        /// Property that enable to interract with ChangeStrokeWidth command.
        /// </summary>
        public RelayCommand ChangeStrokeWidth => changeStrokeWidth;
        /// <summary>
        /// Property that enable to interract with ChangeShapeLocation command.
        /// </summary>
        public RelayCommand ChangeShapeLocation => changeShapeLocation;

        // METHODS
        private void NewFileMethod(object o)
        {
            throw new System.NotImplementedException();
        }
        // your methods here

        // PROPERTIES
        /// <summary>
        /// Property that returns the name of a figure.
        /// </summary>
        public string ShapeNames => "Name shape";

        private void ChangeColorMethod(object obj)
        {
            System.Windows.Media.Color target = System.Windows.Media.Color.FromRgb(0,255,0);
            Pentagon pentagon = obj as Pentagon;
            if(pentagon == null)
            {
                throw new System.ArgumentException("object is not pentagon");
            }
            manager.Execute(new Shapes.Commands.Pentagon.ChangeColor(pentagon, target));
        }

        private void ChangeLocationMethod(object obj)
        {
            System.Windows.Point[] points = new System.Windows.Point[5];
            Pentagon pentagon = obj as Pentagon;
            if (pentagon == null)
            {
                throw new System.ArgumentException("object is not pentagon");
            }
            manager.Execute(new Shapes.Commands.Pentagon.ChangeLocation(pentagon, points));
        }

        private void ChangeOpacityMethod(object obj)
        {
            double target = 3;
            Pentagon pentagon = obj as Pentagon;
            if (pentagon == null)
            {
                throw new System.ArgumentException("object is not pentagon");
            }
            manager.Execute(new Shapes.Commands.Pentagon.ChangeOpacity(pentagon, target));
        }

        private void ChangeStrokeColorMethod(object obj)
        {
            System.Windows.Media.Color target = System.Windows.Media.Color.FromRgb(0, 255, 0);
            Pentagon pentagon = obj as Pentagon;
            if (pentagon == null)
            {
                throw new System.ArgumentException("object is not pentagon");
            }
            manager.Execute(new Shapes.Commands.Pentagon.ChangeStrokeColor(pentagon, target));
        }

        private void ChangeStrokeWidthMethod(object obj)
        {
            double target = 3;
            Pentagon pentagon = obj as Pentagon;
            if (pentagon == null)
            {
                throw new System.ArgumentException("object is not pentagon");
            }
            manager.Execute(new Shapes.Commands.Pentagon.ChangeStrokeWidth(pentagon, target));
        }
    }
}
