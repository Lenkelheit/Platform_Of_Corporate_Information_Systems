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
        private Window mainWindow;

        private UndoRedoManager manager;
        private ShapeBase selectedShape;
        private Canvas canvas;


        private IFileService fileService;
        private IDialogService dialogService;

        private string currentFileName;

        #region Commands
        private RelayCommand initialize;

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

        private RelayCommand canApplyChanging;
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

            initialize = new RelayCommand(InitializeMethod);

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

            canApplyChanging = new RelayCommand((obj) => { }, CanChangeAction);
            changeShapeColor = new RelayCommand(ChangeColorMethod, CanChangeAction);
            changeShapeOpacity = new RelayCommand(ChangeOpacityMethod, CanChangeAction);
            changeShapeStrokeColor = new RelayCommand(ChangeStrokeColorMethod, CanChangeAction);
            changeStrokeWidth = new RelayCommand(ChangeStrokeWidthMethod, CanChangeAction);
            changeShapeLocation = new RelayCommand(ChangeLocationMethod, CanChangeAction);

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
        /// Property that initialize basic tools
        /// </summary>
        public RelayCommand Initialize => initialize;
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

        /// <summary>
        /// Property that enable to interact with CanApplyChanging command
        /// </summary>
        public RelayCommand CanApplyChanging => canApplyChanging;
        /// <summary>
        /// Property that enable to interact with ChangeShapeColor command
        /// </summary>
        public RelayCommand ChangeShapeColor => changeShapeColor;
        /// <summary>
        /// Property that enable to interact with ChangeShapeOpacity command
        /// </summary>
        public RelayCommand ChangeShapeOpacity => changeShapeOpacity;
        /// <summary>
        /// Property that enable to interact with ChangeShapeStrokeColor command
        /// </summary>
        public RelayCommand ChangeShapeStrokeColor => changeShapeStrokeColor;
        /// <summary>
        /// Property that enable to interact with ChangeStrokeWidth command
        /// </summary>
        public RelayCommand ChangeStrokeWidth => changeStrokeWidth;
        /// <summary>
        /// Property that enable to interact with ChangeShapeLocation command
        /// </summary>
        public RelayCommand ChangeShapeLocation => changeShapeLocation;
        #endregion


        // METHODS
        private void InitializeMethod(object o)
        {
            mainWindow = (Window)o;

            mainWindow.KeyDown += KeyDown;
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (SelectedShape == null) return;

            int xShift = 0, yShift = 0;

            if (e.Key == Key.Up) yShift = -5;
            else if (e.Key == Key.Down) yShift = 5;

            if (e.Key == Key.Left) xShift = -5;
            else if (e.Key == Key.Right) xShift = 5;

            if (SelectedShape is Pentagon)
            {
                Pentagon penta = (Pentagon)SelectedShape;

                Point[] newPosition = penta.Points.Select(p => new Point(p.X + xShift, p.Y + yShift)).ToArray();

                manager.Execute(new Shapes.Commands.Pentagon.ChangeLocation(penta, newPosition));
            }
            else if (SelectedShape is Vertex)
            {
                Vertex v = (Vertex)SelectedShape;
                manager.Execute(new Shapes.Commands.Vertex.ChangeLocation(v, new Point()
                {
                    X = v.Location.X + xShift,
                    Y = v.Location.Y + yShift
                }));
            }

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedShape)));
        }

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

        private void ChangeColorMethod(object obj)
        {
            if (dialogService.ColorDialog())
            {
                manager.Execute(new Shapes.Commands.Pentagon.ChangeColor((Pentagon)selectedShape, dialogService.Color));
            }
        }
        private void ChangeLocationMethod(object obj)
        {
            manager.Execute(new Shapes.Commands.Pentagon.ChangeLocation((Pentagon)selectedShape, (Point[])obj));
        }
        private void ChangeOpacityMethod(object obj)
        {
            manager.Execute(new Shapes.Commands.Pentagon.ChangeOpacity((Pentagon)selectedShape, (double)obj));
        }
        private void ChangeStrokeColorMethod(object obj)
        {
            if (dialogService.ColorDialog())
            {
                manager.Execute(new Shapes.Commands.Pentagon.ChangeStrokeColor((Pentagon)selectedShape, dialogService.Color));
            }
        }
        private void ChangeStrokeWidthMethod(object obj)
        {
            manager.Execute(new Shapes.Commands.Pentagon.ChangeStrokeWidth((Pentagon)selectedShape, (double)obj));
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
        private bool CanChangeAction(object obj)
        {
            return selectedShape != null && selectedShape is Pentagon;
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
