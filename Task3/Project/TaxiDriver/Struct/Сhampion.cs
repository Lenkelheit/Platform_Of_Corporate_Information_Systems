namespace TaxiDriver
{
    /// <summary>
    /// Represents class that models Champion.
    /// </summary>
    public struct Сhampion
    {
        // FIELDS
        private int number;
        private string name;
        private double score;
        // PROPERTIES
        /// <summary>
        /// Property that defines the number.
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }
        }
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
        /// Property that defines the score.
        /// </summary>
        public double Score
        {
            get
            {
                return score;
            }
        }
        // CONSTROCTORS
        /// <summary>
        /// Constructors with parameters.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public Сhampion(int number, string name, double score)
        {
            this.number = number;
            this.name = name;
            this.score = score;
        }
    }
}
