//Name and student number: Eunjoo Na, 000811369
//File date : 2020.10.30
//Program's purpose: show the Lists of Media according to the user's choice. 
//I, Eunjoo Na, 000811369 certify that this material is my original work.  
//No other person's work has been used without due acknowledgement.

namespace Lab3A
{
    /// <summary>
    /// This class is the Song class in the program 
    /// </summary>
    class Song : Media
    {
        //Album property
        public string Album { get; set; }
        //Artist property
        public string Artist { get; set; }

        /// <summary>
        /// Song constructor
        /// </summary>
        /// <param name="title">title name</param>
        /// <param name="year">released year</param>
        /// <param name="album">song album name</param>
        /// <param name="artist">artist name</param>
        public Song(string title, int year, string album, string artist) : base(title, year)
        {
            Album = album;
            Artist = artist;
        }

        /// <summary>
        /// ToString method for the Song information output
        /// </summary>
        /// <returns>Song information</returns>
        public override string ToString()
        {
            return $"SONG Title : {Title}" + "\n" + $"Album : {Album} ({Year})" + "\n" + $"Artist: {Artist}";
        }
    }
}
