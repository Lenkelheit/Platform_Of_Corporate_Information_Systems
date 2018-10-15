using DataControl.Interfaces;
using DataControl.Services;
using DataControl.WpfCommands;

using Shapes.Models;

using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DataControl
{
    /// <summary>
    /// A class that bond view and models.
    /// </summary>
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

            undoAction = new RelayCommand(UndoActionMethod, CanUndoAction);
            redoAction = new RelayCommand(RedoActionMethod, CanRedoAction);
            undoManyAction = new RelayCommand(UndoManyItemsMethod);
            redoManyAction = new RelayCommand(RedoManyActionMethod);

            addVertex = new RelayCommand(AddVertexMethod);
            deleteShape = new RelayCommand(DeleteShapeMethod, CanDeleteShapeAction);

            manager.PropertyChanged += Manager_PropertyChanged;

        }



        // PROPERTIES
        public string FileName
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        /// <summary>
        /// Property that enable to interract with selected shape
        /// </summary>
        public ShapeBase SelectedShape
        {
            get
            {
                return selectedShape;
            }
            set
            {
                if (value != selectedShape)
                {
                    selectedShape = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("SelectedShape"));
                }
            }
        }
        /// <summary>
        /// Property that enable to interract with canvas
        /// </summary>
        public Canvas Canvas
        {
            get
            {
                return canvas;
            }
        }

        public System.Collections.Generic.IEnumerable<string> ShapeNames
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        /// <summary>
        /// Property that enable to get undo action names
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> UndoActionNames
        {
            get
            {
                return manager.UndoItems;
            }
        }
        /// <summary>
        /// Property that enable to get redo action names
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> RedoActionNames
        {
            get
            {
                return manager.RedoItems;
            }
        }



        public RelayCommand NewFile => newFile;

        public RelayCommand OpenFile => openFile;

        public RelayCommand SaveFile => saveFile;

        public RelayCommand SaveAsFile => saveAsFile;

        public RelayCommand Exit => exit;
        /// <summary>
        /// Property that enable to interract with DeleteShape command
        /// </summary>
        public RelayCommand DeleteShape => deleteShape;
        /// <summary>
        /// Property that enable to interract with UndoAction command
        /// </summary>
        public RelayCommand UndoAction => undoAction;
        /// <summary>
        /// Property that enable to interract with RedoAction command
        /// </summary>
        public RelayCommand RedoAction => redoAction;
        /// <summary>
        /// Property that enable to interract with UndoManyAction command
        /// </summary>
        public RelayCommand UndoManyAction => undoManyAction;
        /// <summary>
        /// Property that enable to interract with RedoManyAction command
        /// </summary>
        public RelayCommand RedoManyAction => redoManyAction;
        /// <summary>
        /// Property that enable to interract with AddVertex command
        /// </summary>
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
        private void AddVertexMethod(object o)
        {
            Vertex target = new Vertex()
            {
                Location = Mouse.GetPosition((IInputElement)o)
            };
            manager.Execute(new Shapes.Commands.Vertex.AddVertex(canvas, target, manager));

            selectedShape = canvas[canvas.Count - 1];
            OnPropertyChanged(new PropertyChangedEventArgs("Canvas"));
        }
        private void DeleteShapeMethod(object o)
        {
            if (selectedShape is Pentagon)
            {
                manager.Execute(new Shapes.Commands.Pentagon.RemovePentagon(canvas, (Pentagon)selectedShape));
            }
            else if (selectedShape is Vertex)
            {
                manager.Execute(new Shapes.Commands.Vertex.RemoveVertex(canvas, (Vertex)selectedShape));
            }
            else
            {
                throw new System.NullReferenceException("Shape don't chosed!");
            }

            selectedShape = canvas.Count > 0 ? canvas[canvas.Count - 1] : null;
        }
        private void UndoActionMethod(object o)
        {
            manager.Undo();
        }
        private void RedoActionMethod(object o)
        {
            manager.Redo();
        }
        private void UndoManyItemsMethod(object o)
        {
            manager.Undo((int)o + 1);
        }
        private void RedoManyActionMethod(object o)
        {
            manager.Redo((int)o + 1);
        }

        // RESTRICTION
        private bool CanDeleteShapeAction(object o)
        {
            return selectedShape != null;
        }
        private bool CanUndoAction(object o)
        {
            return manager.CanUndo;
        }
        private bool CanRedoAction(object o)
        {
            return manager.CanRedo;
        }
        // EVENT METHODS
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        private void Manager_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "UndoItems": OnPropertyChanged(new PropertyChangedEventArgs("UndoActionNames")); break;
                case "RedoItems": OnPropertyChanged(new PropertyChangedEventArgs("RedoActionNames")); break;
            }
        }
    }
}
