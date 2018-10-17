using System.Linq;
using Shapes.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;

namespace Shapes.Models
{
    /// <summary>
    /// Provides algorithms to manipulate undo redo actions.
    /// </summary>
    public class UndoRedoManager : INotifyPropertyChanged
    {
        // FIELDS
        Stack<ICommand> undoStack;
        Stack<ICommand> redoStack;

        int undoItemCountPrev;
        int redoItemCountPrev;
        // CONSTRUCTORS
        /// <summary>
        /// Initialize a new instance of <see cref="Shapes.Models.UndoRedoManager"/>.
        /// </summary>
        public UndoRedoManager()
        {
            undoStack = new Stack<ICommand>();
            redoStack = new Stack<ICommand>();

            undoItemCountPrev = 0;
            redoItemCountPrev = 0;
        }
        // PROPERTIES
        /// <summary>
        /// Determine if undo action can be performed.
        /// </summary>
        public bool CanUndo => undoStack.Count > 0;
        /// <summary>
        /// Determine if redo action can be performed.
        /// </summary>
        public bool CanRedo => redoStack.Count > 0;
        /// <summary>
        /// Gets all undo items name.
        /// </summary>
        public IEnumerable<string> UndoItems => undoStack.Select(command => command.Name);
        /// <summary>
        /// Gets all redo items name.
        /// </summary>
        public IEnumerable<string> RedoItems => redoStack.Select(command => command.Name);
        // EVENTS
        /// <summary>
        /// Occurs when the <see cref="Shapes.Models.UndoRedoManager"/> state changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // METHODS
        internal void PopUndo()
        {
            if (CanUndo)
            {
                undoStack.Pop();
            }
        }
        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="command">
        /// An command that should be executed.
        /// </param>
        public void Execute(ICommand command)
        {
            RememberState();
            
            undoStack.Push(command);
            command.Execute();            
            redoStack.Clear();

            OnStateChanged();
        }
        /// <summary>
        /// If possible, undo a command.
        /// </summary>
        public void Undo()
        {
            if (CanUndo)
            {
                RememberState();

                ICommand command = undoStack.Pop();
                command.UnExecute();
                redoStack.Push(command);

                OnStateChanged();
            }
        }
        /// <summary>
        /// If possible, redo a command.
        /// </summary>
        public void Redo()
        {
            if (CanRedo)
            {
                RememberState();

                ICommand command = redoStack.Pop();
                command.Execute();
                undoStack.Push(command);

                OnStateChanged();
            }
        }
        /// <summary>
        /// If possible, undo commands.
        /// </summary>
        /// <param name="count">
        /// Number of commands that should be undone.
        /// </param>
        public void Undo(int count)
        {
            RememberState();

            ICommand command;
            for (int i = 0; i < count; ++i)
            {            
                if (!CanUndo) break;
            
                command = undoStack.Pop();
                command.UnExecute();
                redoStack.Push(command);
            }

            OnStateChanged();
        }
        /// <summary>
        /// If possible, redo commands.
        /// </summary>
        /// <param name="count">
        /// Number of commands that should be redone.
        /// </param>
        public void Redo(int count)
        {
            RememberState();

            ICommand command;
            for (int i = 0; i < count; ++i)
            {
                if (!CanRedo) break;
                
                command = redoStack.Pop();
                command.Execute();
                undoStack.Push(command);
            }

            OnStateChanged();
        }
        /// <summary>
        /// Clear manager
        /// </summary>
        public void Clear()
        {
            RememberState();

            redoStack.Clear();
            undoStack.Clear();

            OnStateChanged();
        }
        /// <summary>
        /// Raise the <see cref="Shapes.Models.UndoRedoManager.PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The instance of <see cref="System.ComponentModel.ProgressChangedEventArgs"/> that contains the event data.
        /// </param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        private void OnStateChanged()
        {
            if (undoItemCountPrev != undoStack.Count)
            {
                OnPropertyChanged(new PropertyChangedEventArgs("UndoItems"));
            }
            if (redoItemCountPrev != redoStack.Count)
            {
                OnPropertyChanged(new PropertyChangedEventArgs("RedoItems"));
            }

            if (undoItemCountPrev > 0 != CanUndo)
            {
                OnPropertyChanged(new PropertyChangedEventArgs("CanUndo"));
            }
            if (redoItemCountPrev > 0 != CanRedo)
            {
                OnPropertyChanged(new PropertyChangedEventArgs("CanRedo"));
            }
        }
        private void RememberState()
        {
            undoItemCountPrev = undoStack.Count;
            redoItemCountPrev = redoStack.Count;
        }
    }
}
