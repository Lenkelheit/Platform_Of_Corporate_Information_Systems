using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Shapes.Models
{
    public class Canvas : IEnumerable<ShapeBase>, ICollection<ShapeBase>,  INotifyCollectionChanged
    {
        // PROPERTIES
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // maybe another collection if you want
        //public System.Collections.ObjectModel.ObservableCollection<ShapeBase> shapes { get; set; }

        // EVENTS
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        // METHODS
        public void Add(ShapeBase shape)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, ShapeBase shape)
        {
            throw new NotImplementedException();
        }
        public bool Remove(ShapeBase shape)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ShapeBase item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ShapeBase[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public int IndexOf(ShapeBase item)
        {
            throw new NotImplementedException();
        }
        // other methods that change collection

        public IEnumerator<ShapeBase> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }     
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
