// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

ConversionOfTypes();
WorkingWithArrays();
WorkingWithCollections();
void ConversionOfTypes()
{
    int num1 = 100;
    double num2 = 100;
    bool Ever = true;
    string str = "Rana";
    string strNum = "100";
    var res1 = (double)num1;
    var res2 = (int)num2;
    var convert1 = Convert.ToString(num1);
    Console.WriteLine(str);
    Console.WriteLine(Ever);

    var convert2 = Convert.ToInt32(strNum);
}
void WorkingWithArrays()
{
    int[] arr = new int[3];
    arr[0] = 10;
    arr[1] = 20;
    arr[2] = 30;

    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine($"Value of item: {arr[i]}");
    }
    string[] greetings = { "Namaste", "Hello", "Hola" };
    int count = 0;
    while (count < greetings.Length)
    {
        Console.WriteLine($"A new way to Greet:{greetings[count]}");
        count++;
    }
    int[] evens = { 2, 4, 6, 8, 10 };
    do
    {
        Console.WriteLine($"The next even number:{evens[count]}");
        count++;
    } while (count < evens.Length);

    object[] objArray = { 100, "ok", new int[] { 1, 2, 3, } };
    foreach (var singleitem in objArray)
    {
        if (singleitem.GetType().Name == "Int32[]")
        {
            foreach (var item in (Int32[])singleitem)
            {
                Console.WriteLine(item);

            }
        }
        else
        {
            Console.WriteLine($"Simple item in {nameof(objArray)}:{singleitem}");
        }
    }
}

void WorkingWithCollections()
{
    List<string> ShoppingList = new List<string>();
    Console.WriteLine($"Total items in shopping bag: {ShoppingList.Count()}");
    ShoppingList.Add("Bags");
    log(new object[] {"Item added:", ShoppingList[0] });
    ShoppingList.Add("Shoes");
    log(new object[] { "Item added:", ShoppingList[1] });
    ShoppingList.Add("Jio");
    log(new object[] { "Item added:", ShoppingList[2] });
    ShoppingList.Add("Airlines");
    Console.WriteLine($"Total items in shopping bag: {ShoppingList.Count()}");
    ShoppingList.Remove("Jio");
    Console.WriteLine($"Total items in shopping bag: {ShoppingList.Count()}");
    //print
    PrintValues(ShoppingList);
    ///
    Print(new Object[] { "Comma Separated Values of the shopping list", ShoppingList[0], ShoppingList[1], "\n The total count of items is: ", ShoppingList.Count() });

}
void Print(object[] pValues)
{
    string result = "";
    foreach(var item in pValues)
    {
        result = $"{result},{item}";
    }
    result = result.Trim(',');
    Console.WriteLine(result);
}
void PrintValues<T>(List<T> pCollection) 
{
    foreach(var item in pCollection)
    {
        Console.WriteLine(item);
    }
}


void log(object[] pValues)
    {
    string result = ";";
    foreach(var item in pValues) 
    {
        result = $"{result}{item}";
    }

    var finalResult = $"[{DateTime.Now.ToString()}]:{ result}";
    //console logging
    Console.ForegroundColor=ConsoleColor.Yellow;
    Console.WriteLine("----------");
    Console.WriteLine(finalResult);

    ///output window
    Debug.WriteLine("------LOG------");
    Debug.WriteLine(finalResult);
}
