//Movie definition
using MovieLibrary;

//Movie movie = new Movie();
//movie.title = "Jaws";
//movie.releaseYear = 1977;

//string title = "";
//string description = "";
//int runLength = 0; //in minutes
//int releaseYear = 1900;
//string rating = "";
//bool isClassic = false;

DisplayInformation();


Movie movie =null;
//bool done = false;
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
            var theMovie = AddMovie();
            movie = theMovie.Clone();
            break;
        }
        case MenuOption.Edit: EditMovie(); break;
        case MenuOption.View: ViewMovie(movie); break;
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

} while (!done);

void DisplayInformation ()
{
    Console.WriteLine("Movie Library");
    Console.WriteLine("ITSE 1430 Sample");
    Console.WriteLine("Fall 2022");

}

   // DisplayMenu();

    //AddMovie();

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

            //if (key.Key == ConsoleKey.A)
            //    return 'A';
            //else if (key.Key == ConsoleKey.E)
            //    return 'E';
            //else if (key.Key == ConsoleKey.V)
            //    return 'V';
            //else if (key.Key == ConsoleKey.D)
            //    return 'D';
            //else if (key.Key == ConsoleKey.Q)
            //    return 'Q';

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
    }

int ReadInt32 ( string message, int minimumValue, int maximumValue )
    {
        Console.Write(message);

        do
        {
            string value = Console.ReadLine();

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
    //todo: fix return
Movie AddMovie ()
 {

        Movie movie = new Movie();
    //string title = "";
    //movie.title = ReadString("Enter a title: ", true);

    // movie.SetTitle(ReadString("Enter a title: ", true));
    movie.Title = ReadString("Enter a title: ", true);

    //string description = "";
    movie.Description = ReadString("Enter an optional description: ", false);

        //int runlength = 0; //in minutes
        movie.RunLength = ReadInt32("Enter a run length (in minutes): ", 0, 300);

        movie.ReleaseYear = ReadInt32("Enter the release year: ", 1900, 2100);
        movie.Rating = ReadString("Entering MPAA rating: ", true);

        movie.IsClassic = ReadBoolean("Is this a classic? ");

    return movie;
}

Movie GetSelectedMovie ()
{
    //HACK: For now
    return movie;
}

void DeleteMovie ()
{
    var selectedMovie = GetSelectedMovie ();

    //No movie
    if (selectedMovie == null)
        return;

    //Not confirmed
    if (!ReadBoolean("Are you sure you want to delete the movie '{selectedMovie} (Y/N)? "))
        return;

    //TODO: Delete movie
    movie = null;
}

void EditMovie ()
{ }

void ViewMovie (Movie movie)
{
    if (movie == null)
    {
        Console.WriteLine("No movies available");
        return;
    };

    //String formatting
    // Option 1 - concatenation
    // Console.WriteLine("Length: " + runLength + " mins");

    // Option 2 - String.Format
    // Console.WriteLine(String.Format("Length: {0} mins", runLength));

    // Option 3 - String interpolation
    // Console.WriteLine($"Length: {runLength} mins");
    //string someValue = $"Length = {runLength}";

    //ToString
    Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})");
    //Console.WriteLine(releaseYear);
    //Console.WriteLine(releaseYear.ToString());

    //Console.WriteLine("Length: " + runLength + " mins");
    //Console.WriteLine(String.Format("Length: {0} mins", runLength));
    //Console.WriteLine("Length: {0} mins", runLength);
    Console.WriteLine($"Length: {movie.RunLength} mins");

    Console.WriteLine($"Rated {movie.Rating}");
    //Console.WriteLine($"This {(isClassic ? "Is" : "Is Not")} a Classic");
    Console.WriteLine($"Is Classic: {(movie.IsClassic ? "Yes" : "No")}");
    Console.WriteLine(movie.Description);
}

//var movie = getselectedMovie();
//    {

//    return movie;
    //    if (movie.title == "")
    //        return;

    //    //Not confirmed
    //    if (!ReadBoolean("Are you sure you want to delete the movie (Y/N)?"))
    //        return;

    ////todo : delete movie 
    //    movie.title = "";
    //}

    //void EditMovie ()
    //{ }

    //void ViewMovie ( Movie movie)
    //{
    //    if (movie == null)
    //    {
    //        Console.WriteLine("' No movies avalable");
    //        return;
        //};


    //    //Console.WriteLine(movie.title);

    //    //string formatting
    //    //option 1 - concatenaation 
    //    //console.writeline(Lentgh; " + runLength + " mins");

    //    //option 2 - string.format
    //    //to string
    //    //Console.WriteLine(releaseYear);
    //    Console.WriteLine(movie._releaseYear.ToString());
    //    Console.WriteLine(movie.Description);
    //    //Console.WriteLine("Length: "+ runLength + " mins");

    //    Console.WriteLine(String.Format("Length: {0} mins", runLength));
    //    Console.WriteLine("MPAA Rating: " + movie._rating);
    //    Console.WriteLine("Classic: " + movie._isClassic);

    //}


//Movie definition
//string title = "";
//string description = "";
//int runLength = 0; //in minutes
//int releaseYear = 1900;
//string rating = "";
//bool isClassic = false;

//DisplayInformation();

//bool 
//var done = false;
//do
//{
//    //type inferencing - compiler figures out type based upon context
//    //MenuOption input = DisplayMenu();
//    var input = Displaymenu();
//    Console.WriteLine();
//    switch (input)
//    {

//        case MenuOption.Add:
//        {
//            AddMovie();
//            break;   
//        }
//        case MenuOption.Edit: EditMovie(); break;
//        case MenuOption.View: ViewMovie(); break;
//        case MenuOption.Delete: DeleteMovie(); break;
//        case MenuOption.Quit : done = true; break;
//    };
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

//} while (true);

//void DisplayInformation ()
//{
//    Console.WriteLine("Movie Library");
//    Console.WriteLine("ITSE 1430 Sample");
//    Console.WriteLine("Fall 2022");



//    DisplayMenu();

//    AddMovie();

//    MenuOption DisplayMenu ()
//    {
//    Console.WriteLine();
//Console.WriteLine("----------");
//    Console.WriteLine("".PadLeft(10, '-'));
//    Console.WriteLine("A)dd Movie");
//    Console.WriteLine("E)dit Movie");
//    Console.WriteLine("V)iew Movie");
//    Console.WriteLine("D)elete Movie");
//    Console.WriteLine("Q)uit");

//    do
//    {

//        ConsoleKeyInfo key = Console.ReadKey(true);
//        switch (key.Key)
//        {
//            case ConsoleKey.A: return MenuOption.Add;
//            case ConsoleKey.E: return MenuOption.Edit;
//            case ConsoleKey.V: return MenuOption.View;
//            case ConsoleKey.D: return MenuOption.Delete;
//            case ConsoleKey.Q: return MenuOption.Quit;
//        };

//        //if (key.Key == ConsoleKey.A)
//        //    return 'A';
//        //else if (key.Key == ConsoleKey.E)
//        //    return 'E';
//        //else if (key.Key == ConsoleKey.V)
//        //    return 'V';
//        //else if (key.Key == ConsoleKey.D)
//        //    return 'D';
//        //else if (key.Key == ConsoleKey.Q)
//        //    return 'Q';

//    } while (true);
//}

//////functions

//bool ReadBoolean ( string message )
//{
//    Console.Write ( message );

//    //Looking for y/n
//    do 
//    { 
//   ConsoleKeyInfo key = Console.ReadKey();
//    if (key.Key == ConsoleKey.Y)
//        return true;
//    else if (key.Key == ConsoleKey.N)
//        return false;
//    } while (true) ;
//    //TODO:ERROR
//    return false;
//}

//int ReadInt32 ( string message, int minimumValue, int maximumValue )
//{
//    Console.Write(message);

//    do
//    {
//        string value = Console.ReadLine();

//        //inline variable declarations
//        //int result;
//        //if (Int32.TryParse(value, out result))
//        if (Int32.TryParse(value, out int result))
//        {
//            if (result >= minimumValue && result <= maximumValue)
//            return result;
//        };

//        //if (false)
//            //break;  //exit loop
//            //continue; //exit iteration

//        Console.WriteLine("Value must be between " + minimumValue + " and " + maximumValue);
//    } while (true);



//}

//string ReadString ( string message, bool required )
//{
//    //message = "Bob";
//    Console.Write(message);

//    while (true)
//    { 
//         string value = Console.ReadLine();

//        //if value is not empty or not required
//        if (value != "" || !required)
//         return value;

//        //:value is empty and required
//        Console.WriteLine ("Value is required");
//    };
//}

//void AddMovie ()
//{
//    //string title = "";
//    title = ReadString("Enter a title: ", true);

//    //string description = "";
//    description = ReadString("Enter an optional description: ", false);

//    //int runlength = 0; //in minutes
//    runLength = ReadInt32("Enter a run length (in minutes): ", 0, 300);

//    releaseYear = ReadInt32("Enter the release year: ", 1900, 2100);
//    rating = ReadString("Entering MPAA rating: ", true);

//    isClassic = ReadBoolean("Is this a classic? ");
//}

//void DeleteMovie()
//{
//    if (title == "")
//        return;

//    //Not confirmed
//    if (!ReadBoolean("Are you sure you want to delete the movie (Y/N)?"))
//        return;

//    //todo : delete movie 
//    title = "";
//}

//void EditMovie()
//{ }

//void ViewMovie()
//{
//    if (title == "")
//    {
//        Console.WriteLine("' No movies avalable");
//        return;
//    };


//    Console.WriteLine(title);

//    //string formatting
//    //option 1 - concatenaation 
//    //console.writeline(Lentgh; " + runLength + " mins");

//    //option 2 - string.format
//    //to string
//    //Console.WriteLine(releaseYear);
//    Console.WriteLine(releaseYear.ToString());
//    Console.WriteLine(description);
//    //Console.WriteLine("Length: "+ runLength + " mins");

//    Console.WriteLine(String.Format("Length: {0} mins", runLength));
//    Console.WriteLine("MPAA Rating: " + rating);
//    Console.WriteLine("Classic: " + isClassic);

//}