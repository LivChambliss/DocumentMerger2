using System;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            try (args.Length > 3)
                //I'm not sure what goes here, or if the try argument is what i should be inputing, 
                //I am trying to do this by the sample code because I could not get my code to work,
                //and tbh I couldnt really get the sample code to work either 

            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <incput_file_n> <output_file>")
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text files as command line arguments.")
            }   // i see that the Console has a red squiggly, so I might've done this incorrectly but I think that
                //that I put this in the right spot, just don't know how to use it correctly

            //im thinking that everything else is the same? 


        }

        static string GetSourceTextFilePath(string prompt)
        {
            string sourceFilePath = "";

            Console.Write(prompt);

            do
            {
                sourceFilePath = Console.ReadLine();
                if (IsValidSourceFilePath(sourceFilePath)) return sourceFilePath;
                Console.Write("The provided source file path cannot be found. Enter again: ");
            } while (true);
        }

        static bool IsValidSourceFilePath(string sourceFilePath)
        {           
            if (!File.Exists(sourceFilePath))
            {
                return false;
            }

            return true;
        }

        static string GetDestinationFilePath(string filePath1, string filePath2)
        {
            
            string destinationFilePath = "";

            string file1Name = Path.GetFileNameWithoutExtension(filePath1);
            string file2Name = Path.GetFileNameWithoutExtension(filePath2);

            destinationFilePath = String.Format("{0}{1}.txt", file1Name, file2Name);

            return destinationFilePath;
        }

        static ulong MergeTextFiles(string sourceFilePath1, string sourceFilePath2, string destinationFilePath)
        {
            ulong characterCount = 0;

            StreamReader reader = null;
            StreamWriter writer = null;

            // https://www.geeksforgeeks.org/c-sharp-arrays/
            string[] sourceFilePaths = new string[2] { sourceFilePath1, sourceFilePath2 };

            try
            {
                writer = new StreamWriter(destinationFilePath);

                foreach (string sourceFilePath in sourceFilePaths)
                {
                    reader = new StreamReader(sourceFilePath2);

                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                        characterCount = characterCount + (ulong)line.Length;
                    }

                    reader.Close();
                }

                return characterCount;
            }
            catch (Exception ex)
            {               
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}