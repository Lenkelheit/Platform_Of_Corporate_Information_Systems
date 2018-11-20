namespace TaxiDriver
{
    /// <summary>
    /// Represents class that models Client
    /// </summary>
    public class Client
    {
        // PROPERTIES
        /// <summary>
        /// Property that defines the ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Property that defines the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property that defines the phone
        /// </summary>
        public string Phone { get; set; }
        // CONSTRUCTORS

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="name">The name of the client</param>
        /// <param name="phone">Client phone number</param>
        public Client(string name, string phone)
        {
            this.ID = -1;
            this.Name = name;
            this.Phone = phone;
        }
        /// <summary>
        /// Initialize a new instance of <see cref="Client"/>
        /// </summary>
        public Client()
        {
            this.ID = -1;
            this.Name = null;
            this.Phone = null;
        }
    }
}
