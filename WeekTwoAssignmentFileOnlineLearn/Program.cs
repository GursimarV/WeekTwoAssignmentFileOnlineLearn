/*
 Made by: Gursimar Virdi
 Date: September 20th, 2023
 I made this code with the help of the two resources given to me:
 https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/file-io-operationLinks 
 https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/create-file-compare
 and the previous lesson of the C# Fundamentals Guide
 */

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //This gets the directory path to for the text files to be read and written in latter code
        string directoryPath = @"C:\Users\gursi\OneDrive\Desktop\Real Class Work\Design App Programming\WeekTwoAssignmentFileOnlineLearn\TextFiles";

        ProcessFilesInDirectory(directoryPath);
        
        //To end the Build once the text has been read
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static Dictionary<char, int> CountCharacters(string filePath)
    {
        //The dictonary that counts the characters and the numbers in the text files
        Dictionary<char, int> charCounts = new Dictionary<char, int>();

        try
        {
            //This reads the text files that is director with the path and counts the amount of character and reads the first character
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    char character = (char)reader.Read();

                    //This makes sure to exclude the spaces to get accurate amount of characters and count
                    if (character != ' ') 
                    {
                        if (charCounts.ContainsKey(character))
                        {
                            charCounts[character]++;
                        }
                        else
                        {
                            charCounts[character] = 1;
                        }
                    }
                }
            }
        }
        //This is in case the files or the directory has issues so it will read out this message to that it has issues while reading the file
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while reading the file: {e.Message}");
        }

        return charCounts;
    }

    static void ProcessFilesInDirectory(string directoryPath)
    {
        //This makes sure that the directory path does exist and that they can reach to it
        if (Directory.Exists(directoryPath))
        {
            //This finds and get the files from the directory path that was shown above in Main
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                //This reads out the file name from where the directory list is coming from
                Console.WriteLine($"File: {Path.GetFileName(file)}");
                //This gets the files from the directory and will count the characters in the text files
                Dictionary<char, int> charCounts = CountCharacters(file);

                //This will write the character and the amount that are in the text files
                foreach (var entry in charCounts)
                {
                    Console.WriteLine($"Character: {entry.Key}, Count: {entry.Value}");
                }

                Console.WriteLine();
            }
        }
        else
        {
            //This will write a message saying that the directory is nowhere to be found 
            Console.WriteLine("The specified directory does not exist.");
        }
    }

}
