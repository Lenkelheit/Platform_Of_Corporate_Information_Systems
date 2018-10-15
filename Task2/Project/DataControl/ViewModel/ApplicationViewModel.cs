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
                return currentFileName == null ? "Pentagon Editor" : System.IO.Path.GetFileName(currentFileName);
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
        /// Property that enable to interact with DeleteShape command
        /// </summary>
        public RelayCommand DeleteShape => deleteShape;
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
            OnPropertyChanged(new PropertyChangedEventArgs("Canvas"));
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

                    OnPropertyChanged(new PropertyChangedEventArgs("FileName"));
                    OnPropertyChanged(new PropertyChangedEventArgs("Canvas"));
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
                        OnPropertyChanged(new PropertyChangedEventArgs("FileName"));
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
            System.Windows.Application.Current.Shutdown();
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
            selectedShape = null;
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
                case "UndoItems": OnPropertyChanged(new PropertyChangedEventArgs("UndoActionNames")); break;
                case "RedoItems": OnPropertyChanged(new PropertyChangedEventArgs("RedoActionNames")); break;
            }
        }
    }
}
