int getUserInput(string prompt_message,string err_message,Func<int,bool> validatePick){

    int pick=0;

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(prompt_message);
    Console.ResetColor();
    bool isValid = false;

    while (!isValid)
    {
       try
       {
        string? user_input;
        user_input = Console.ReadLine();
        pick = int.Parse(user_input);
        if(validatePick(pick)){
            isValid = true;
        }
        else {
            throw new Exception("Incorret intput");
        }
       }
       catch (System.Exception)
       {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine(err_message);
         Console.ResetColor();
       }
    }
   
    return pick;
}

int players_limit = getUserInput("Pick the number on players","Incorrect input, enter un integer between 1-10",(pick)=>{
    return pick >0 && pick <= 10;
});

int[] players = new int[players_limit];
double sum = 0;

for (int i = 0; i < players_limit; i++)
{
    int score = getUserInput($"What is the score for player {i+1}","Incorrect input, enter un integer",(pick)=>true);
    sum += score;
}



Console.WriteLine($"The score sum is {sum} and the score mean is {sum/players_limit}");
