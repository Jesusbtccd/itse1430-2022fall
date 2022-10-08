//Jesus Bustillos
//ITSE-1430.Fall
//08/3/2022


using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

string accountName;
string processor;
string memory;
string cart;
//int releaseYear = 1900;
//string rating = "";
bool isClassic = false;


DisplayInformation();
//DisplayprocessorMenu();



void DisplayInformation ()
{
    Console.WriteLine("Jesus Bustillos");
    Console.WriteLine("PC Builder");
    Console.WriteLine("ITSE 1430-Fall 2022");
    Console.WriteLine("09/21/2022");
}

var done = false;
do
{
    //type inferencing - compiler figures out type based upon context
    //MenuOption input = DisplayMenu();
    //var input = DisplayMenu();
    //Console.WriteLine();
    switch (DisplayMenu())
    {

        case MenuOption.Add: AddProcessor(); break;
        case MenuOption.Edit: EditCart(); break;
        case MenuOption.View: ViewCart(); break;
        case MenuOption.Delete: DeleteItem(); break;
        case MenuOption.Quit: done = Exit(); break;

    };

} while (!done);




DisplayMenu();

AddProcessor();

//Menu();

MenuOption DisplayMenu ()
{
    Console.WriteLine();
    //Console.WriteLine("----------");
    Console.WriteLine("".PadLeft(10, '-'));
    Console.WriteLine("A)dd Processor");
    Console.WriteLine("E)dit Cart");
    Console.WriteLine("V)iew Cart");
    Console.WriteLine("D)elete Item");
    Console.WriteLine("Q)uit");



    do
    {

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.A: Console.WriteLine(); return MenuOption.Add;
            case ConsoleKey.E: Console.WriteLine(); return MenuOption.Edit;
            case ConsoleKey.V: Console.WriteLine(); return MenuOption.View;
            case ConsoleKey.D: Console.WriteLine(); return MenuOption.Delete;
            case ConsoleKey.Q: Console.WriteLine(); return MenuOption.Quit;

            default: Error("Please enter valid option"); break;
        };
    } while (true);
}



////functions


bool ReadBoolean ( string message )
{
    Console.Write(message);

    //Looking for y/n
    do
    {
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Y)
            return true;
        else if (key.Key == ConsoleKey.N)
            return false;
    } while (true);
    //TODO:ERROR
    //return false;
    //ConsoleKeyInfo key = Console.ReadKey();
    //if (key.Key == ConsoleKey.Y)
    //    return true;
    //else if (key.Key == ConsoleKey.N)
    //    return false;

    //return false;
}

int ReadInt32 ( string message, int minimumValue, int maximumValue )
{
    Console.Write(message);

    do
    {
        string value = Console.ReadLine();
        if (Int32.TryParse(value, out int result))
        {
            if (result >= minimumValue && result <= maximumValue)
                return result;
        };



        Console.WriteLine("Value must be between " + minimumValue + " and " + maximumValue);
    } while (true);



}

string ReadString ( string message, bool required )
{

    Console.Write(message);

    while (true)

    {
        string value = Console.ReadLine();

        //if value is not empty or not required
        if (value != "" || !required)
            return value;
        Console.Write(message);

        //:value is empty and required
        Console.WriteLine("Value is required");
    };
}


void AddProcessor ()
{
    accountName = ReadString("Enter an account name:", true);

    processor = ReadProcessor("Please select a processor:");

    memory = ReadMemory("Please select memory type: ");

    //primaryStorage = ReadInt32("Enter the release year: ", 1900, 2100);
    //secondaryStorage = ReadString("Entering MPAA rating: ", true);

    //isClassic = ReadBoolean("Is this a classic? ");
}

void DeleteItem ()
{
    if (!ItemCart())
    {
        Error("No items in cart");
        return;
    };

    if (!ReadBoolean("Are you sure you want to remove item from cart (Y/N)?"))
        return;
    processor = "";
}

void EditCart ()
{
    if (!ItemCart())
    {
        Error("No items in cart");
        return;
    };


}

void ViewCart ()
{
    if (!ItemCart())
    {
        Error("No items in cart");
        return;
    };

    //Console.WriteLine(accountName);
    //Console.WriteLine($"{processor}");
    //Console.WriteLine($"{memory}");
    //Console.WriteLine($"{primaryStorage});
    //Console.WriteLine($"{secondaryStorage});

    //if (!String.IsNullOrEmpty(cart))
    //    Console.WriteLine(cart);
}


//string formatting
//option 1 - concatenaation 
//console.writeline(Lentgh; " + runLength + " mins");

//option 2 - string.format
//to string
//Console.WriteLine(releaseYear);
//Console.WriteLine(releaseYear.ToString());
//Console.WriteLine(description);
//Console.WriteLine("Length: "+ runLength + " mins");

//Console.WriteLine(String.Format("Length: {0} mins", runLength));
//Console.WriteLine("MPAA Rating: " + rating);
//Console.WriteLine("Classic: " + isClassic);

string ReadProcessor ( string message, string defaultValue = null )
{
    Console.WriteLine(message);

    if (!String.IsNullOrEmpty(defaultValue))

        Console.WriteLine($"0) Leave unchanged ({defaultValue})");
    Console.WriteLine("1)AMD Ryzen 9 5900X" + " " + "$1410");
    Console.WriteLine("2)AMD Ryzen 7 5700X" + " " + "$1270");
    Console.WriteLine("3)AMD Ryzen 5 5600X" + " " + "1200");
    Console.WriteLine("4)Intel i7-12700K" + " " + "1400");
    Console.WriteLine("5)Intel i5-12600K" + " " + "1280");

    do
    {
        string processor = null;

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        while (true)
        {
            case ConsoleKey.D0: processor = defaultValue; break;
            case ConsoleKey.D1: processor = "AMD Ryzen 9 5900X" + " " + "$1410"; break;
            case ConsoleKey.D2: processor = "AMD Ryzen 7 5700X" + " " + "$1270"; break;
            case ConsoleKey.D3: processor = "AMD Ryzen 5 5600X" + " " + "1200"; break;
            case ConsoleKey.D4: processor = "Intel i7-12700K" + " " + "1400"; break;
            case ConsoleKey.D5: processor = "Intel i5-12600K" + " " + "1280"; break;
//string value = Console.ReadLine();

        };
    }
}
//if value is not empty or not required
//if (value != "" || !required)
    //return value;

if (processor != null)
{
    Console.WriteLine(key.KeyChar);
    return processor;
    //:value is empty and required
    Console.WriteLine("Value is required");
};
    }

        } while (true) ;
        //return defaultValue;

}

string ReadMemory ( string message, string defaultValue = null )
{
    Console.WriteLine(message);


    if (!String.IsNullOrEmpty(defaultValue))

        Console.WriteLine($"0) Leave unchanged ({defaultValue})");
    Console.WriteLine("1) 8GB" + " " + "$30");
    Console.WriteLine("2) 16GB" + " " + "$40");
    Console.WriteLine("3) 32GB" + " " + "$90");
    Console.WriteLine("4) 64GB" + " " + "$410");
    Console.WriteLine("5) 128GB" + " " + "$600");

    do
        void MainMenu ()
        {
            string memory = null;
            //string title = "";
            processor = ReadString("Enter a title: ", true);

            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D0: memory = defaultValue; break;
                case ConsoleKey.D1: memory = "8GB" + " " + "$30"; break;
                case ConsoleKey.D2: memory = "16GB" + " " + "$40"; break;
                case ConsoleKey.D3: memory = "32GB" + " " + "$90"; break;
                case ConsoleKey.D4: memory = "64GB" + " " + "$410"; break;
                case ConsoleKey.D5: memory = "128GB" + " " + "$600"; break;
            };

            if (memory != null)
            {
                Console.WriteLine(key.KeyChar);
                return memory;
            };
        } while (true);
}
//string description = "";
description = ReadString("Enter an optional description: ", false);

//int runlength = 0; //in minutes


void ViewItem ()
{
    if (!ItemCart())
    {
        Error("No items in cart");
        return;
    };

    //Console.WriteLine(yourCart);
    //Console.WriteLine($"{})
}


void Error ( string message )
{
    Console.WriteLine(message);
}

bool ItemCart ()
{
    return true;
}

bool Confirm ( string message )
{
    Console.Write($"{message} (Y/N) ");

    do
    {
        var key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.Y: Console.WriteLine(key.KeyChar); return true;
            case ConsoleKey.N: Console.WriteLine(key.KeyChar); return false;
        };
    } while (true);
    //isClassic = ReadBoolean("Is this a classic? ");
}

bool Exit ()
{
    return Confirm("Are you sure you want exit menu? ");
}



