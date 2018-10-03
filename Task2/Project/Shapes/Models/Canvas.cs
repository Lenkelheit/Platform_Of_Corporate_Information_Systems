using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Shapes.Models
{
    /// <summary>
    /// Class that represents collection of shapes
    /// </summary>
    [Serializable]
    public class Canvas : IList<ShapeBase>, INotifyCollectionChanged
    {
        List<ShapeBase> shapes;
        int count;
        bool isReadOnly;

        // PROPERTIES
        /// <summary>
        /// Property that enable to get count of shapes
        /// <returns>Count of shapes</returns>
        /// </summary>
        public int Count
        {
            get
            {
                return shapes.Count;
            }
        }
        /// <summary>
        /// Property that shows if canvas is only for read
        /// <returns>Is canvas only for read</returns>
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
        }
        /// <summary>
        /// Property that enable to get shapes collection
        /// <returns>Shapes collecton</returns>
        /// </summary>
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
        /// <returns>Shape with preset index</returns>
        /// <exception cref="System.ArgumentException">Wrong index</exception>
        public ShapeBase this[int index]
        {
            get
            {

                if (index > shapes.Count - 1 || index < 0)
                {
                    throw new ArgumentException("Wrong Index");
                }
                else
                {
                    return shapes[index];
                }
            }

            set
            {
                if (index > shapes.Count - 1 || index < 0)
                {
                    throw new ArgumentException("Wrong Index");
                }
                else
                {
                    shapes[index] = value;
                }
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
            count++;
        }
        /// <summary>
        /// Method that allow to insert shape in collection
        /// </summary>
        /// <param name="index">Index where shape should be inserted</param>
        /// <param name="shape">Shape that should be inserted</param>
        public void Insert(int index, ShapeBase shape)
        {
            if (index > count - 1 || index < 0)
            {
                throw new ArgumentException("Wrong argument");
            }
            else
            {
                shapes.Insert(index, shape);
            }
        }
        /// <summary>
        /// Method that removes preset shape
        /// </summary>
        /// <param name="shape">Preset shape</param>
        /// <returns>If shape was deleted</returns>
        public bool Remove(ShapeBase shape)
        {
            for (int i = 0; i < count; i++)
            {
                if (shapes[i] == shape)
                {
                    shapes.Remove(shape);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Method that remove shape with preset index
        /// </summary>
        /// <param name="index">Index with which shape should be removed</param>
        public void RemoveAt(int index)
        {
            if (index > count - 1 || index < 0)
            {
                throw new ArgumentException("Wrong argument");
            }
            else
            {
                shapes.RemoveAt(index);
            }
        }
        /// <summary>
        /// Method that removes all shapes with preset predicate
        /// </summary>
        /// <param name="match">Predicate with whitch shapes should be removed</param>
        /// <returns></returns>
        public int RemoveAll(Predicate<ShapeBase> match)
        {
            return shapes.RemoveAll(match);
        }
        /// <summary>
        /// Method that deletes all shapes in collection
        /// </summary>
        public void Clear()
        {
            shapes.Clear();
        }
        /// <summary>
        /// Method that check if collection contains preset item
        /// </summary>
        /// <param name="item">Shape should bechecked</param>
        /// <returns>If collection contains item</returns>
        public bool Contains(ShapeBase item)
        {
            return shapes.Contains(item);
        }
        /// <summary>
        /// Method that copy collection to preset array started from preset index
        /// </summary>
        /// <param name="array">Array where collection should be copied</param>
        /// <param name="arrayIndex">Index from which stated copiing</param>
        public void CopyTo(ShapeBase[] array, int arrayIndex)
        {
            shapes.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Method that returns index of preset item in collection
        /// </summary>
        /// <param name="item">Item should be founded</param>
        /// <returns>Index of item in collection</returns>
        public int IndexOf(ShapeBase item)
        {
            return shapes.IndexOf(item);
        }
        /// <summary>
        /// Method that returns collectiob enumerator
        /// </summary>
        /// <returns>Collectiob enumerator</returns>
        public IEnumerator<ShapeBase> GetEnumerator()
        {
            return shapes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
