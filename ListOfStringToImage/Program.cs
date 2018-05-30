using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfStringToImage
{
    class Program
    {
        private const string _fileName = "List.txt";
        private const string _fileSavingLocation = "";
        private const char _splitter = '-';
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the program ...");
            Console.WriteLine("Reading file ...");

            try
            {
                string[] lines = System.IO.File.ReadAllLines(_fileName);

                Console.WriteLine("File read ...");
                Console.WriteLine("Creating images...");

                foreach (string line in lines)
                {
                    TextToImage t2image = new TextToImage();
                    string[] wordsInLine = line.Split(_splitter);
                    string lineInText = line.Substring(line.IndexOf(_splitter), line.Length - wordsInLine[0].Length);
                    lineInText = lineInText.Replace(_splitter.ToString(), string.Empty);
                    t2image.DrawAndSave(lineInText, _fileSavingLocation + wordsInLine[0] + ".jpg");
                    Console.WriteLine("\tCreating image for " + lineInText + " as " + wordsInLine[0] + ".jpg");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Specified file not found!");
            }
            catch (IOException ex)
            {
                Console.WriteLine("System IO error ouccured!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error ouccured! Details: ");
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }
}
