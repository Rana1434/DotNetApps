namespace FirstApi.Models
{
    public class Car
    {
        private IEngine _engine;
        public Car(IEngine e)
        { 
           _engine = e;
        }
    }
    public interface IEngine { }
    public class SuzukiEngine : IEngine { }
    public class ToyotaEngine : IEngine { }

}
