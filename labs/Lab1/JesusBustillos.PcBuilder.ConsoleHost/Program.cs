//Jesus Bustillos
//ITSE-1430.Fall
//08/3/2022

string accountName = "";
string processor = "";
string memory = "";
string primaryStorage = "";
string secondaryStorage = "";
string graphicsCard = "";
string opSystem = "";
int userTotal = 0;


DisplayInformation();


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
    switch (DisplayMenu())
    {

        case MenuOption.Add: AddItems(); break;
        case MenuOption.Edit: EditCart(); break;
        case MenuOption.View: ViewCart(); break;
        case MenuOption.Delete: DeleteItems(); break;
        case MenuOption.Quit: done = Exit(); break;

    };

} while (!done);




DisplayMenu();

AddItems();

MenuOption DisplayMenu ()
{
    Console.WriteLine();
    Console.WriteLine("".PadLeft(10, '-'));
    Console.WriteLine("A)dd Items");
    Console.WriteLine("E)dit Cart");
    Console.WriteLine("V)iew Cart");
    Console.WriteLine("D)elete Items");
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


bool ReadBoolean ( string message )
{
    Console.Write(message);

    do
    {
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Y)
            return true;
        else if (key.Key == ConsoleKey.N)
            return false;
    } while (true);

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

        if (value != "" || !required)
            return value;
        Console.Write(message);
        Console.WriteLine("Value is required");
    };
}


void AddItems ()
{
    accountName = ReadString("Enter an account name:", true);
    processor = ReadProcessor("Please select a processor:");
    memory = ReadMemory("Please select memory type: ");
    primaryStorage = ReadStorage("Please select Primary storage capacity: ");
    secondaryStorage = ReadSecStorage("Please select Secondary storage capacity: ");
    graphicsCard = ReadCard("Please select a Graphics Card:");
    opSystem = ReadSystem("Please select an Operating System:");

}

void DeleteItems ()
{
    if (!ItemCart())
    {
        Error("No items in cart");
        return;
    };

    if (!ReadBoolean("Are you sure you want to remove items from cart (Y/N)?"))
        return;
    
}

void EditCart ()
{
    if (!ItemCart())
    {
        Error("No items in cart");
        return;
    };

    if (Confirm($"Are you sure you want to edit '{accountName}'?"))
        accountName = "";
       

}

void ViewCart ()
{
    if (!ItemCart())
    {
        Error("No items in cart");
        return;
    };

    Console.WriteLine(accountName);
    Console.WriteLine($"{processor}");
    Console.WriteLine($"{memory}");
    Console.WriteLine($"{primaryStorage}");
    Console.WriteLine($"{secondaryStorage}");
    Console.WriteLine($"Your total in cart is: {userTotal}");

}

string ReadProcessor ( string message, string defaultValue = null )
{
    Console.WriteLine(message);

    if (!String.IsNullOrEmpty(defaultValue))
        Console.WriteLine($"0) Leave unchanged ({defaultValue})");

    Console.WriteLine("1)AMD Ryzen 9 5900X" + " " + "$1410");
    Console.WriteLine("2)AMD Ryzen 7 5700X" + " " + "$1270");
    Console.WriteLine("3)AMD Ryzen 5 5600X" + " " + "$1200");
    Console.WriteLine("4)Intel i9-12900K" + " " + "$1590");
    Console.WriteLine("5)Intel i7-12700K" + " " + "$1400");
    Console.WriteLine("6)Intel i5-12600K" + " " + "$1280");

    do
    {
        string processor = null;

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)

        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0: processor = defaultValue; break;
            case ConsoleKey.D1: processor = "AMD Ryzen 9 5900X"; userTotal += 1410; break;
            case ConsoleKey.D2: processor = "AMD Ryzen 7 5700X"; userTotal += 1270; break;
            case ConsoleKey.D3: processor = "AMD Ryzen 5 5600X"; userTotal += 1200; break;
            case ConsoleKey.D4: processor = "Intel i9- 12900K"; userTotal += 1590; break;
            case ConsoleKey.D5: processor = "Intel i7-12700K"; userTotal += 1400; break;
            case ConsoleKey.D6: processor = "Intel i5-12600K"; userTotal += 1280; break;

        };

        if (processor != null)
        {
            Console.WriteLine(key.KeyChar);
            return processor;
        };

    } while (true);

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

    {
        string memory = null;

        var key = Console.ReadKey(true);
        switch (key.Key)


        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0: memory = defaultValue; break;
            case ConsoleKey.D1: memory = "8GB"; userTotal += 30; break;
            case ConsoleKey.D2: memory = "16GB"; userTotal += 40; break;
            case ConsoleKey.D3: memory = "32GB"; userTotal += 90; break;
            case ConsoleKey.D4: memory = "64GB"; userTotal += 410; break;
            case ConsoleKey.D5: memory = "128GB"; userTotal += 600; break;
        };

        if (memory != null)
        {
            Console.WriteLine(key.KeyChar);
            return memory;
        };
    } while (true);
}

string ReadStorage ( string message, string defaultValue = null )
{
    Console.WriteLine(message);

    if (!String.IsNullOrEmpty(defaultValue))
        Console.WriteLine($"0) Leave unchanged ({defaultValue})");

    Console.WriteLine("1)SSD 256 GB" + " " + "$90");
    Console.WriteLine("2)SSD 512 GB" + " " + "$100");
    Console.WriteLine("3)SSD 1 TB" + " " + "$125");
    Console.WriteLine("4)SSD 2 TB" + " " + "$230");


    do
    {
        string primaryStorage = null;

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)

        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0: primaryStorage = defaultValue; break;
            case ConsoleKey.D1: primaryStorage = "SSD 256 GB"; userTotal += 90; break;
            case ConsoleKey.D2: primaryStorage = "SSD 512 GB"; userTotal += 100; break;
            case ConsoleKey.D3: primaryStorage = "SSD 1 TB"; userTotal += 125; break;
            case ConsoleKey.D4: primaryStorage = "SSD 2 TB"; userTotal += 230; break;

        };

        if (primaryStorage != null)
        {
            Console.WriteLine(key.KeyChar);
            return primaryStorage;
            //:value is empty and required
            //Console.WriteLine("Value is required");
        };

    } while (true);
    //return defaultValue;

}

string ReadSecStorage ( string message, string defaultValue = null )
{
    Console.WriteLine(message);

    if (!String.IsNullOrEmpty(defaultValue))
        Console.WriteLine($"0) Leave unchanged ({defaultValue})");

    Console.WriteLine("1)None" + " " + "$0");
    Console.WriteLine("2)HDD 1 TB" + " " + "$40");
    Console.WriteLine("3)HDD 2 TB" + " " + "$50");
    Console.WriteLine("4)HDD 4 TB" + " " + "$70");
    Console.WriteLine("5)SSD 512 GB" + " " + "$100");
    Console.WriteLine("6)SSD 1 TB" + " " + "$125");
    Console.WriteLine("7)SSD 2 TB" + " " + "$230");


    do
    {
        string secondaryStorage = null;

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)

        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0: secondaryStorage = defaultValue; break;
            case ConsoleKey.D1: secondaryStorage = "None"; userTotal += 0; break;
            case ConsoleKey.D2: secondaryStorage = "HDD 1 TB"; userTotal += 40; break;
            case ConsoleKey.D3: secondaryStorage = "HDD 2 TB"; userTotal += 50; break;
            case ConsoleKey.D4: secondaryStorage = "HDD 4 TB"; userTotal += 70; break;
            case ConsoleKey.D5: secondaryStorage = "SSD 512 GB"; userTotal += 100; break;
            case ConsoleKey.D6: secondaryStorage = "SSD 1 TB"; userTotal += 125; break;
            case ConsoleKey.D7: secondaryStorage = "SSD 2 TB"; userTotal += 230; break;






            //if value is not empty or not required
            //if (value != "" || !required)
        };

        if (secondaryStorage != null)
        {
            Console.WriteLine(key.KeyChar);
            return secondaryStorage;
            //:value is empty and required
            // Console.WriteLine("Value is required");
        };

    } while (true);
    //return defaultValue;

}

string ReadCard ( string message, string defaultValue = null )
{
    Console.WriteLine(message);

    if (!String.IsNullOrEmpty(defaultValue))
        Console.WriteLine($"0) Leave unchanged ({defaultValue})");

    Console.WriteLine("1)None" + " " + "$0");
    Console.WriteLine("2)GeForce RTX 3070" + " " + "$580");
    Console.WriteLine("3)GeForce RTX 2070" + " " + "$400");
    Console.WriteLine("4)Radeon RX 6600" + " " + "$300");
    Console.WriteLine("5)Radeon RX 5600" + " " + "$325");


    do
    {
        string graphicsCard = null;

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)

        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0: graphicsCard = defaultValue; break;
            case ConsoleKey.D1: graphicsCard = "GeForce RTX 3070"; userTotal += 580; break;
            case ConsoleKey.D2: graphicsCard = "GeForce RTX 2070"; userTotal += 400; break;
            case ConsoleKey.D3: graphicsCard = "Radeon RX 6600"; userTotal += 300; break;
            case ConsoleKey.D4: graphicsCard = "Radeon RX 5600"; userTotal += 325; break;

        };

        if (graphicsCard != null)
        {
            Console.WriteLine(key.KeyChar);
            return graphicsCard;
            //:value is empty and required
            //Console.WriteLine("Value is required");
        };

    } while (true);
    //return defaultValue;

}

string ReadSystem ( string message, string defaultValue = null )
{
    Console.WriteLine(message);

    if (!String.IsNullOrEmpty(defaultValue))
        Console.WriteLine($"0) Leave unchanged ({defaultValue})");

    Console.WriteLine("1)Windows 11 Home" + " " + "$140");
    Console.WriteLine("2)Windows 11 Pro" + " " + "$160");
    Console.WriteLine("3)Windows 10 Home" + " " + "$150");
    Console.WriteLine("4)Windows 10 Pro" + " " + "$170");
    Console.WriteLine("5)Linux(Fedora)" + " " + "$20");
    Console.WriteLine("6)Linux(Red Hat)" + " " + "$60");


    do
    {
        string opSystem = null;

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)

        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0: opSystem = defaultValue; break;
            case ConsoleKey.D1: opSystem = "Windows 11 Home"; userTotal += 140; break;
            case ConsoleKey.D2: opSystem = "Windows 11 Pro"; userTotal += 160; break;
            case ConsoleKey.D3: opSystem = "Windows 10 Home"; userTotal += 150; break;
            case ConsoleKey.D4: opSystem = "Windows 10 Pro"; userTotal += 170; break;
            case ConsoleKey.D5: opSystem = "Linux(Fedora)"; userTotal += 20; break;
            case ConsoleKey.D6: opSystem = "Linux(Red Hat)"; userTotal += 60; break;


        };

        if (opSystem != null)
        {
            Console.WriteLine(key.KeyChar);
            return opSystem;
            //:value is empty and required
            //Console.WriteLine("Value is required");
        };

    } while (true);
    //return defaultValue;

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

}

bool Exit ()
{
    return Confirm("Are you sure you want exit menu? ");
}

