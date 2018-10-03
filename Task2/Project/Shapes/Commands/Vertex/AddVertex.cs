namespace Shapes.Commands.Vertex
{
    /// <summary>
    /// Class that represents command for adding vertex to pentagon
    /// </summary>
    public class AddVertex : Interfaces.ICommand
    {
        // FIELDS
        Models.Pentagon basePentagon;
        Models.Vertex target;

        //CONSTRUCTORS
        /// <summary>
        /// Basic constructor without parameters
        /// </summary>
        AddVertex()
        {

        }
        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="basePentagon">Pentagon in which will be added vertex</param>
        /// <param name="target">Added vertex</param>
        AddVertex(Models.Pentagon basePentagon, Models.Vertex target)
        {
            this.basePentagon = basePentagon;
            this.target = target;
        }

        // PROPERTIES
        /// <summary>
        /// Property that enable to interract with command name
        /// </summary>
        /// /// <returns>Command name</returns>
        public string Name
        {
            get
            {
                return "Vertex added";
            }
        }

        // METHODS
        /// <summary>
        /// Method that execute command
        /// </summary>
        public void Execute()
        {
            for (int i = 0; i < basePentagon.Points.Length; i++)
            {
                if (basePentagon.Points[i] == null)
                {
                    basePentagon.Points[i] = target.Location;
                    return;
                }
            }
        }
        /// <summary>
        /// Method that returns command execution
        /// </summary>
        public void UnExecute()
        {
            for (int i = 0; i < basePentagon.Points.Length; i++)
            {
                if (basePentagon.Points[i] == target.Location)
                {
                    basePentagon.Points[i] = new System.Windows.Point();// я не знаю як її занулити (null не допускає)
                    return;
                }
            }
        }
    }
}
