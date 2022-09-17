//Jesus Bustillos
//ITSE-1430.Fall
//08/3/2022

DisplayInformation();


void DisplayInformation()
{
    Console.WriteLine("Jesus Bustillos");
    Console.WriteLine("ITSE 1430 Fall");
    Console.WriteLine("09/21/2022");
}

DisplayMenu();

AddMovie();

MenuOption DisplayMenu ()
{
    Console.WriteLine();
    //Console.WriteLine("----------");
    Console.WriteLine("".PadLeft(10, '-'));
    Console.WriteLine("A)dd Movie");
    Console.WriteLine("E)dit Movie");
    Console.WriteLine("V)iew Movie");
    Console.WriteLine("D)elete Movie");
    Console.WriteLine("Q)uit");

    do
    {

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.A: return MenuOption.Add;
            case ConsoleKey.E: return MenuOption.Edit;
            case ConsoleKey.V: return MenuOption.View;
            case ConsoleKey.D: return MenuOption.Delete;
            case ConsoleKey.Q: return MenuOption.Quit;
        };

        

    } while (true);
}

var done = false;
do
{
    //type inferencing - compiler figures out type based upon context
    //MenuOption input = DisplayMenu();
    var input = DisplayMenu();
    Console.WriteLine();
    switch (input)
    {

        case MenuOption.Add:
        {
            AddMovie();
            break;
        }
        case MenuOption.Edit: EditMovie(); break;
        case MenuOption.View: ViewMovie(); break;
        case MenuOption.Delete: DeleteMovie(); break;
        case MenuOption.Quit: done = true; break;
    };
    //if (input =='A')
    //    AddMovie();
    //else if (input == 'E')
    //    EditMovie();
    //else if (input == 'V')
    //    ViewMovie();
    //else if (input == 'D')
    //    DeleteMovie();
    //else if (input == 'Q')
    //    break;

} while (true);


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
    return false;
}

string ReadString ( string message, bool required )
{
    //message = "Bob";
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




void AddMovie ()
{
    //string title = "";
    title = ReadString("Enter a title: ", true);

    //string description = "";
    description = ReadString("Enter an optional description: ", false);

    //int runlength = 0; //in minutes
    runLength = ReadInt32("Enter a run length (in minutes): ", 0, 300);

    releaseYear = ReadInt32("Enter the release year: ", 1900, 2100);
    rating = ReadString("Entering MPAA rating: ", true);

    isClassic = ReadBoolean("Is this a classic? ");
}

void ViewMovie ()
{
    if (title == "")
    {
        Console.WriteLine("' No movies avalable");
        return;
    };


    Console.WriteLine(title);

    //string formatting
    //option 1 - concatenaation 
    //console.writeline(Lentgh; " + runLength + " mins");

    //option 2 - string.format
    //to string
    //Console.WriteLine(releaseYear);
    Console.WriteLine(releaseYear.ToString());
    Console.WriteLine(description);
    //Console.WriteLine("Length: "+ runLength + " mins");

    Console.WriteLine(String.Format("Length: {0} mins", runLength));
    Console.WriteLine("MPAA Rating: " + rating);
    Console.WriteLine("Classic: " + isClassic);

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