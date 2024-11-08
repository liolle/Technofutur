long fibonacci(int val){
    return fibonacciR(val,1,1);
}

long fibonacciR(int val,long n_1, long n_2){
    if (val<=0){
        return n_1;
    }

    return fibonacciR(val-1,n_2,n_1+n_2);
}


void getUserInput(){
    string? user_input;
    int val;

    do
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Pick a number ?");
        Console.ResetColor();
        user_input = Console.ReadLine();

        if (int.TryParse(user_input, out val))
        {
            break;
        }else {
            Console.WriteLine("Invalid input. Pick a valid interger");
        }

     
    } while (true);

    Console.WriteLine($"Answer: {fibonacci(val)}");

}

getUserInput();
