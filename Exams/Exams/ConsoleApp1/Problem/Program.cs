using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

        string input = Console.ReadLine();
        while (input != "end")
        {
            string[] inputParts = input.Split(" : ");
            string courseName = inputParts[0];
            string studentName = inputParts[1];

            if (!courses.ContainsKey(courseName))
            {
                courses.Add(courseName, new List<string>());
            }
            courses[courseName].Add(studentName);

            input = Console.ReadLine();
        }

        foreach (var courseName in courses.Keys)
        {
            Console.WriteLine($"{courseName}: {courses[courseName].Count}");
            foreach (var studentName in courses[courseName])
            {
                Console.WriteLine($"-- {studentName}");
            }
        }
    }
}
