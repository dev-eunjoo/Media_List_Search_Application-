//Name and student number: Eunjoo Na, 000811369
//File date : 2020.10.30
//Program's purpose: show the Lists of Media according to the user's choice. 
//I, Eunjoo Na, 000811369 certify that this material is my original work.  
//No other person's work has been used without due acknowledgement.

namespace Lab3A
{
    /// <summary>
    /// This class is the Book class in the program 
    /// </summary>
    class Book : Media, IEncryptable
    {
        //Author property
        public string Author { get; set; }
        //Summary property
        public string Summary { get; set; }

        /// <summary>
        /// Book constructor
        /// </summary>
        /// <param name="title">title name</param>
        /// <param name="year">released year</param>
        /// <param name="author">author name</param>
        /// <param name="summary">book summary</param>
        public Book(string title, int year, string author, string summary) : base(title, year)
        {
            Author = author;
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
        /// ToString method for the Book information output
        /// </summary>
        /// <returns>Book information</returns>
        public override string ToString()
        {
            return $"BOOK Title : {Title} ({Year})" + "\n" + $"Author: {Author}";
        }

    }
    }
