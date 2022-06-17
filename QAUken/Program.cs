/*
- Create a C# script that can open up a text file (files can be found in src folder), and tell us the number that has repeated the fewest number of times. Each number is on it's own line and is an integer.
- If two numbers have the same frequency count, return the smaller of the two numbers.
- Solve the problem without using LINQ.
- Output example 1: File: 1.txt, Number: 32, Repetead: 3 times
- Print the output for all the files in a single run
- Create a repo on github and commit the files that you've staged in your local repository.
- Add a detailed instruction on how to setup/launch your project.
*/
using System;
using System.IO;
using System.Collections.Generic;

namespace QAUken
{
    class Program
    {
        static void Main()
        {
            try
            {
                var path = Directory.GetCurrentDirectory() + "/src";
                 Console.WriteLine(path);
                foreach (string fileName in Directory.GetFiles(path, "*.txt"))
                {
                    //creating dictionary to store number and quantity of it's repeats
                    var number_Quantity = new Dictionary<int, int>();
                    foreach (var number in File.ReadLines(fileName))
                    {
                        //changing it's quantity if repeated
                        if (number_Quantity.ContainsKey(int.Parse(number)))
                        {
                            number_Quantity[int.Parse(number)]++;
                        }
                        //or adding to dictionary if not defined
                        else
                            number_Quantity.Add(int.Parse(number), 1);
                    }

                    int topScore = 0;
                    int leader = 555;

                    //running through numbers
                    foreach (var numberQ in number_Quantity)
                    {
                        //if first or higher than topscore >> set it as high score
                        if (topScore == 0 || topScore < numberQ.Value)
                        {
                            topScore = numberQ.Value;
                            leader = numberQ.Key;
                        }
                        // if same set lower as leader
                        else if (topScore == numberQ.Value)
                            leader = leader > numberQ.Key ? leader : numberQ.Key;
                    }
                    Console.WriteLine($"File: {fileName} Number: {leader} Repeated: {topScore}");
                }
            }
            catch (IOException exception)
            {
                // Display error message if file could not be read
                Console.WriteLine("Oops, problem");
                Console.WriteLine(exception.Message);
            }

            // Application exits on user input
            Console.ReadKey();
        }
    }
}
