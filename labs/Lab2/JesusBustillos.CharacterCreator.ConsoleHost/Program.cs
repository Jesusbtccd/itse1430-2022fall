//Jesus Bustillos
//ITSE-1430/Fall
//10/19/2022

ProgramInformation();


void ProgramInformation ()
{
    Console.WriteLine("Jesus Bustillos");
    Console.WriteLine("Character Creator");
    Console.WriteLine("ITSE 1430-Fall 2022");
    Console.WriteLine("10/19/2022");
    DisplayDivider();
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

    };

} while (!done);




DisplayMenu();


MenuOption DisplayMenu()
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





void DisplayDivider(int width = 80)
{
    Console.WriteLine("".PadLeft(width, '-'));
}