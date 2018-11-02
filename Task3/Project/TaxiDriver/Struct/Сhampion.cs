namespace TaxiDriver
{
    /// <summary>
    /// Represents struct that models Champion
    /// </summary>
    public struct Сhampion
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
        /// <param name="number">number champion's</param>
        /// <param name="name">name champion's</param>
        /// <param name="score">score champion's</param>
        public Сhampion(int number, string name, double score)
        {
            this.number = number;
            this.name = name;
            this.score = score;
        }
    }
}
