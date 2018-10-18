namespace DataControl.Services
{
    /// <summary>
    /// Represents service for work with xml files.
    /// </summary>
    public class XmlFileService : Interfaces.IFileService
    {
        // METHODS
        /// <summary>
        /// Loads information from xml file.
        /// </summary>
        /// <param name="item">Object to loading.</param>
        /// <param name="fileName">The name of file.</param>
        public void Load(ref Shapes.Models.Canvas item, string fileName)
        {
            item.Clear();
            System.Xml.Serialization.XmlSerializer xmlFormat = new System.Xml.Serialization.XmlSerializer(typeof(Shapes.Models.Canvas),
                new System.Type[] { typeof(Shapes.Models.ShapeBase), typeof(Shapes.Models.Vertex), typeof(Shapes.Models.Pentagon) });

            using (System.IO.FileStream fStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                item = (Shapes.Models.Canvas)xmlFormat.Deserialize(fStream);
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
                System.Xml.Serialization.XmlSerializer xmlFormat = new System.Xml.Serialization.XmlSerializer(typeof(Shapes.Models.Canvas),
                    new System.Type[] { typeof(Shapes.Models.ShapeBase), typeof(Shapes.Models.Vertex), typeof(Shapes.Models.Pentagon) });

                using (System.IO.FileStream fStream = new System.IO.FileStream(fileName,
                    System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
                {
                    xmlFormat.Serialize(fStream, item);
                }
            }
            else
            {
                throw new System.ArgumentNullException("Canvas is null.");
            }
        }
    }
}
