//Jesus Bustillos
//ITSE-1430.Fall
//08/3/2022

Console.WriteLine("Jesus Bustillos");
Console.WriteLine("ITSE 1430 Fall");
Console.WriteLine("09/21/2022");



MainMenu();

bool ReadBoolean ( string message )
{
    Console.Write(message);

    //Looking for y/n
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Y)
        return true;
    else if (key.Key == ConsoleKey.N)
        return false;

    return false;
}

string input = "";
while (input != "Exit")
{
    Console.WriteLine();
    Console.WriteLine("Choose an option: ");
    Console.WriteLine("1: Processor");
    Console.WriteLine("2: Memory");
    Console.WriteLine("3: Exit");
    //Console.WriteLine("Press Exit");
    input = Console.ReadLine();
    if (input == "1")
    {

        //inline variable declarations
        //int result;
        //if (Int32.TryParse(value, out result))
        if (Int32.TryParse(value, out int result))
        {
            if (result >= minimumValue && result <= maximumValue)
                return result;
        };

        //if (false)
        //break;  //exit loop
        //continue; //exit iteration

        Console.WriteLine("Value must be between " + minimumValue + " and " + maximumValue);
    } while (true);

    string ReadString ( string message, bool required )
    {
        Console.Write(message);

        while (true)
        {
            string value = Console.ReadLine();

            //if value is not empty or not required
            if (value != "" || !required)
                return value;

            //:value is empty and required
            Console.WriteLine("Value is required");
        };
    }

    void MainMenu ()
    {
        //string title = "";
        processor = ReadString("Enter a title: ", true);

        //string description = "";
        description = ReadString("Enter an optional description: ", false);

        //int runlength = 0; //in minutes
        price1 = ReadInt32("Enter a run length (in minutes): ", 0, 300);

        price2 = ReadInt32("Enter the release year: ", 1900, 2100);
        rating = ReadString("Entering MPAA rating: ", true);

        isClassic = ReadBoolean("Is this a classic? ");
    }



}


//string input = "";
//while (input != "Exit")
//{
//    Console.WriteLine();
//    Console.WriteLine("Choose an option: ");
//    Console.WriteLine("1: Processor");
//    Console.WriteLine("2: Memory");
//    Console.WriteLine("3: Exit");
//    //Console.WriteLine("Press Exit");
//    input = Console.ReadLine();
//    if (input == "1")
//    {

//    }
//};