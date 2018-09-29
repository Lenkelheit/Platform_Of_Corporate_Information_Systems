using Shapes.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;

namespace Shapes.Models
{
    public class UndoRedoManager : INotifyPropertyChanged
    {
        // PROPERTIES
        public bool CanUndo
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public bool CanRedo
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public IEnumerable<string> UndoItems
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public IEnumerable<string> RedoItems
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        // EVENTS
        public event PropertyChangedEventHandler PropertyChanged;

        // METHODS
        public void Execute(ICommand command)
        {
            throw new System.NotImplementedException();
        }
        public void Undo()
        {
            throw new System.NotImplementedException();
        }
        public void Redo()
        {
            throw new System.NotImplementedException();
        }

        public void Undo(int count)
        {
            throw new System.NotImplementedException();
        }
        public void Redo(int count)
        {
            throw new System.NotImplementedException();
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
