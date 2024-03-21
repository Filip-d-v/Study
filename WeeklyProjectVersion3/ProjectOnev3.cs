using System;

class ProduktLista
{
    static void Main()
    {
        string[] produkter = new string[0];
        int index = 0;

        while (true)
        {
            Console.WriteLine("Ange produktnamn, exit för att avsluta:");
            string produktNamn = Console.ReadLine().Trim().ToLower();

            if (produktNamn == "exit")
            {
                break;
            }

            bool isValid = ValidName(produktNamn, out string errorMessage);

            if (isValid)
            {
                Array.Resize(ref produkter, index + 1); // Expandera array för antal element
                produkter[index] = produktNamn;
                index++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(produktNamn + " har lagts till.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ResetColor();
            }
        }

        Array.Sort(produkter, 0, index); // Sortera och visa angivna "produkter"
        Console.WriteLine("\nAlla produkter angivna:");
        for (int i = 0; i < index; i++)
        {
            Console.WriteLine(produkter[i]);
        }
    }
        // Kontroll block - kontrollerar så produktnamn är korrekt samt deklarerar errorMessage
    static bool ValidName(string productName, out string errorMessage)
    {
        errorMessage = "";

        // Etablera att det ska vara ett - mellan
        string[] parts = productName.Split('-');

        // Produktnamnet ska bestå av två delar
        if (parts.Length != 2)
        {
            errorMessage = "Produktnamnet måste vara i formatet: Bokstäver-Siffror.";
            return false;
        }

        string namePart = parts[0];
        string numberPart = parts[1];

        // kontrollera att första delen är bokstäver
        if (!namePart.All(char.IsLetter))
        {
            errorMessage = "Första delen av produktnamnet måste vara bokstäver.";
            return false;
        }

        // kontrollera att andra delen är siffror
        if (!int.TryParse(numberPart, out int number))
        {
            errorMessage = "Bara siffror efter -.";
            return false;
        }
        // kontrollera att nummret är mellan 200 och 500
        if (number < 200 || number > 500)
        {
            errorMessage = "Siffran måste vara mellan 200 och 500.";
            return false;
        }

        return true;
    }
}
