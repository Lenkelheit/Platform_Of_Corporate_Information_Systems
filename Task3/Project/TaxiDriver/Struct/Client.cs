namespace TaxiDriver
{
    /// <summary>
    /// Represents class that models Client.
    /// </summary>
    public struct Client
    {
        // FILEDS
        private string name;
        private string phone;
        // PROPERTIES
        /// <summary>
        /// Property that defines the name.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
        /// <summary>
        /// Property that defines the phone.
        /// </summary>
        public string Phone
        {
            get
            {
                return phone;
            }
        }
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        public Client(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
    }
}
