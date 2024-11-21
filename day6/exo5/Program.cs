int n = 10;
string[] state = new string[n];
int position = 0;

void updateState(int prev_position,int next_position){
    state[prev_position] = " . ";
    state[next_position] = " O ";
}

bool[] getUserInput(){

    string? user_input;
    user_input = Console.ReadLine();
    int last_position = position;

    switch (user_input)
    {
        case "g":
            position--;
            if(position<0){
                position = n-1;
            }
            updateState(last_position,position);
            return [false,true];
        case "d":
            position = (position+1)%n;
            updateState(last_position,position);
            return [false,true];
        case "q":
            return [true,false];
        case "h":
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Make a choice\n - [g] move left\n - [d] move right\n - [q] quit");
            Console.ResetColor();
            return [false,false];
        default:
            return [false,false];
    }
    
}

void printState(){
    for (int i = 0; i < state.Length; i++)
    {
        Console.Write($"{state[i]}");
    }
    Console.Write("\n");
}

void play() {
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Make a choice\n - [g] move left\n - [d] move right\n - [q] quit");
    Console.ResetColor();
    for (int i = 0; i < n; i++)
    {
        state[i] = " . ";
    }
    state[position] = " O ";
    printState();

    bool[] game_state = getUserInput();
    if(game_state[0] && game_state[1]){
        printState();
    }

    while (!game_state[0])
    {
        if(game_state[1]){
            printState();
        }
        game_state=getUserInput();
    }

}

play();
