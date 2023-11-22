// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using TestDal;
using TestDbConsole;

Console.WriteLine("Hello, World!");
CrudEf<Parent>.Add("Sara", true);
CrudEf<Parent>.Add("Vio", false);
CrudEf<Parent>.Add("Vio", true);
CrudEf<Parent>.Update("Vio","Jio");
CrudEf<Parent>.Add("Imposter", false);
CrudEf<Parent>.Delete("Imposter");
var result = CrudEf<Parent>.SearchOne("Vio");
Console.WriteLine($"Search matches:{result.Name}");


CrudEf<Parent>.Get().ForEach(p =>
{
    if (p.IsActive == true)
        Console.WriteLine($"{p.Name} is an {p.IsActive} parent");
    else
        Console.WriteLine($"{p.Name} is child");
});