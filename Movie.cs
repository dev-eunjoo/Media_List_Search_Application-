//Name and student number: Eunjoo Na, 000811369
//File date : 2020.10.30
//Program's purpose: show the Lists of Media according to the user's choice. 
//I, Eunjoo Na, 000811369 certify that this material is my original work.  
//No other person's work has been used without due acknowledgement.

namespace Lab3A
{
    /// <summary>
    /// This class is the Movie class in the program 
    /// </summary>
    class Movie : Media, IEncryptable
    {
        //Director property
        public string Director { get; set; }
        //Summary property
        public string Summary { get; set; }

        /// <summary>
        /// Movie constructor
        /// </summary>
        /// <param name="title">title name</param>
        /// <param name="year">released year</param>
        /// <param name="director">director name</param>
        /// <param name="summary">movie summary</param>
        public Movie(string title, int year, string director, string summary) : base(title, year)
        {
            Director = director;
            Summary = summary;
        }

        /// <summary>
        /// Encrypt method for encrypting the summary
        /// </summary>
        /// <returns>encrypted summary result</returns>
        public string Encrypt()
        {
            return Decrypt();
        }

        /// <summary>
        /// Decrypt method for decrypting the summary
        /// </summary>
        /// <returns>decrypted summary result</returns>
        public string Decrypt()
        {
            //array chart array for convering to char array from summary
            char[] array = Summary.ToCharArray();
            //value character
            char value;
            for (int i = 0; i < Summary.Length; i++)
            {
                //set the value as the index i of the Summary
                value = Summary[i];
                if ((value >= 'a' && value <= 'm') || (value >= 'A' && value <= 'M'))
                    array[i] = (char)(value + 13);
                else if ((value >= 'n' && value <= 'z') || (value >= 'N' && value <= 'Z'))
                    array[i] = (char)(value - 13);
            }
            //Summary string for converting the array to the string
            Summary = new string(array);
            return Summary;
        }

        /// <summary>
        /// ToString method for the Movie information output
        /// </summary>
        /// <returns>Movie information</returns>
        public override string ToString()
        {
            return $"MOVIE Title : {Title} ({Year})" + "\n" + $"Director: {Director}";
        }
    }
}
