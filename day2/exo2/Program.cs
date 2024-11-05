

static int getDifficulty(){

    string? user_input;

    do
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Veuiller sasir un niveau de difficulté: ");
        Console.ResetColor();

        user_input = Console.ReadLine();
        
        switch (user_input)
        {
            case "facile":
                return 50;
            case "moyen":
                return 100 ;
            case "difficile":
                return 200;
            default:
                continue;
        }
     
    } while (true);

}

static bool validateInput(int secret){

    string? user_input;
    int val;

    do
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Quel est le nombre mystère ?");
        Console.ResetColor();

        user_input = Console.ReadLine();
        

        if (int.TryParse(user_input,out val))
        {
            break;
            
        }else {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }

     
    } while (true);


    if(secret == val){
        Console.WriteLine($"Felicitation tu as trouvé le secret");
    }{
        Console.WriteLine($"Dommage le secret était {secret}");
    }
    
    return false;
}


Random rnd = new Random();
int num = rnd.Next(1,getDifficulty()+1);
validateInput(num);


