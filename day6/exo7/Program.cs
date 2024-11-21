char[] getUserInput(){
    int i = 0;
    string? message;
    int offset = 0;

    do
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("What messge would you like to encrypt ?");
        Console.ResetColor();
        message = Console.ReadLine();
    } while (message is null);

    char[] char_message = message.ToCharArray();
    
    return char_message;
}



string[] letter = [];

char[] encrypt(char[] input){
    return [];
}

char[] decrypt(char[] input){
    return [];
}

char[] message = getUserInput();

for (int i = 0; i < message.Length; i++)
{
    Console.Write($"{message[i]}");
}
Console.WriteLine("\n");