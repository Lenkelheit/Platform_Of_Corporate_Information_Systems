namespace TaxiDriver
{
    /// <summary>
    /// Represents class that models Route.
    /// </summary>
    public struct Route
    {
        // FIELDS
        private string startStreet;
        private string endStreet;
        private System.TimeSpan time;
        private double price;
        // PROPERTIES
        /// <summary>
        /// Property that defines the start street.
        /// </summary>
        public string StartStreet
        {
            get
            {
                return startStreet;
            }
        }
        /// <summary>
        /// Property that defines the end street.
        /// </summary>
        public string EndStreet
        {
            get
            {
                return endStreet;
            }
        }
        /// <summary>
        /// Property that defines the time.
        /// </summary>
        public System.TimeSpan Time
        {
            get
            {
                return time;
            }
        }
        /// <summary>
        /// Property that defines the price.
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }
        }
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="startStreet"></param>
        /// <param name="endStreet"></param>
        /// <param name="time"></param>
        /// <param name="price"></param>
        public Route(string startStreet, string endStreet, System.TimeSpan time, double price)
        {
            this.startStreet = startStreet;
            this.endStreet = endStreet;
            this.time = time;
            this.price = price;
        }
    }
}
