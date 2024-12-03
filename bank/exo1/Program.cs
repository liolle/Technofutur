using Extra;


Personne personne = new Personne("Jhon","Doe",new DateTime(2015,5,15));

Account account = new Courant(personne,"BE4444444444",500,50);

bool QUIT = true;

void printHelp(){
    Console.WriteLine("Here are the available commands\n - debit <amount>\n - credit <amount>\n - show (display account balance)\n - help\n - q (quit)\n\n");
    Console.WriteLine("What do you want to do?");
}


if(!QUIT){
    printHelp();
}

while (!QUIT)
{

    string? user_command;

    do
    {
        user_command = Console.ReadLine();
    } while (user_command is null);

    string[] command = user_command.Split(" ");

    if(command.Length<1){
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("unknown command (type help to see the available commands)");
        continue;
    }

    double amount;

    switch (command[0])
    {
        case "credit":
            if(command.Length<2){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("amount is missing: credit <amount>");
            }
            if(double.TryParse(command[1],out amount)){
                account.Credit(amount);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Transaction successful");
            }else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("invalid amount : credit <amount>");
            }
            break;

        case "debit":
            if(command.Length<2){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("invalid amount : debit <amount>");
            }
            if(double.TryParse(command[1],out amount)){
                
                if(account.Debit(amount)){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Transaction successful");
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("invalid amount : debit <amount>");
            }
            break;

        case "q":
            QUIT = true;
            break;
        
        case "clear":
            Console.Clear();
            break;
        
        case "show":
            account.show();
            break;

        case "help":
            printHelp();
            break;
        
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("unknown command (type help to see the available commands)");
            break;
    }
}

Bank bank = new Bank("ING");

Account ac = new Courant(personne,"BE4444444444",50,50);
Account ac2 = new Courant(personne,"BE4444444444",50,50);
Account ac3 = new Epargne(personne,"BE4444444444",500);
bank.add(ac);
bank.add(ac2);
bank.add(ac3);
ac.Debit(75);
ac2.Debit(75);
ac3.Credit(100);
bank.ApplyInterest();
bank.ApplyInterest();
Console.WriteLine(bank.assetsSum(personne));

