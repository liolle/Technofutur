using System.Globalization;

string BBANToIBANBE(string bban)
{
    string iso_be = "1114";
    string last_twoS = bban.Substring(10);
    string dummyString = last_twoS + last_twoS + iso_be;
    long num;

    if(!long.TryParse(dummyString,out num)){
        return "";
    }
    long code = 98 - (num%97);

    string IBAN = "BE" + $"{code}{bban}" ;

    return IBAN;
}

bool isValidBBAN(string bban){
    if (bban.Length != 12){
        return false;
    }
     
     
    int first_ten ;
    int last_two ;
    if(!int.TryParse(bban.Substring(0,10),out first_ten) || !int.TryParse(bban.Substring(10),out last_two) ){
        return false;
    }

    if (first_ten%97 ==0){
        return last_two == 97;
    }

    return first_ten%97 ==last_two;
}

void getUserInput(){
    string? user_input;
   

    do
    {
         Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("can you enter your BBAN ?");
        Console.ResetColor();
        user_input = Console.ReadLine();

        if ((user_input is not null) && isValidBBAN(user_input))
        {
            break;
            
        }else {
            Console.WriteLine("Invalid input. Please enter a valid BBAN.");
        }

     
    } while (true);


    string IBAN = BBANToIBANBE(user_input);

    Console.WriteLine($"Here is your IBAN: {IBAN}");

}

getUserInput();