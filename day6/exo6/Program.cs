Dictionary<string,string> win_match_up = new()
{
    { "pierre", "ciseaux" },
    { "papier", "pierre" },
    { "ciseaux", "papier" }
};

Dictionary<string,int>  score = new()
{
    { "win", 0},
    { "lost", 0},
    { "draw", 0}
};

string[] choises = ["pierre","papier","ciseaux"];

string getUserInput(){
    Random rand = new();
    string? user_pick;
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Make a choice\n - pierre\n - papier\n - ciseaux\n - [q] quit");
    Console.ResetColor();
    user_pick = Console.ReadLine();
    bool isValid = false;

    while (!isValid)
    {
        switch (user_pick)
        {
            case "pierre":
                isValid = true;
                break;
            case "papier":
                isValid = true;
                break;
            case "ciseaux":
                isValid = true;
                break;
            case "q":
                return "quit";
            default :
                user_pick = Console.ReadLine();
                break;
        }
        
    }

    string machine_pick = choises[rand.Next(1,3)];

    if (win_match_up[machine_pick].Equals(user_pick) )
    {
        Console.WriteLine($"You have lost: you chose {user_pick} Vs {machine_pick}");
        return "lost";
    }else if(win_match_up[user_pick].Equals(machine_pick)){
        Console.WriteLine($"Congratulation you have won: you chose {user_pick} Vs {machine_pick}");
        return "win";
    }else {
        Console.WriteLine($"It is a draw: {user_pick} Vs {machine_pick}");
        return "draw";
    }

}

void printScore(){
    Console.WriteLine($"Win: {score["win"]} - Lost: {score["lost"]} - Draw: {score["draw"]}");
}


void play() {
    bool end_game = false;
    string state ;
    printScore();

    while (!end_game)
    {   
        state = getUserInput();
        switch (state)
        {
            case "win":
                object sc = score[state];
                score[state] = (int)score[state] + 1;
                break;
            case "lost":
                score[state] = (int)score[state] + 1;
                break;
            case "draw":
                score[state] = (int)score[state] + 1;
                break;
            case "quit":
                end_game = true;
                break;
            default :
                break;
        }
        printScore();
    }
}

play();