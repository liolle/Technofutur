static Func<double,double> getConverter(){

    string? user_input;

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Pick : \n- Celsius => Farenheit [1]\n- Celsius => Kelvin [2]\n- Farenheit => Celsiur [3]\n- Farenheit => Kelvin [4]\n- Kelvin => Celsius [5]\n- Kelvin => Farenheit [6]");
    Console.ResetColor();

    do
    {

        user_input = Console.ReadLine();

        try
        {
            if (user_input is null) {
                continue;
            }
            switch (int.Parse(user_input))
            {
                case 1:
                    return x=>(double)x * 9/5 + 32;
                case 2:
                    return x=>(double) x + 273.15;
                case 3:
                    return x=>(double)(x-32) * 5/9;
                case 4:
                    return x=>(double)(x-32) * 5/9 + 273.15;
                case 5:
                    return x=>(double) x - 273.15;
                case 6:
                    return x=>(double) (x - 273.15) * 9/5 +32;
                default:
                    Console.WriteLine("Enter a valide number beween [1-6]");
                    break;
            }
            
        }
        catch (System.Exception)
        {
           Console.WriteLine("Enter a valide number beween [1-6]");
        }
        
    } while (true);

}


double promptValue(){

    string? user_input;
    double val = 0;

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("What value do you want to convert ?");
    Console.ResetColor();

    do
    {
        user_input = Console.ReadLine();
        
    } while (!double.TryParse(user_input,out val));

    return val;
}



bool END_FLAG = false;

void promptReplay(){
    string? user_input;
    do
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Do you want to conver an other value ?  [y/n]?");
        Console.ResetColor();

        user_input = Console.ReadLine();
        
        if (user_input is null) {
                continue;
            }

        switch (user_input.ToLower())
        {
            case "y":
                return;
            case "n":
                END_FLAG = true;
                return;
            
            default:
                break;
        }

    } while (true);

}


while (!END_FLAG)
{
    Func<double,double> converter = getConverter();
    Console.WriteLine($"Result: {converter(promptValue())}");
    promptReplay();
}



