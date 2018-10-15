using DataControl.Interfaces;
using DataControl.Services;
using DataControl.WpfCommands;
using Shapes.Models;
using System.ComponentModel;

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

        private bool dataChanged;
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

            dataChanged = false;
            currentFileName = "Pentagon Editor";

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
        }

        // PROPERTIES
        /// <summary>
        /// Returns name of file.
        /// </summary>
        public string FileName
        {
            get
            {
                return currentFileName;
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
            OnPropertyChanged(new PropertyChangedEventArgs("dataChanged"));
        }
        private void OpenFileMethod(object o)
        {
            try
            {
                if (dialogService.OpenFileDialog()) 
                {
                    currentFileName = dialogService.FilePath;
                    fileService.Load(canvas, currentFileName);
                    dialogService.ShowMessage("File is opened and data is loaded from it.");
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
                if (currentFileName.Contains("Pentagon Editor"))  
                {
                    if (dialogService.SaveFileDialog())
                    {
                        currentFileName = dialogService.FilePath;
                        fileService.Save(canvas, currentFileName);
                        dialogService.ShowMessage("Data is saved to file.");
                    }
                }
                else
                {
                    currentFileName = currentFileName.Remove(currentFileName.Length - 1, 1);
                    fileService.Save(canvas, currentFileName);
                    dialogService.ShowMessage("Data is saved to file.");
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
                    dialogService.ShowMessage("Data is saved to file.");
                }
            }
            catch (System.Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }
        private void ExitMethod(object o)
        {
            if (SavingBeforeClosingWindow() != System.Windows.MessageBoxResult.Cancel) 
            {
                ((System.Windows.Window)o).Close();
            }
        }
        private System.Windows.MessageBoxResult SavingBeforeClosingWindow()
        {
            if (currentFileName.Contains("*")) 
            {
                System.Windows.MessageBoxResult boxResult = System.Windows.MessageBox.Show("Save", "Saving", System.Windows.MessageBoxButton.YesNoCancel);
                if (boxResult == System.Windows.MessageBoxResult.Yes) 
                {
                    Save();
                }
                return boxResult;
            }
            return System.Windows.MessageBoxResult.None;
        }
        private void Save()
        {
            try
            {
                if (currentFileName.Contains("Pentagon Editor"))
                {
                    if (dialogService.SaveFileDialog())
                    {
                        currentFileName = dialogService.FilePath;
                        fileService.Save(canvas, currentFileName);
                        dialogService.ShowMessage("Data is saved to file.");
                    }
                }
                else
                {
                    currentFileName = currentFileName.Remove(currentFileName.Length - 1, 1);
                    fileService.Save(canvas, currentFileName);
                    dialogService.ShowMessage("Data is saved to file.");
                }
            }
            catch (System.Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }
        private void UpdateInterface()
        {
            IsSaved(!dataChanged);
        }
        private void IsSaved(bool isSaved)
        {
            bool hasStar = currentFileName.Contains("*");
            if (isSaved && hasStar)
            {
                currentFileName = currentFileName.Remove(currentFileName.Length - 1, 1);
            }
            else if (!isSaved && !hasStar)
            {
                currentFileName += "*";
            }
        }
        private void AddVertexMethod(object o)
        {
            Vertex target = new Vertex(/*mouse control*/);
            manager.Execute(new Shapes.Commands.Vertex.AddVertex(canvas, target, manager));
            OnPropertyChanged(new PropertyChangedEventArgs("dataChanged"));
        }
        private void DeleteShapeMethod(object o)
        {
            if (selectedShape is Pentagon)
            {
                manager.Execute(new Shapes.Commands.Pentagon.RemovePentagon(canvas, (Pentagon)selectedShape));
                OnPropertyChanged(new PropertyChangedEventArgs("dataChanged"));
            }
            else if (selectedShape is Vertex)
            {
                manager.Execute(new Shapes.Commands.Vertex.RemoveVertex(canvas, (Vertex)selectedShape));
                OnPropertyChanged(new PropertyChangedEventArgs("dataChanged"));
            }
            else
            {
                throw new System.NullReferenceException("Shape isn`t chosen!");
            }
        }
        private void UndoActionMethod(object o)
        {
            manager.Undo();
            OnPropertyChanged(new PropertyChangedEventArgs("dataChanged"));
        }
        private void RedoActionMethod(object o)
        {
            manager.Redo();
            OnPropertyChanged(new PropertyChangedEventArgs("dataChanged"));
        }
        private void UndoManyItemsMethod(object o)
        {
            manager.Undo((int)o + 1);
            OnPropertyChanged(new PropertyChangedEventArgs("dataChanged"));
        }
        private void RedoManyActionMethod(object o)
        {
            manager.Redo((int)o + 1);
            OnPropertyChanged(new PropertyChangedEventArgs("dataChanged"));
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

        // EVENT METHODS
        /// <summary>
        /// Notifies event <see cref="PropertyChanged"/> that some property is changed.
        /// </summary>
        /// <param name="e">Data for event <see cref="PropertyChanged"/>.</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dataChanged")
            {
                dataChanged = true;
                UpdateInterface();
            }
            PropertyChanged?.Invoke(this, e);
        }
    }
}
