namespace FirstApi.Models
{
    public interface IApiLogger
    {
        void Log(string message);
    }
    public interface IAccessories
    {
        void Log(string message);
    }
    public class Accessories : IAccessories
    {
        public void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now}:{message}");
        }
    }
    public class ApiLogger : IApiLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now}:{message}");
        }
    }
    public class FileApiLogger : IApiLogger
    {
        private string _fileName;
        public FileApiLogger()
        {
            _fileName = $"Log_{DateTime.Now.ToFileTime()}.log";
            File.WriteAllText(_fileName,"This is a log file"+Environment.NewLine);
        }
        public void Log(string message)
        {
            File.AppendAllText(_fileName, $"{ DateTime.Now}:{ message}");
            File.AppendAllText(_fileName, Environment.NewLine);
        }
    }
}
