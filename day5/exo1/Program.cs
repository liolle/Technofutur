void getDivitionInfo(int a, int b){

    int int_part = a / b;          
    int remainder = a % b;         
    double real_part = (double)a / b; 

    Console.WriteLine($"{int_part}\n{remainder}\n{real_part}");
}

getDivitionInfo(5,2);







