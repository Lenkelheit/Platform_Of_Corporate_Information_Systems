using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Shapes.Models.Classes;
using Shapes.Models.Enums;
using Shapes.Models.Interfaces;

namespace Task1
{
    class Program
    {
        static readonly string DIRECTORY_SEPARATOR_STR 	= Path.DirectorySeparatorChar.ToString();
        static readonly string DIRECTORY_PATH 		        = string.Join(DIRECTORY_SEPARATOR_STR, AppDomain.CurrentDomain.BaseDirectory, "Resources");
        static readonly string FILE_PATH_FORMAT 	        = string.Join(DIRECTORY_SEPARATOR_STR, DIRECTORY_PATH, "{0}.txt");

        static readonly string READ_FILE_NAME 		= "data";
        static readonly string WRITE_FILE_NAME_1 	= "file1";
        static readonly string WRITE_FILE_NAME_2 	= "file2";

        static readonly string DIRECTORY_NOT_FOUND_MESSAGE 	= "Wrong path to resources folder.";
        static readonly string FILE_NOT_FOUND_MESSAGE 		= "Data file has not been found.";
        static readonly string FILE_READ_EXCEPTION_MESSAGE 	= "Do you want to END reading or SKIP this line?";
        static readonly string USER_WRONG_READ_ANSWER_MESSAGE 	= "Your answer is incorrect, please try again.";
        static readonly string USER_SKIP_READ_ANSWER 		= "SKIP";
        static readonly string USER_END_READ_ANSWER 		= "END";

        static void Main(string[] args)
        {
            if(!Directory.Exists(DIRECTORY_PATH))
            {
                Console.WriteLine(DIRECTORY_NOT_FOUND_MESSAGE);
                Console.ReadLine();
                return;
            }
            if (!File.Exists(string.Format(FILE_PATH_FORMAT, READ_FILE_NAME)))
            {
                Console.WriteLine(FILE_NOT_FOUND_MESSAGE);
                Console.ReadLine();
                return;
            }

            List<ShapeBase> shapes = new List<ShapeBase>();

            // Read the data in the List collection
            using (StreamReader streamReader = File.OpenText(string.Format(FILE_PATH_FORMAT, READ_FILE_NAME)))
            {
                while (!streamReader.EndOfStream)
                {
                    try
                    {
                        shapes.Add(ShapeBase.MakeInstance(streamReader));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(FILE_READ_EXCEPTION_MESSAGE);

                        string userAnswer = Console.ReadLine().Trim().ToUpper();

                        while (userAnswer != USER_SKIP_READ_ANSWER && userAnswer != USER_END_READ_ANSWER)
                        {
                            Console.WriteLine(USER_WRONG_READ_ANSWER_MESSAGE);
                            userAnswer = Console.ReadLine().Trim().ToUpper();
                        }

                        if (userAnswer == USER_SKIP_READ_ANSWER) continue;
                        else break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            }

            // Sort the collection ascending by the square and write the result into file1
            WriteToFile(shapes.OrderBy(shape => shape.GetSquare), WRITE_FILE_NAME_1);

            // Find shapes that lie in the third quarter of the coordinate plane and write them in a separate collection           
            LinkedList<ShapeBase> shapesThirdQuarter = 
                new LinkedList<ShapeBase>(shapes.Where(shape => shape.GetQuarter == CoordinateQuarters.Third));
            
            // Sort that collection decending by the perimeters and write the result into file2
            WriteToFile(shapesThirdQuarter.OrderByDescending(shape => shape.GetPerimeter), WRITE_FILE_NAME_2);
        }
        
        public static void WriteToFile<T>(IEnumerable<T> collection, string fileName) where T : IFileManager
        {
            using (StreamWriter streamWriter = new StreamWriter(string.Format(FILE_PATH_FORMAT, fileName)))
            {
                foreach (T item in collection)
                {
                    item.WriteToFile(streamWriter);
                }
            }
        }
    }
}
