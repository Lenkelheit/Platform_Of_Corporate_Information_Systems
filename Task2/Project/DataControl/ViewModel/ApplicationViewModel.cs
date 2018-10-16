using DataControl.Interfaces;
using DataControl.Services;
using DataControl.WpfCommands;

using Shapes.Models;
using System.ComponentModel;

using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DataControl
{
    /// <summary>
    /// A class that bond view and models.
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        // CONST
        const string APPLICATION_NAME = "Pentagon Editor";
        const string DYNAMIC_MENU_ITEM_SHAPES_NAME = "Shapes";
        // FIELDS
        private UndoRedoManager manager;
        private ShapeBase selectedShape;
        private Canvas canvas;


        private IFileService fileService;
        private IDialogService dialogService;

        private string currentFileName;

        #region Commands
        private RelayCommand newFile;
        private RelayCommand openFile;
        private RelayCommand saveFile;
        private RelayCommand saveAsFile;
        private RelayCommand exit;

        private RelayCommand undoAction;
        private RelayCommand redoAction;
        private RelayCommand undoManyAction;
        private RelayCommand redoManyAction;

        private RelayCommand addVertex;
        private RelayCommand deleteShape;
        private RelayCommand selectShapeByPosition;

        private RelayCommand changeShapeColor;
        private RelayCommand changeShapeOpacity;
        private RelayCommand changeShapeStrokeColor;
        private RelayCommand changeStrokeWidth;
        private RelayCommand changeShapeLocation;
        #endregion

        // EVENT
        /// <summary>
        /// Notifies that some property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor without parameters.
        /// </summary>
        public ApplicationViewModel()
            : this(new XmlFileService(), new DefaultDialogService()) { }
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="fileService">Service for work with files.</param>
        /// <param name="dialogService">Service for work with dialog windows.</param>
        public ApplicationViewModel(IFileService fileService, IDialogService dialogService)
        {
            this.fileService = fileService;
            this.dialogService = dialogService;

            manager = new UndoRedoManager();
            selectedShape = null;
            canvas = new Canvas();

            currentFileName = null;

            newFile = new RelayCommand(NewFileMethod);
            openFile = new RelayCommand(OpenFileMethod);
            saveFile = new RelayCommand(SaveFileMethod);
            saveAsFile = new RelayCommand(SaveAsFileMethod);
            exit = new RelayCommand(ExitMethod);

            undoAction = new RelayCommand(UndoActionMethod, CanUndoAction);
            redoAction = new RelayCommand(RedoActionMethod, CanRedoAction);
            undoManyAction = new RelayCommand(UndoManyItemsMethod);
            redoManyAction = new RelayCommand(RedoManyActionMethod);

            addVertex = new RelayCommand(AddVertexMethod);
            deleteShape = new RelayCommand(DeleteShapeMethod, CanDeleteShapeAction);
            selectShapeByPosition = new RelayCommand(SelectShapeByPositionMethod);

            manager.PropertyChanged += Manager_PropertyChanged;
        }

        // PROPERTIES
        /// <summary>
        /// Returns name of file.
        /// </summary>
        public string FileName
        {
            get
            {
                return currentFileName == null ? APPLICATION_NAME : System.IO.Path.GetFileName(currentFileName);
            }
        }
        /// <summary>
        /// Property that enable to interract with selected shape name
        /// </summary>
        public string SelectedShapeName
        {
            get
            {
                return selectedShape == null ? DYNAMIC_MENU_ITEM_SHAPES_NAME : selectedShape.Name;
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

                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedShape)));
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedShapeName)));
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
        /// <summary>
        /// Return shapes name
        /// </summary>
        public System.Collections.Generic.IEnumerable<string> ShapeNames
        {
            get
            {
                return Canvas.Shapes.Select(s => s.Name);
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

        #region Commands
        /// <summary>
        /// Property that enable to interact with NewFile command.
        /// </summary>
        public RelayCommand NewFile => newFile;
        /// <summary>
        /// Property that enable to interact with OpenFile command.
        /// </summary>
        public RelayCommand OpenFile => openFile;
        /// <summary>
        /// Property that enable to interact with SaveFile command.
        /// </summary>
        public RelayCommand SaveFile => saveFile;
        /// <summary>
        /// Property that enable to interact with SaveAsFile command.
        /// </summary>
        public RelayCommand SaveAsFile => saveAsFile;
        /// <summary>
        /// Property that enable to interact with Exit command.
        /// </summary>
        public RelayCommand Exit => exit;

        /// <summary>
        /// Property that enable to interact with UndoAction command
        /// </summary>
        public RelayCommand UndoAction => undoAction;
        /// <summary>
        /// Property that enable to interact with RedoAction command
        /// </summary>
        public RelayCommand RedoAction => redoAction;
        /// <summary>
        /// Property that enable to interact with UndoManyAction command
        /// </summary>
        public RelayCommand UndoManyAction => undoManyAction;
        /// <summary>
        /// Property that enable to interact with RedoManyAction command
        /// </summary>
        public RelayCommand RedoManyAction => redoManyAction;

        /// <summary>
        /// Property that enable to interact with AddVertex command
        /// </summary>
        public RelayCommand AddVertex => addVertex;
        /// <summary>
        /// Property that enable to interact with DeleteShape command
        /// </summary>
        public RelayCommand DeleteShape => deleteShape;
        /// <summary>
        /// Property that enable to interact with SelectShapeByPosition command
        /// </summary>
        public RelayCommand SelectShapeByPosition => selectShapeByPosition;


        public RelayCommand ChangeShapeColor => changeShapeColor;

        public RelayCommand ChangeShapeOpacity => changeShapeOpacity;

        public RelayCommand ChangeShapeStrokeColor => changeShapeStrokeColor;

        public RelayCommand ChangeStrokeWidth => changeStrokeWidth;

        public RelayCommand ChangeShapeLocation => changeShapeLocation;
        #endregion
        

        // METHODS
        private void NewFileMethod(object o)
        {
            canvas.Clear();
            this.Reset();
            OnCanvasChanged();
        }
        private void OpenFileMethod(object o)
        {
            try
            {
                if (dialogService.OpenFileDialog())
                {
                    this.Reset();
                    currentFileName = dialogService.FilePath;
                    fileService.Load(ref canvas, currentFileName);

                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(FileName)));
                    OnCanvasChanged();
                }
            }
            catch (System.Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }
        private void SaveFileMethod(object o)
        {
            try
            {
                if (currentFileName == null)   
                {
                    if (dialogService.SaveFileDialog())
                    {
                        currentFileName = dialogService.FilePath;
                        fileService.Save(canvas, currentFileName);
                        OnPropertyChanged(new PropertyChangedEventArgs(nameof(FileName)));
                    }
                }
                else
                {
                    fileService.Save(canvas, currentFileName);
                }
            }
            catch (System.Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }
        private void SaveAsFileMethod(object o)
        {
            try
            {
                if (dialogService.SaveFileDialog())
                {
                    fileService.Save(canvas, dialogService.FilePath);
                }
            }
            catch (System.Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }
        private void ExitMethod(object o)
        {
            Application.Current.Shutdown();
        }
        private void AddVertexMethod(object o)
        {
            Vertex target = new Vertex()
            {
                Location = Mouse.GetPosition((IInputElement)o)
            };
            manager.Execute(new Shapes.Commands.Vertex.AddVertex(canvas, target, manager));

            SelectedShape = canvas.Last();
            OnCanvasChanged();
        }
        private void DeleteShapeMethod(object o)
        {
            try
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
                    dialogService.ShowMessage("Shape don't chosed!");
                }
            }
            catch (System.Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }

            SelectedShape = canvas.Count > 0 ? canvas.Last() : null;
            OnCanvasChanged();
        }
        private void SelectShapeByPositionMethod(object o)
        {
            Point mouseClick = Mouse.GetPosition((IInputElement)o);
            foreach (ShapeBase shape in canvas.Shapes.Reverse())
            {
                if (shape.HitTest(mouseClick))
                {
                    SelectedShape = shape;
                    return;
                }
            }
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

        // RESTRICTIONS
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

        // ADDITIONAL METHODS
        private void Reset()
        {
            manager.Clear();
            SelectedShape = null;
        }
        private void OnCanvasChanged()
        {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Canvas)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(ShapeNames)));
        }
        // EVENT METHODS
        /// <summary>
        /// Notifies event <see cref="PropertyChanged"/> that some property is changed.
        /// </summary>
        /// <param name="e">Data for event <see cref="PropertyChanged"/>.</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private void Manager_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "UndoItems": OnPropertyChanged(new PropertyChangedEventArgs(nameof(UndoActionNames))); break;
                case "RedoItems": OnPropertyChanged(new PropertyChangedEventArgs(nameof(RedoActionNames))); break;
            }
        }
    }
}
