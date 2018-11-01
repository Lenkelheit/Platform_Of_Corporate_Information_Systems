namespace TaxiDriver
{
    /// <summary>
    /// Represents class that models Driver.
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
        /// Property that defines the password.
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
        }
        /// <summary>
        /// Property that defines the name best score.
        /// </summary>
        public double BestScore
        {
            get
            {
                return bestScore;
            }
        }
        /// <summary>
        /// Property that defines the total score.
        /// </summary>
        public double TotalScore
        {
            get
            {
                return totalScore;
            }
        }
        /// <summary>
        /// Property that defines the last score.
        /// </summary>
        public double LastScore
        {
            get
            {
                return lastScore;
            }
            set
            {
                if(value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("score can not be zero");
                }
                lastScore = value;
            }
        }
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="bestScore"></param>
        /// <param name="totalScore"></param>
        /// <param name="lastScore"></param>
        public Driver(string name, string password, double bestScore, double totalScore, double lastScore)
        {
            this.name = name;
            this.password = password;
            this.bestScore = bestScore;
            this.totalScore = totalScore;
            this.lastScore = lastScore;
        }
    }
}
