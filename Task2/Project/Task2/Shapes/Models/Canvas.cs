using System;
using System.Collections;
using System.Collections.Generic;

namespace Shapes.Models
{
    public class Canvas : IEnumerable<ShapeBase> /*, INotifyCollectionChanged or (IChangable)*/
    {
        public ShapeBase SelectedShape { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<ShapeBase> shapes { get; set; }

        // METHODS
        public void SelectShape(int index)
        {
            throw new NotImplementedException();
        }
        public void Add(ShapeBase shape)
        {
            throw new NotImplementedException();
        }
        public void Remove(ShapeBase shape)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public void MoveX(ShapeBase shape, uint position)
        {
            throw new NotImplementedException();
        }
        public void MoveY(ShapeBase shape, uint position)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<ShapeBase> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }     
        // EVENTS
        /*
        MouseDown();
        MouseUp();
        MouseMove();
        KeyDown();
        KeyUp();
        */
    }
}
