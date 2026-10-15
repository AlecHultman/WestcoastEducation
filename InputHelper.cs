using System.Diagnostics.Contracts;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WestcoastEducation;

public static class InputHelper
{

    public static int ReadInt(string prompt)
    {

        while (true)
        {

            Console.WriteLine(prompt);



            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            Console.WriteLine("Du angav inte ett tal");
        }
    }

    public static DateOnly ReadDate(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);

            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly value))

            {
                return value;
            }

            Console.WriteLine("Ogiltigt datum, skriv exempelvis: 2026-01-01");

        }
    }

    public static string CheckIfNullOrWhitespace(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);

            string? answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                return answer;
            }

            Console.WriteLine("Du skrev inget, prova igen");



        }
    }





}
