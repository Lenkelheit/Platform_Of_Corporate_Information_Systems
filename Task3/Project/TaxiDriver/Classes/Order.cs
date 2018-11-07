namespace TaxiDriver
{
    /// <summary>
    /// Represents class that models Order
    /// </summary>
    public class Order
    {
        // FIELDS
        private int number;
        private Client client;
        private Route route;
        // PROPERTIES
        /// <summary>
        /// Property that defines the number
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }
        }
        /// <summary>
        /// Property that defines the Client
        /// </summary>
        public Client Client
        {
            get
            {
                return client;
            }
        }
        /// <summary>
        /// Property that defines the Route
        /// </summary>
        public Route Route
        {
            get
            {
                return route;
            }
        }
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="number">Order number</param>
        /// <param name="client">Client who accepted the refraction</param>
        /// <param name="route">Destination</param>
        public Order(int number, Client client, Route route)
        {
            this.number = number;
            this.client = client;
            this.route = route;
        }
    }
}
