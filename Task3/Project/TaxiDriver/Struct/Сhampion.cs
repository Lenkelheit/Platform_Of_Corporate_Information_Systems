namespace TaxiDriver
{
    /// <summary>
    /// Represents struct that models Champion
    /// </summary>
    public struct Champion
    {
        // FIELDS
        private int number;
        private string name;
        private double score;
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
        /// Property that defines the name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
        /// <summary>
        /// Property that defines the score
        /// </summary>
        public double Score
        {
            get
            {
                return score;
            }
        }
        // CONSTRUCTORS
        /// <summary>
        /// Constructors with parameters
        /// </summary>
        /// <param name="number">Number champion's</param>
        /// <param name="name">Name champion's</param>
        /// <param name="score">Score champion's</param>
        public Champion(int number, string name, double score)
        {
            this.number = number;
            this.name = name;
            this.score = score;
        }
    }
}
