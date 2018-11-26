namespace TaxiDriver
{
    /// <summary>
    /// Represents struct that models Route
    /// </summary>
    public class Route
    {
        // PROPERTIES
        /// <summary>
        /// Property that defines the ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Property that defines the ID of the start street
        /// </summary>
        public int? StartStreetID { get; set; }
        /// <summary>
        /// Property that defines the start street
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("StartStreetID")]
        public virtual Street StartStreet { get; set; }
        /// <summary>
        /// Property that defines the ID of the end street
        /// </summary>
        public int? EndStreetID { get; set; }
        /// <summary>
        /// Property that defines the end street
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("EndStreetID")]
        public virtual Street EndStreet { get; set; }
        /// <summary>
        /// Property that defines the time
        /// </summary>
        public System.TimeSpan Time { get; set; }
        /// <summary>
        /// Property that defines the price
        /// </summary>
        public double Price { get; set; }
        // CONSTRUCTORS
        /// <summary>
        /// Initialize a new instance of <see cref="Route"/>
        /// </summary>
        public Route()
        {
            this.ID = default(int);
            this.StartStreetID = default(int);
            this.EndStreetID = default(int);
            this.StartStreet = default(Street);
            this.EndStreet = default(Street);
            this.Time = default(System.TimeSpan);
            this.Price = default(double);
        }
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="startStreet">Start of the route.</param>
        /// <param name="endStreet">End of the route.</param>
        /// <param name="time">The duration of the trip.</param>
        /// <param name="price">Trip price.</param>
        public Route(string startStreet, string endStreet, System.TimeSpan time, double price)
        {
            this.ID = -1;
            this.StartStreetID = -1;
            this.EndStreetID = -1;
            this.StartStreet = new Street { ID = -1, Name = startStreet };
            this.EndStreet = new Street { ID = -1, Name = endStreet };
            this.Time = time;
            this.Price = price;
        }
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="startStreet">Start street of the route.</param>
        /// <param name="endStreet">End street of the route.</param>
        /// <param name="time">The duration of the trip.</param>
        /// <param name="price">Trip price.</param>
        public Route(Street startStreet, Street endStreet, System.TimeSpan time, double price)
        {
            this.ID = -1;
            this.StartStreetID = -1;
            this.EndStreetID = -1;
            this.StartStreet = startStreet;
            this.EndStreet = endStreet;
            this.Time = time;
            this.Price = price;
        }
    }
}
