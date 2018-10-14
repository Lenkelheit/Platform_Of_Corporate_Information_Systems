using System.Linq;

namespace DataControl.Services
{
    /// <summary>
    /// Represents service for work with xml files.
    /// </summary>
    public class XmlFileService : Interfaces.IFileService
    {
        /// <summary>
        /// Loads information from xml file.
        /// </summary>
        /// <param name="item">Object to loading.</param>
        /// <param name="fileName">The name of file.</param>
        public void Load(Shapes.Models.Canvas item, string fileName)
        {
            item.Clear();
            System.Xml.Serialization.XmlSerializer xmlFormat = new System.Xml.Serialization.XmlSerializer(item.Shapes.GetType(),
                new System.Type[] { typeof(Shapes.Models.Vertex), typeof(Shapes.Models.Pentagon) });

            using (System.IO.FileStream fStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                var list = (System.Collections.Generic.IEnumerable<Shapes.Models.ShapeBase>)xmlFormat.Deserialize(fStream);
                int elemCount = list.Count();
                for (int i = 0; i < elemCount; ++i)  
                {
                    item.Add(list.ElementAt(i));
                }
            }
        }
        /// <summary>
        /// Saves information to xml file.
        /// </summary>
        /// <param name="item">Object to saving.</param>
        /// <param name="fileName">The name of file.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when canvas is null.
        /// </exception>
        public void Save(Shapes.Models.Canvas item, string fileName)
        {
            if (item != null) 
            {
                System.Xml.Serialization.XmlSerializer xmlFormat = new System.Xml.Serialization.XmlSerializer(item.Shapes.GetType(),
                    new System.Type[] { typeof(Shapes.Models.Vertex), typeof(Shapes.Models.Pentagon) });

                using (System.IO.FileStream fStream = new System.IO.FileStream(fileName,
                    System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
                {
                    xmlFormat.Serialize(fStream, item.Shapes);
                }
            }
            else
            {
                throw new System.ArgumentNullException("Canvas is null.");
            }
        }
    }
}
