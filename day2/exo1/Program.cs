
static int getUserInput(string message){

    string? user_input;
    int val = 0;

    do
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();

        user_input = Console.ReadLine();
        

        if (int.TryParse(user_input,out val))
        {
            break;
            
        }else {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }

     
    } while (true);
    return val;
}

static string evenOrOdd(int number){
    if(number %2 == 0){
        return "Pair";
    }
    return "Impaire";
}

#region exo1 (tryparse)
int first_numer = getUserInput("Veulliez introduire un premier nombre entier");
int second_number = getUserInput("Veulliez introduire un second nombre entier");
int res = first_numer + second_number;
Console.WriteLine($"Result = {res}\nLe resultat est {evenOrOdd(res)}");

#endregion


// static int getUserInputParse(string message){
//     string? user_input; 
//     int val = 0;

//     do
//     {
//         Console.ForegroundColor = ConsoleColor.Red;
//         Console.WriteLine(message);
//         Console.ResetColor();

//         user_input = Console.ReadLine();
        
//         try
//         {
//             if (user_input is null){
//                 Console.WriteLine("Invalid input. Please enter a valid integer.");
//                 continue;
//             }
//             val = int.Parse(user_input );
//             break;
//         }
//         catch (FormatException)
//         {
//             Console.WriteLine("Invalid input. Please enter a valid integer.");
//             continue;
//         }
//     } while (true);
//     return val;

// }

// Thread.Sleep(200);
// Console.Clear();



// #region exo1 (parse)
// int first_val = getUserInputParse("Veulliez introduire un premier nombre entier");
// int second_val= getUserInputParse("Veulliez introduire un second nombre entier");

// Console.WriteLine($"Result = {first_val + second_val}\n Le resultat est {}");

// #endregion



