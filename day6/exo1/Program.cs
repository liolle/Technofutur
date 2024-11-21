
int getUserInput(){

    string? user_input;
    int pick;

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Pick a natural number plus grand que 0");
    Console.ResetColor();
    user_input = Console.ReadLine();

    while (!int.TryParse(user_input,out pick))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Incorrect input: enter a valid integer");
        Console.ResetColor();
    }
    return pick;
}


List<int> siv(int num){
    List<int> primes = [];

    for (int i = 2; i < num; i++)
    {
        bool is_prime = true;
        foreach (int item in primes)
        {
            if(i%item == 0){
                is_prime = false;
            }
        }
        if(is_prime){
            primes.Add(i);
        }
    }

    return primes;
}

int pick = getUserInput();
int[] primes = [.. siv(pick)];
Console.Write($"[");
for (int i = 0; i < primes.Length; i++)
{
    Console.Write($"{primes[i]} {(i==primes.Length-1 ? " ":",")}");
}
Console.Write($"]\n");

