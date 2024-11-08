static int getDifficulty(){

    string? user_input;

    do
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Pick the difficulty: \n- easy [1-50]\n- medium [1-100]\n- hard [1-200]\n");
        Console.ResetColor();

        user_input = Console.ReadLine();
        
        switch (user_input)
        {
            case "easy":
                return 50;
            case "medium":
                return 100 ;
            case "hard":
                return 200;
            default:
                continue;
        }
     
    } while (true);

}

void play(int secret){

    string? user_input;
    int val = 0;

    while (val != secret)
    {
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
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
        if (secret>val){
            Console.WriteLine("secret is greather");

        }else if(secret<val) {
            Console.WriteLine("secret is smaller");
        }
    }
    Console.WriteLine("Congratualtion you have fount the secret");

    return ;
}

bool END_GAME_FLAG = false;


void promptReplay(){
    string? user_input;
    do
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Do you want to replay  [y/n]?");
        Console.ResetColor();

        user_input = Console.ReadLine();

        switch (user_input.ToLower())
        {
            case "y":
                return;
            case "n":
                END_GAME_FLAG = true;
                return;
            
            default:
                break;
        }

    } while (true);

}


while (!END_GAME_FLAG)
{
    Random rnd = new Random();
    int num = rnd.Next(1,getDifficulty()+1);
    play(num);
    promptReplay();
}




