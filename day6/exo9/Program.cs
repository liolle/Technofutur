Test.Pion[,] table = new Test.Pion[6,7];
int[] place_left = [6,6,6,6,6,6,6];
int getUserInput(){

    int pick = 0;

    while (pick<1 || pick>7)
    {
        do
        {
            Console.WriteLine("Pick a column betwee 1 and 7");
        } while (!int.TryParse(Console.ReadLine(),out pick));  
    }

    return pick;
}


void showTable(Test.Pion[,] table){

    for (int i = 0; i < 6; i++)
    {
        string line = "[";
        for (int j = 0; j < 7; j++)
        {
            line += $" {(table[i,j].color)}";
        }
        line += " ]";
        Console.WriteLine($"{line}");
    }

}

// brut force, use backtracking here (flemme) 
int winning(Test.Pion[,] table)
{
    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 4; j++) 
        {
            if (table[i, j].color != 0 &&
                table[i, j].color == table[i, j + 1].color &&
                table[i, j].color == table[i, j + 2].color &&
                table[i, j].color == table[i, j + 3].color)
            {
                return table[i, j].color ;
            }
        }
    }

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 7; j++)
        {
            if (table[i, j].color != 0 &&
                table[i, j].color == table[i + 1, j].color &&
                table[i, j].color == table[i + 2, j].color &&
                table[i, j].color == table[i + 3, j].color)
            {
                 return table[i, j].color ;
            }
        }
    }

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            if (table[i, j].color != 0 &&
                table[i, j].color == table[i + 1, j + 1].color &&
                table[i, j].color == table[i + 2, j + 2].color &&
                table[i, j].color == table[i + 3, j + 3].color)
            {
                 return table[i, j].color ;
            }
        }
    }

    for (int i = 0; i < 3; i++)
    {
        for (int j = 3; j < 7; j++)
        {
            if (table[i, j].color != 0 &&
                table[i, j].color == table[i + 1, j - 1].color &&
                table[i, j].color == table[i + 2, j - 2].color &&
                table[i, j].color == table[i + 3, j - 3].color)
            {
                 return table[i, j].color ;
            }
        }
    }

    return -1;
}

void botPick(){
    int col = Random.Shared.Next(0,7);
    while (place_left[col]<0)
    {
        col = Random.Shared.Next(0,7);   
    }
    place_left[col]--;
    table[place_left[col],col].color = 1;
}

showTable(table);
while (winning(table)<0)
{
    int col = getUserInput()-1;
    if(place_left[col]>0){
        place_left[col]--;
        table[place_left[col],col].color = 2;
        botPick();
        showTable(table);
    }else {
        col = getUserInput()-1;
    }
}

namespace Test
{
    struct Pion
{
    public int color = 0;

    public Pion()
    {
    }
}
}