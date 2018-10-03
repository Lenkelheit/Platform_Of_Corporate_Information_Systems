namespace Shapes.Commands.Vertex
{
    public class AddVertex : Interfaces.ICommand
    {
        /// <summary>
        /// Property that enable to interract with command name
        /// <returns>Command name</returns>
        /// </summary>
        public string Name
        {
            get
            {
                return "Vertex added";
            }
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public void UnExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}
