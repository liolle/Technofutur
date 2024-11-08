

using System.Reflection.Metadata;

string compte1 = "000000014245";
string compte2 = "000000014246";
string compte3 = "000000000097";


bool BBANValidator(string account_number){
    if (account_number.Length != 12){
        return false;
    }
     
     
    int first_ten ;
    int last_two ;
    if(!int.TryParse(account_number.Substring(0,10),out first_ten) || !int.TryParse(account_number.Substring(10),out last_two) ){
        return false;
    }

    if (first_ten%97 ==0){
        return last_two == 97;
    }

    return first_ten%97 ==last_two;
}


void getUserInput(){
    string? user_input;
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("can you enter your BBAN ?");
    Console.ResetColor();
    Console.WriteLine($"Sample accounts\n\n - {compte1}\n - {compte2}\n - {compte3}\n");
    user_input = Console.ReadLine();

    if (user_input is not null && BBANValidator(user_input)){
        Console.WriteLine("OK");
    }else {
        Console.WriteLine("KO");
    }


}

getUserInput();
