namespace TaxiDriver
{
    /// <summary>
    /// Represents class that models Driver
    /// </summary>
    public class Driver
    {
        // FIELDS
        private string name;
        private string password;
        private double bestScore;
        private double totalScore;
        private double lastScore;
        // PROPERTIES
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
        /// Property that defines the password
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
        }
        /// <summary>
        /// Property that defines the best score
        /// </summary>
        public double BestScore
        {
            get
            {
                return bestScore;
            }
        }
        /// <summary>
        /// Property that defines the total score
        /// </summary>
        public double TotalScore
        {
            get
            {
                return totalScore;
            }
        }
        /// <summary>
        /// Property that defines the last score
        /// </summary>
        public double LastScore
        {
            get
            {
                return lastScore;
            }
            set
            {
                lastScore = value;

                totalScore += lastScore;
                if(lastScore > bestScore)
                {
                    bestScore = lastScore;
                }
            }
        }
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="name">driver's name</param>
        /// <param name="password">driver's password</param>
        /// <param name="bestScore">best score driver's</param>
        /// <param name="totalScore">total score driver's</param>
        public Driver(string name, string password, double bestScore, double totalScore)
        {
            this.name = name;
            this.password = password;
            this.bestScore = bestScore;
            this.totalScore = totalScore;
            this.lastScore = 0;
        }
    }
}
