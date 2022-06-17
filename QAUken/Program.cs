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
                    //creating dictionary to store number and it's frequency
                    var number_Frequency = new Dictionary<int, int>();
                    foreach (var number in File.ReadLines(fileName))
                    {
                        var num = int.Parse(number)
                        //changing it's frequncy if repeated
                        if (number_Frequency.ContainsKey(num)) number_Quantity[num]++;
                        //or adding to dictionary if not defined
                        else
                            number_Frequency.Add(num, 1);
                    }

                    var lowScore = int.MaxValue;
                    var leader = int.MaxValue;

                    //running through numbers
                    foreach (var numberQ in number_Frequency)
                    {
                        //if first or lower than lowscore >> set it as leader
                        if (lowScore == int.MaxValue || lowScore > numberQ.Value)
                        {
                            lowScore = numberQ.Value;
                            leader = numberQ.Key;
                        }
                        // if same frequency set lower value as leader
                        else if (topScore == numberQ.Value)
                            leader = leader > numberQ.Key ? numberQ.Key : leader;
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
            Console.ReadKey();
        }
    }
}
