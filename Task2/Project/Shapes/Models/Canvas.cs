using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Shapes.Models
{
    /// <summary>
    /// Class that represents collection of shapes
    /// </summary>
    [System.Serializable]
    public class Canvas : IList<ShapeBase>, INotifyCollectionChanged
    {
        // FIELDS
        List<ShapeBase> shapes;

        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor without parameters
        /// </summary>
        public Canvas()
        {
            shapes = new List<ShapeBase>();
        }

        // PROPERTIES
        /// <summary>
        /// Property that enable to get count of shapes
        /// </summary>
        /// <returns>Count of shapes</returns>
        public int Count
        {
            get
            {
                return shapes.Count;
            }
        }
        /// <summary>
        /// Property that shows if canvas is only for read
        /// </summary>
        /// <returns>Is canvas only for read</returns>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Property that enable to get shapes collection
        /// </summary>
        /// <returns>Shapes collecton</returns>
        public IEnumerable<ShapeBase> Shapes
        {
            get
            {
                return shapes;
            }
        }

        // INDEXERS
        /// <summary>
        /// Indexer that enable to interract with collection elements
        /// </summary>
        /// <param name="index">Shape index in collection</param>
        /// <returns>Shape with present index</returns>
        /// <exception cref="System.IndexOutOfRangeException">Index out of range</exception>
        public ShapeBase this[int index]
        {
            get
            {
                return shapes[index];
            }
            set
            {
                shapes[index].PropertyChanged -= Canvas_PropertyChanged;
                shapes[index] = value;
                shapes[index].PropertyChanged += Canvas_PropertyChanged;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, index));
            }
        }

        // EVENTS
        /// <summary>
        /// Event that message about canvas property change
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        // METHODS
        /// <summary>
        /// Method that allow to add new shape to collection
        /// </summary>
        /// <param name="shape">Shape that should be added</param>
        public void Add(ShapeBase shape)
        {
            shapes.Add(shape);
            shape.PropertyChanged += Canvas_PropertyChanged;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, shape));
        }
        /// <summary>
        /// Method that allow to insert shape in collection
        /// </summary>
        /// <param name="index">Index where shape should be inserted</param>
        /// <param name="shape">Shape that should be inserted</param>
        /// <exception cref="System.IndexOutOfRangeException">Index out of range</exception>
        public void Insert(int index, ShapeBase shape)
        {
            shapes.Insert(index, shape);
            this[index].PropertyChanged += Canvas_PropertyChanged;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, shape));
        }
        /// <summary>
        /// Method that removes present shape
        /// </summary>
        /// <param name="shape">present shape</param>
        /// <returns>If shape was deleted</returns>
        public bool Remove(ShapeBase shape)
        {
            int index = shapes.IndexOf(shape);
            bool result = index != -1;
            if (result == true)
            {
                this.RemoveAt(index);
            }
            return result;
        }
        /// <summary>
        /// Method that remove shape with present index
        /// </summary>
        /// <param name="index">Index with which shape should be removed</param>
        /// <exception cref="System.IndexOutOfRangeException">Index out of range</exception>
        public void RemoveAt(int index)
        {
            shapes[index].PropertyChanged -= Canvas_PropertyChanged;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, shapes[index], index));
            shapes.RemoveAt(index);
        }
        /// <summary>
        /// Method that removes all shapes with present predicate
        /// </summary>
        /// <param name="match">Predicate with whitch shapes should be removed</param>
        /// <returns>Number of deleted items</returns>
        public int RemoveAll(System.Predicate<ShapeBase> match)
        {
            foreach (ShapeBase item in shapes)
            {
                if (match(item))
                {
                    item.PropertyChanged -= Canvas_PropertyChanged;
                }
            }
            int elementRemoved = shapes.RemoveAll(match);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            return elementRemoved;
        }
        /// <summary>
        /// Method that deletes all shapes in collection
        /// </summary>
        public void Clear()
        {
            foreach (ShapeBase item in shapes)
            {
                item.PropertyChanged -= Canvas_PropertyChanged;
            }
            shapes.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        /// <summary>
        /// Method that check if collection contains present item
        /// </summary>
        /// <param name="item">Shape should be checked</param>
        /// <returns>If collection contains item</returns>
        public bool Contains(ShapeBase item)
        {
            return shapes.Contains(item);
        }
        /// <summary>
        /// Count number of element that satisfy condition
        /// </summary>
        /// <param name="predicate">
        /// The condition that should be satisfied
        /// </param>
        /// <returns>
        /// Number of elements that satisfy condition
        /// </returns>
        public int CountIf(System.Predicate<ShapeBase> predicate)
        {
            int counter = 0;
            foreach (ShapeBase shape in shapes)
            {
                if (predicate(shape))
                {
                    ++counter;
                }
            }
            return counter;
        }
        /// <summary>
        /// Method that copy collection to present array started from present index
        /// </summary>
        /// <param name="array">Array where collection should be copied</param>
        /// <param name="arrayIndex">Index from which stated copiing</param>
        /// <exception cref="System.IndexOutOfRangeException">Index out of range</exception>
        public void CopyTo(ShapeBase[] array, int arrayIndex)
        {
            shapes.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Method that returns index of present item in collection
        /// </summary>
        /// <param name="item">Item should be founded</param>
        /// <returns>Index of item in collection</returns>
        public int IndexOf(ShapeBase item)
        {
            return shapes.IndexOf(item);
        }
        /// <summary>
        /// Method that returns collections enumerator
        /// </summary>
        /// <returns>Collections enumerator</returns>
        public IEnumerator<ShapeBase> GetEnumerator()
        {
            return shapes.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private void Canvas_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        /// <summary>
        /// Method that invokes CollectionChanged event
        /// </summary>
        /// <param name="e">Event argument</param>
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
    }
}
