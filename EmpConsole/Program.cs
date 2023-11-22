// See https://aka.ms/new-console-template for more information
using EmpLib;


Person Rohith = new Person();
Rohith.Name = "Rohith";
Console.WriteLine(Rohith.Eat());

Person Rana = new Person();
Rana.Name = "Rana";
Console.WriteLine(Rana.Sleep());

Person Baap = new Employee()
{
    Designation = "Intern",
    DOJ = DateTime.Now.AddMonths(-1)
};
Baap.Name = "Baap";
((Employee)Baap).Designation="Analyst";
Console.WriteLine(Baap.Work());
Console.WriteLine($"EmpId for {Baap.Name} is {((Employee)Baap).EmpId}");

Console.WriteLine(((Employee)Baap).AttendTraining("C2C"));

//polymorphism
RuntimePolymorphism Sharmaji = new RuntimePolymorphism();
Console.WriteLine($"Sharmaji:{Sharmaji.Settle()}");
Console.WriteLine($"Sharmaji gets married:{Sharmaji.GetMarried()}");

RuntimePolymorphism SharmajiKaBeta = new RuntimePolymorphism();
Console.WriteLine($"Sharmaji:{SharmajiKaBeta.Settle()}");
Console.WriteLine($"Sharmaji gets married:{SharmajiKaBeta.GetMarried()}");

RuntimePolymorphism SharmaJiKaBeta2 = new Child();
Console.WriteLine($"SharmajiKaBeta2 gets married:{((Child)SharmaJiKaBeta2).GetMarried()}");
Console.WriteLine($"Sharmaji ka drawing concept (Using Abstract):{Sharmaji.Drawing()}");
Console.WriteLine($"Sharmaji ka dating concept (Using Abstract):{Sharmaji.WhatIsDating()}");

Employee Vidya = new Employee();
Vidya.Name = "Vidya";
Vidya.Designation = "Hacking";
Console.WriteLine(Vidya.Work());
Console.WriteLine(Vidya.Work("Hacking websites"));


Employee Srikar = new Employee();
Srikar.Name = "Srikar";
Srikar.SetTaxInfo("Im eligible in the 20% tax payer category");
Console.WriteLine(Srikar.GetTaxInfo());


Person SriRam=new Person("ASFSD79878765","+91 9876543210");

Console.WriteLine($"Aadhar:{SriRam.Aadhar}| Mobile Number:{SriRam.Mobile}");
Employee SriRam2 = new Employee("dgf90876543","+91 9876543211");
Console.WriteLine($"Aadhar:{SriRam2.Aadhar}| Mobile Number:{SriRam2.Mobile}");

Console.WriteLine($"Total count of Employee: {EmpUtils.EmpCount}");


EmpUtils.EmpDB.Add(Vidya);
EmpUtils.EmpDB.Add(SriRam2);
EmpUtils.EmpDB.Add(new Employee("dsdaafghjkl23456789", "+91 9876543215") { Name = "Ninja", Designation = "Analyst", Salary = 60000 });
EmpUtils.EmpDB.Add(new Employee("dsdahjkl23487654389", "+91 9876765215") { Name = "NinjaKaPita", Designation = "Senior Analyst", Salary = 600000 });
var resultList=EmpUtils.EmpDB.Where((emp) =>emp.Aadhar != null && emp.Aadhar.StartsWith("ds"));
resultList.ToList().ForEach((emp) =>Console.WriteLine($"{emp.Name} | {emp.Aadhar}"));

var resultList1 = EmpUtils.EmpDB.Where((emp) =>emp.Salary!=null && emp.Salary>=(600000));
resultList1.ToList().ForEach((emp) => Console.WriteLine($"{emp.Name} | {emp.Salary}"));


Employee.Add("Rara", true);
Employee.Add("Vara", true);

Employee.Get().ForEach(p =>
{
    if (p.IsActive == true)
        Console.WriteLine($"{p.EmpName} is an {p.IsActive} parent");
    else
        Console.WriteLine($"{p.EmpName} is child");
});







