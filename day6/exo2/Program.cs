int getUserInput(){

    string? user_input;
    int pick;

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Pick an integer greater than 0");
    Console.ResetColor();
    user_input = Console.ReadLine();

    while (!int.TryParse(user_input,out pick) && pick>0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Incorrect input: enter a valid integer");
        Console.ResetColor();
    }
    return pick;
}

int pick = getUserInput();
int[] table = new int[pick];



for (int i = 0; i < pick; i++)
{
    table[i] = (int) Math.Pow(2,i+1);
}


Console.Write($"[");
for (int i = 0; i < table.Length; i++)
{
    if(i!=0 && i%8==0){
        Console.Write($"\n");
    }
    Console.Write($" {table[i]}{(i==table.Length-1 ?"":", ")}");

}
Console.Write($" ]\n");