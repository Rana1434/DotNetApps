// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Car Maruti = new Car(new SuzukiEngine(new Cylinder(new Piston(), new CrankShaft(new Transmitter()))));
Car Toyota = new Car(new ToyotaEngine());
class Car 
{
    public Car(IEngineVendor suzuki)
    {

    }
}
interface IEngineVendor { }
class SuzukiEngine : IEngineVendor 
{
    public SuzukiEngine(Cylinder cylinder)
    {

    }
}
class ToyotaEngine : IEngineVendor
{
    public ToyotaEngine()
    {

    }
}
class Piston 
{

}
class Cylinder 
{
    public Cylinder(Piston piston,CrankShaft shaft)
    {

    }
}
class Transmitter { }
class CrankShaft 
{
    public CrankShaft(Transmitter transmitter)
    {

    }
}