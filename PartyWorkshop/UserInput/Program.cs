using System;

public static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! - User Input Example");
        Console.WriteLine("Drücke bitte z oder e.");

        CharacterComparison();
        KeyComparison();
    }

    /// <summary>
    /// Read user input as string
    /// Check if string is bigger than one character
    /// Compare Character agains desired ones and repeat until happy.
    /// </summary>
    public static void CharacterComparison()
    {
        bool correctInput = false;

        while (!correctInput)
        {
            string input = Console.ReadLine();

            if (input.Length != 1 || input[0] != 'z' && input[0] != 'e')
            {
                Console.WriteLine("Das war kein richtiger input! Gib bitte GENAU z oder e an.");
                continue;
            }

            if (input[0] == 'z' || input[0] == 'e')
            {
                correctInput = true;
                Console.WriteLine($"Danke, dass du {input} angegeben hast!");
            }
        }
    }

    /// <summary>
    /// Read user input as key
    /// Switch Key until happy.
    /// </summary>
    public static void KeyComparison()
    {
        bool correctInput = false;
        ConsoleKey key = Console.ReadKey(true).Key;

        while (!correctInput)
        {
            switch (key)
            {
                case ConsoleKey.E:
                case ConsoleKey.Z:
                    correctInput = true;
                    Console.WriteLine($"Danke, dass du {key} gedrückt hast!");
                    break;

                default:
                    Console.WriteLine("Das war kein richtiger input! Gib drücke GENAU Z oder E.");
                    break;
            }
        }
    }
}
