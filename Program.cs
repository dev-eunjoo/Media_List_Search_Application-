//Name and student number: Eunjoo Na, 000811369
//File date : 2020.10.30
//Program's purpose: show the Lists of Media according to the user's choice. 
//I, Eunjoo Na, 000811369 certify that this material is my original work.  
//No other person's work has been used without due acknowledgement.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab3A
{
    /// <summary>
    /// This class is the main class in the program and control the program
    /// </summary>
    class Program
    {
        //count for the  resizing the array
        private static int count;

        /// <summary>
        /// Main method of the class and it controls the program
        /// </summary>
        /// <param name="args">optional parameters which are not used for this program</param>
        static void Main(string[] args)
        {
            // create mediaCollection array to contains Media objects from Data file
            Media[] mediaCollection = ReadData();


            if (mediaCollection != null)
            {
                //resize the method array based on the size of the data file informations 
                Array.Resize(ref mediaCollection, count);
                //execute choice method for choosing options
                Choice(mediaCollection);

            }
            else
            {
                //Show the error 
                Console.WriteLine("Program terminated due to exception.  Click any key to close");
                Console.ReadKey();
            }

        }

        /// <summary>
        /// this method is for reading and getting information from the Data file
        /// </summary>
        /// <returns>array of Media</returns>
        private static Media[] ReadData()
        {
            //create mediaArray array with 100 size
            Media[] mediaArray = new Media[100];
            //create media list 
            List<Media> media = new List<Media>();
            //fs for FileStream 
            FileStream fs = null;
            //sr for StreamReader
            StreamReader sr = null;

            try
            {
                //create a new fs with Data.txt file opened
                fs = new FileStream(@"..\..\Data.txt", FileMode.Open);
                //create a new sr
                sr = new StreamReader(fs);

                // resultsList for storing the object information
                List<string> resultsList = new List<string>();

                while (!sr.EndOfStream)
                {
                    //endOfBlock for setting the end point of the every object information
                    string endOfBlock = "-----";

                    // Read the next line
                    string input = sr.ReadLine();

                    //check the endOfBlock is in the input
                    if (input != endOfBlock)
                    {
                        //add the input in the resultsList
                        resultsList.Add(input);

                    }
                    else
                    {
                        //oneMedia for get the specific Media information
                        Media oneMedia = CreateMedia(resultsList);
                        //add the oneMedia information in the media list
                        media.Add(oneMedia);
                        //clear the resultsList
                        resultsList.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                //log the error if get an exception
                Console.WriteLine($"Exception loading cars from file due to: {ex.Message}");
                return null;
            }
            finally
            {
                //close fs, sr
                if (fs != null)
                    fs.Close();
                if (sr != null)
                    sr.Close();
            }

            //set the count as the media list's size
            count = media.Count;
            //convert media list to the array and store in the mediaArray
            mediaArray = media.ToArray();
            //resize the mediaArray size as 100
            Array.Resize(ref mediaArray, 100);

            return mediaArray;

        }

        /// <summary>
        /// this method is about Choosing options in the menu 
        /// </summary>
        /// <param name="mediaArray">array of Media</param>
        /// <returns>true</returns>
        private static bool Choice(Media[] mediaArray)
        {
            //create Books list 
            List<Book> Books = new List<Book>();
            //create Movies list 
            List<Movie> Movies = new List<Movie>();
            //create Songs list 
            List<Song> Songs = new List<Song>();

            //store the object data in the assigned list according to the type of object
            foreach (Media element in mediaArray)
            {
                if (element is Book)
                {
                    Books.Add((Book)element);
                }
                else if (element is Movie)
                {
                    Movies.Add((Movie)element);
                }
                else if (element is Song)
                {
                    Songs.Add((Song)element);
                }
            }

            //diplay the menu option
            DisplayMenu();


            while (true)
            {
                //get the input from the user
                string input = Console.ReadLine();
                Console.WriteLine();

                //show the error if the user's input is wrong
                if ((int.TryParse(input, out int userSelection) == false) ||
                    userSelection < 1 || userSelection > 6)
                {
                    Console.WriteLine("\n*** Invalid Choice - Try Again ***\n");
                    Console.WriteLine("\nPress any key to continue . . .");
                    input = Console.ReadLine();
                    Console.Clear();
                    DisplayMenu();
                    continue;
                }

                //display the output according to the user's input
                if (userSelection == 1)
                {
                    //foreach statement of the Books list
                    foreach (Book element in Books)
                    {
                        //display the information
                        Console.WriteLine(element.ToString());
                        Console.WriteLine("-----------------------");
                    }
                }
                else if (userSelection == 2)
                {
                    foreach (Movie element in Movies)
                    {
                        Console.WriteLine(element.ToString());
                        Console.WriteLine("-----------------------");
                    }
                }
                else if (userSelection == 3)
                {
                    foreach (Song element in Songs)
                    {
                        Console.WriteLine(element.ToString());
                        Console.WriteLine("-----------------------");
                    }
                }
                else if (userSelection == 4)
                {
                    foreach (Media element in mediaArray)
                    {
                        Console.WriteLine(element.ToString());
                        Console.WriteLine("-----------------------");
                    }
                }
                else if (userSelection == 5)
                {
                    Console.Write("\nEnter a search string: ");

                    //get the keyword from the user
                    string keyword = Console.ReadLine();
                    Console.WriteLine();

                    //foreach statement of the mediaArray array
                    int keywordResultCount = 0;
                    foreach (Media element in mediaArray)
                    {
                        //check the keyword is found or not
                        if (element.Search(keyword))
                        {
                            //check the keyword is Book object
                            if (Books.Contains(element))
                            {
                                Book book = (Book)element;
                                Console.WriteLine(element.ToString());
                                //decrpt the Summary and display on the screen 
                                Console.WriteLine("Summary: " + book.Decrypt());
                                Console.WriteLine("-----------------------");
                                book.Encrypt();
                                keywordResultCount++;

                            }
                            //check the keyword is Movies object
                            else if (Movies.Contains(element))
                            {
                                Movie movie = (Movie)element;
                                Console.WriteLine(element.ToString());
                                //decrpt the Summary and display on the screen 
                                Console.WriteLine("Summary: " + movie.Decrypt());
                                Console.WriteLine("-----------------------");
                                movie.Encrypt();
                                keywordResultCount++;
                            }
                            //keyword is Song object
                            else
                            {
                                Console.WriteLine(element.ToString());
                                Console.WriteLine("-----------------------");
                                keywordResultCount++;
                            }
                        }
                        else
                        {
                            if (keywordResultCount > 0)
                            {
                                Console.WriteLine(keywordResultCount + " results are found");
                            }
                            else
                            {
                                Console.WriteLine("No search result");
                            }
                            break;
                        }
                        if (keywordResultCount == mediaArray.Length)
                        {
                            Console.WriteLine(keywordResultCount + " results are found");
                        }

                    }
                }
                else
                {
                    // if userSelection is 6, then exit
                    break;
                }
                Console.WriteLine("\nPress any key to continue . . .");

                string continueInput = Console.ReadLine();
                if (continueInput != null)
                {
                    //clear the screen and show the display menu 
                    Console.Clear();
                    DisplayMenu();
                }
            }
            return true;
        }

        /// <summary>
        /// this method is for displying menu
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine("Eunjoo's Media Collection");
            Console.WriteLine("1. List All Books");
            Console.WriteLine("2. List All Movies");
            Console.WriteLine("3. List All Songs");
            Console.WriteLine("4. List All Media");
            Console.WriteLine("5. Search All Media by Title");
            Console.WriteLine("\n6. Exit Program");
            Console.Write("\nEnter Choice : ");
        }

        /// <summary>
        /// This method is for create the specific media object
        /// </summary>
        /// <param name="info">List of string</param>
        /// 
        private static Media CreateMedia(List<string> info)
        {
            //neMedia for the return value
            Media newMedia;
            //values string array  for the splitting the value based on '|'
            string[] values = info[0].Split('|');
            //category string to store the value of index 0 of array
            string category = values[0];

            //check the category 
            if (category == "BOOK" || category == "MOVIE")
            {
                //title string to store the value of index 1 of array
                string title = values[1];
                //year string to store the value of index 2 of array
                string year = values[2];
                //arthor string to store the value of index 3 of array
                string arthor = values[3];
                //yearInt for the Parsing the string year
                int yearInt = short.Parse(year);
                //summary string for the storing the remaining data 
                string summary = "";
                for (int i = 1; i < info.Count; i++)
                {
                    summary += info[i] + Environment.NewLine;
                }

                if (category == "BOOK")
                {
                    //create the Book object and return
                    newMedia = new Book(title, yearInt, arthor, summary);
                    return newMedia;
                }
                else
                {
                    //create the Movie object and return
                    newMedia = new Movie(title, yearInt, arthor, summary);
                    return newMedia;
                }

            }
            else if (category == "SONG")
            {
                //title string to store the value of index 1 of array
                string title = values[1];
                //year string to store the value of index 2 of array
                string year = values[2];
                //album string to store the value of index 3 of array
                string album = values[3];
                //director string to store the value of index 3 of array
                string director = values[4];
                //yearInt for the Parsing the string year
                int yearInt = short.Parse(year);

                //create the Song object and return
                newMedia = new Song(title, yearInt, album, director);
                return newMedia;
            }

            return null;
        }

    }


}
