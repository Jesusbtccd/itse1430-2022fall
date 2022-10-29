//Jesus Bustillos
//ITSE-1430/Fall
//10/19/2022

using JesusBustillos.CharacterCreator;

string characterName;
string characterProfession;
string characterRace;
string characterBiography;
int characterStrength, characterIntelligence, characterAgility, characterConstitution, characterCharisma;
const int minAttribute = 1;
const int maxAttribute = 100;



DisplayInformation();


void DisplayInformation ()
{
    Console.WriteLine("Jesus Bustillos");
    Console.WriteLine("Character Creator");
    Console.WriteLine("ITSE 1430-Fall 2022");
    Console.WriteLine("10/19/2022");
}

var done = false;
do
{
    switch (DisplayMenu())
    {

        case MenuOption.Add: AddCharacter(); break;
        case MenuOption.Edit: EditCharacter(); break;
        case MenuOption.View: ViewCharacter(); break;
        case MenuOption.Delete: DeleteCharacter(); break;
        case MenuOption.Quit: done = Exit(); break;

        default: done = true; break;

    };

} while (!done);




DisplayMenu();

AddCharacter();

MenuOption DisplayMenu ()
{
    Console.WriteLine();
    Console.WriteLine("".PadLeft(10, '-'));
    Console.WriteLine("A)dd Character");
    Console.WriteLine("E)dit Character");
    Console.WriteLine("V)iew Character");
    Console.WriteLine("D)elete Character");
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


//bool ReadBoolean ( string message )
//{
//    Console.Write(message);

//    do
//    {
//        ConsoleKeyInfo key = Console.ReadKey();
//        if (key.Key == ConsoleKey.Y)
//            return true;
//        else if (key.Key == ConsoleKey.N)
//            return false;
//    } while (true);

//}

//int ReadInt32 ( string message, int minimumValue, int maximumValue )
//{
//    Console.Write(message);

//    do
//    {
//        string value = Console.ReadLine();
//        if (Int32.TryParse(value, out int result))
//        {
//            if (result >= minimumValue && result <= maximumValue)
//                return result;
//        };



//        Console.WriteLine("Value must be between " + minimumValue + " and " + maximumValue);
//    } while (true);



//}

string ReadString ( string message, bool required, string defaultValue = "" )
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


void AddCharacter ()
{
    characterName = ReadString("Enter an account name:", true);
    characterProfession = CharProfession("Please select a Profession:");
    characterRace = CharRace("Please select a Race: ");
    characterBiography = ReadString("Enter optional biographic details of the character:", false);
    characterStrength = CharAttributes("Enter Strength: ");
    characterIntelligence = CharAttributes("Enter Intelligence: ");
    characterAgility = CharAttributes("Enter Agility: ");
    characterConstitution = CharAttributes("Enter Constitution: ");
    characterCharisma = CharAttributes("Enter Charisma: ");

}

void DeleteCharacter ()
{
    if (!CharCreated())
    {
        Error("No character created.");
        return;
    };

    if (Confirm($"Are you sure you want to remove character '{characterName}'?"))
        return;
    characterName = "";
}

void EditCharacter ()
{
    if (!CharCreated())
    {
        Error("Character not created to Edit.");
        return;
    };

    characterName = ReadString($"Enter a Character name or ENTER to remain '{characterName}': ", false, characterName);
    characterProfession = CharProfession("Please select a Profession: ", characterProfession);
    characterRace = CharRace("Please select a Race: ", characterRace);
    characterBiography = ReadString("Enter optional biographic details of the character: ", false, characterBiography);
    characterStrength = CharAttributes("Enter Strength: ", false, characterStrength);
    characterIntelligence = CharAttributes("Enter Intelligence: ", false, characterIntelligence);
    characterAgility = CharAttributes("Enter Agility: ", false, characterAgility);
    characterConstitution = CharAttributes("Enter Constitution: ", false, characterConstitution);
    characterCharisma = CharAttributes("Enter Charisma: ", false, characterCharisma);



}

void ViewCharacter ()
{
    if (!CharCreated())
    {
        Error("No Character to view");
        return;
    };

    Console.WriteLine(characterName);
    Console.WriteLine($"{characterProfession}");
    Console.WriteLine($"{characterRace}");
    Console.WriteLine($"{characterBiography}");
    Console.WriteLine($"{characterStrength}");
    Console.WriteLine($"{characterIntelligence}");
    Console.WriteLine($"{characterAgility}");
    Console.WriteLine($"{characterConstitution}");
    Console.WriteLine($"{characterCharisma}");

    if (!String.IsNullOrEmpty(characterBiography))
        Console.WriteLine(characterBiography);
}

string CharProfession ( string message, string defaultValue = null )
{
    Console.WriteLine(message);

    if (!String.IsNullOrEmpty(defaultValue))
        Console.WriteLine($"0) Leave unchanged ({defaultValue})");

    Console.WriteLine("1)Fighter");
    Console.WriteLine("2)Hunter");
    Console.WriteLine("3)Priest");
    Console.WriteLine("4)Rogue");
    Console.WriteLine("5)Wizard");

    do
    {
        string characterProfession = null;

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)

        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0: characterProfession = defaultValue; break;
            case ConsoleKey.D1: characterProfession = "Fighter"; break;
            case ConsoleKey.D2: characterProfession = "Hunter"; break;
            case ConsoleKey.D3: characterProfession = "Priest"; break;
            case ConsoleKey.D4: characterProfession = "Rogue"; break;
            case ConsoleKey.D5: characterProfession = "Wizard"; break;
            

        };

        if (characterProfession != null)
        {
            Console.WriteLine(key.KeyChar);
            return characterProfession;
        };

    } while (true);

}


string CharRace ( string message, string defaultValue = null )
{
    Console.WriteLine(message);


    if (!String.IsNullOrEmpty(defaultValue))
        Console.WriteLine($"0) Leave unchanged ({defaultValue})");

    Console.WriteLine("1)Dwarf");
    Console.WriteLine("2)Elf");
    Console.WriteLine("3)Gnome");
    Console.WriteLine("4)Half Elf");
    Console.WriteLine("5)Human");

    do

    {
        string characterRace = null;

        var key = Console.ReadKey(true);
        switch (key.Key)


        {
            case ConsoleKey.NumPad0:
            case ConsoleKey.D0: characterRace = defaultValue; break;
            case ConsoleKey.D1: characterRace = "Dwarf"; break;
            case ConsoleKey.D2: characterRace = "Elf"; break;
            case ConsoleKey.D3: characterRace = "Gnome"; break;
            case ConsoleKey.D4: characterRace = "Half Elf"; break;
            case ConsoleKey.D5: characterRace = "Human"; break;
        };

        if (characterRace != null)
        {
            Console.WriteLine(key.KeyChar);
            return characterRace;
        };
    } while (true);
}


int CharAttributes ( string name )
{
    return CharAttributes(name, true, 0);
}

int CharAttributes ( string name, int defaultValue )
{
    return CharAttributes(name, false, defaultValue);
}

int CharAttributes ( string name, bool required, int defaultValue = 0 )
{
    var min = minAttribute;
    var max = maxAttribute;

    if (!required)
        Console.Write($"Enter a value for {name} ({min}-{max}) or press ENTER to leave unchanged (Current = {defaultValue}): ");
    else
        Console.Write($"Enter a value for {name} ({min}-{max}): "); ;

    do
    {
        var input = Console.ReadLine();
        if (String.IsNullOrEmpty(input) && !required)
            return defaultValue;

        if (Int32.TryParse(input, out var result) && result >= min && result <= max)
            return result;


        Error($"Value must be between {min} and {max}");
    } while (true);
}


void Error ( string message )
{
    Console.WriteLine(message);
}

bool CharCreated ()
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

