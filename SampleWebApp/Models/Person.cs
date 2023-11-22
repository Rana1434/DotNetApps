using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Models
{
    public class Person
    {
        [Required]
        public string Aadhar {  get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(18, 108)]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
    public class  PersonOperations
    {
        static List<Person> _people = new List<Person>();
        public static List<Person> GetPeople()
        {
            if (_people.Count == 0)
            {
                _people.Add(new Person() { Aadhar = "YFTHDCVHGY876543", Age = 21, Email = "asdfghjkl@gmail.com", Name = "Rana" });
                _people.Add(new Person() { Aadhar = "YFTHDCVHGY876544", Age = 22, Email = "qwertyuiop@gmail.com", Name = "Pana" });
                _people.Add(new Person() { Aadhar = "YFTHDCVHGY876545", Age = 23, Email = "zxcvbnm@gmail.com", Name = "Vana" });

            }
            return _people;
        }

        public static Person Search(string pAadhar)
        {
            return GetPeople().Where(p => p.Aadhar == pAadhar).FirstOrDefault();
        }
        public static List<Person> Range(int startAge, int endAge)
        {
           return GetPeople().Where( p=> p.Age >= startAge && p.Age <= endAge).ToList();
            

        }

        internal static void CreateNew(Person p)
        {
            _people.Add(p);
        }
    }
}
