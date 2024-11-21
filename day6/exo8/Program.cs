string[] getUserInput(){
    string[] players = new string[8];
    int i = 0;
    string? name;

    for (; i < 8;)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Can you enter a name for the player [{i+1}]");
        Console.ResetColor();
        name = Console.ReadLine();
        if(name is not null){
            players[i++] = name;
        }
    }

    return players;
}


string[] pick(int num, String[] players){
    Random rand = new();
    String[] res = new string[num];
    Dictionary<int,bool>  picked = [];
    int i = 0;

    while (picked.Count<num)
    {
        int pick = rand.Next(0,players.Length);
        if(picked.ContainsKey(pick)){
            continue;
        }
        res[i] = players[pick];
        i++;
        picked.Add(pick,true);
    }

    return res;
}

string[] players = getUserInput();
Console.WriteLine("\nSemi-finalist");
string[] semi = pick(4,players);
for (int i = 0; i < semi.Length; i++)
{
    Console.WriteLine(semi[i]);
}

Console.WriteLine("\nfinalist");
string[] finalist = pick(2,semi);
for (int i = 0; i < finalist.Length; i++)
{
    Console.WriteLine(semi[i]);
}

Console.WriteLine("\nWinner");
string[] winner = pick(1,finalist);
for (int i = 0; i < winner.Length; i++)
{
    Console.WriteLine(semi[i]);
}

int a = 1;
string aa = "";