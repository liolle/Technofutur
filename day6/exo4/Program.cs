int[] array = [1,2,3,4,5,6,7,8,9]; 

void printArray(int[] arr){
    Console.Write($"[");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($" {array[i]}{(i==array.Length-1 ?"":", ")}");
    }
    Console.Write($" ]\n");
}

void reverseArray(int[] arr){
    for (int i = 0,j=arr.Length-1; i <j; i++,j--)
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = arr[tmp];
    }
}

Console.WriteLine("Array before reverse");
printArray(array);

reverseArray(array);

Console.WriteLine("Array after reverse");
printArray(array);
