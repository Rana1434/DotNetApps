// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics.Contracts;

partial class Program
{
    delegate void compute(int n1, int n2);
    delegate void Contractor(double budget);
    delegate void Work(string st, bool t);
    static void Main()
    {
        Lab9();

    }

    private static void Lab9()
    {
        Action<string, bool> Working = new Action<string, bool>((st, t) =>
        {
            Console.WriteLine($"Work:{st},{t}");

        });
        Working("Coding in C#", true);
        Func<string, string> Name = (name1) => $"Name is {name1}";
        Console.WriteLine(Name("Dhanush"));

        Predicate<string> isActive = (v) =>
        {
            if (v == null) return false;
            else return true;
        };
        Console.WriteLine($"update Employee set isActive= {isActive("T")}");
    }

    private static void UsingGenericDelegate()
    {
        Action<double> DoraDoremonRegisterMarriage = new Action<double>((budget) =>
        {
            Console.WriteLine($"Registration Charges: {budget * 95 / 100}");
            Console.WriteLine($"Reception Charges: {budget * 5 / 100}");

        });
        Func<int, int, string> modifiedCompute = (n1, n2) => $"Addition: {n1 + n2}";
        modifiedCompute += (n1, n2) => $"Subtraction: {n1 - n2}";

        Predicate<int> isActive = (v) =>
        {
            if (v == 0) return false;
            else return true;
        };

        DoraDoremonRegisterMarriage(500000d);
        Console.WriteLine(modifiedCompute(100, 200));
        Console.WriteLine($"Output of Predicate: {isActive(1)}");
    }

    private static void DoraDoremonMarriage()
    {
        Contractor DoraDoremonMarriage = new Contractor((b) => Console.WriteLine($"Pandit charges: {b * 20 / 100}"));
        DoraDoremonMarriage += (b) => Console.WriteLine($"Catering Charges: {b * 50 / 100}");
        DoraDoremonMarriage += (b) => Console.WriteLine($"Mantap Decoration: {b * 5 / 100}");
        DoraDoremonMarriage += (b) => Console.WriteLine($"Doremon arriving in Anyway Door: {b * 15 / 100}");
        DoraDoremonMarriage(5000000);
    }

    private static void UsingLamdas()
    {
        compute objShortCompute = new compute((a, b) => Console.WriteLine($"Addition : {a + b}"));
        objShortCompute += (s, t) => Console.WriteLine($"Subtraction : {s - t}");
        objShortCompute += (a, b) => Console.WriteLine($"Multiplication : {a * b}");
        objShortCompute += (s, t) => Console.WriteLine($"Division : {s / t}");
        objShortCompute(100, 200);

    }
    private static void DelegatesUsingLongCutTechnique()
    {
        compute objCompute = new compute(AddFn);

        objCompute += SubFn;
        objCompute += DivFn;
        objCompute += MulFn;

        objCompute(100, 200);
    }

    //instantiate

    static void AddFn(int n1, int n2)
    {
        Console.WriteLine($"Output of Addition: {n1+ n2}");
    }
    static void DivFn(int n1, int n2)
    {
        Console.WriteLine($"Output of Division: {n1 / n2}");
    }
    static void SubFn(int n1, int n2)
    {
        Console.WriteLine($"Output of Subtracttion: {n1 - n2}");
    }
    static void MulFn(int n1, int n2)
    {
        Console.WriteLine($"Output of Multiplication: {n1 * n2}");
    }

}