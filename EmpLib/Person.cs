using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpLib
{
    public enum Gender
    {
        male,Female
    }
    public class Person
    {
        public Person()
        {

        }

        public Person(string pAadhar) :this()
        {
            this.Aadhar = pAadhar;
        }

        public Person( string pAadhar, string pMobile) : this(pAadhar)
        {

            this.Mobile = pMobile;
            
        }

        public string Name { get; set; }
        public string Aadhar { get; set; }
        public string Email { get; set; }
        public string PersonGender { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public DateTime DOB { get; set; }
        public string Eat() 
        {
            return $"{this.Name} Eats Breakfast,Lunch,Dinner";
        }
        public string Sleep() 
        {
            return $"{this.Name} Sleeps 8hrs a day";

        }
        public virtual string Work() 
        {
            return $"{this.Name} works for 4hrs,relaxes for 8hrs";

        }

        protected string TaxDetails { get; set; }   
    }
}
