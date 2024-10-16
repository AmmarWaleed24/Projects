// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
class Program2
{
    private static List<string> allWordsList = new List<string>();
    private static Stack<string> redoStack = new Stack<string>();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Type something 'undo' For Undo 'redo' For Redo 'exit': ");
            string input = Console.ReadLine();

            if (string.Equals(input, "undo", StringComparison.OrdinalIgnoreCase))
            {
                undo();
                readAllWordsList();
            }
            else if (string.Equals(input, "redo", StringComparison.OrdinalIgnoreCase))
            {
                redo();
                readAllWordsList();
            }
            else if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase)) return;
            else
            {
                TrackAllWords(input);
                readAllWordsList();
            }
        }

    }

    static void TrackAllWords(string input)
    {
        string[] allWordsArray = input.Split(' ');
        allWordsList.AddRange(allWordsArray);
        redoStack.Clear();

    }


    static void undo()
    {
        if (allWordsList.Count > 0)
        {
            redoStack.Push(allWordsList[allWordsList.Count - 1]);
            allWordsList.Remove(allWordsList[allWordsList.Count - 1]);
        }
    }

    static void redo()
    {
        if (redoStack.Count > 0)
        {
            allWordsList.Add(redoStack.Pop());
        }
    }

    static void readAllWordsList()
    {
        foreach (var item in allWordsList)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
        Console.WriteLine("-----------------");
    }
}