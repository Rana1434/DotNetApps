using EmpDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpLib
{

    public class Employee :Person, IEmployeeContract 
    { 
         
            public event EventHandler Join;
        public event EventHandler Resign;
        //ctor for creating constructor
        public Employee()
        {
            this.ViewContract();
            this.Sign();
            this.EmpId=new Random(1000).Next();
            EmpUtils.EmpCount++;
        }

        public void TriggerJoinEvent()
        {
            this.Join.Invoke(this, null);
        }

        public void TriggerResignEvent()
        {
            this.Resign.Invoke(this, null);
        }

        public Employee(string pAadhar):this()
        {
            this.Aadhar = pAadhar;
        }

        public Employee(string pAadhar,string pMobile):base(pAadhar,pMobile)
        {
            this.ViewContract();
            this.Sign();
            this.EmpId = new Random(1000).Next();
            EmpUtils.EmpCount++;
        }
        //variables inside a class are known as FIELDS
        private bool _contractSigned = false;
        private bool _hasReadContract =false;
        public void Sign()
        {
            _contractSigned = true;
        }
        public void ViewContract()
        {
            _hasReadContract = true;
        }
        private int _empId;
        public int EmpId { get { return _empId; }
            private set { _empId = value; } }  
        public string Designation { get; set; }
        public int Salary { get; set; }
        public DateTime DOJ { get; set; }

        public bool IsActive { get; set; }

        public string AttendTraining(string pTraining)
        {
            return $"{this.Name} attended a training {pTraining}";
        }
        public string FillTimesheet(List<string> ptasks)
        {
            var csvTask = "";
            foreach(var task in ptasks)
            {
                csvTask = $"{csvTask},{task}";
            }
            return $"{this.Name} has worked on {csvTask} on {DateTime.Now.ToShortDateString()}";

        }

        public override string Work( )

        {
            return $"{this.Name} with {this.EmpId} works for 8hrs a day at KPMG";
        }

        public string Work(string task)
        {
            return $"{this.Name} works {this.EmpId} has{task}assigned on {DateTime.Today}";

        }

        public void SetTaxInfo(string pTaxInfo) 
        {
            this.TaxDetails = pTaxInfo;
        }

        public string GetTaxInfo()
        {
            return $"{this.Name} : Your tax details are: {this.TaxDetails}";
        }

        //ADDING FUNCTIONS

        static VanaDbContext dbContext = new VanaDbContext();

        public static void Add(string pName, bool pIsActive)
        {
            dbContext.Employee1.Add(new Employee1() { EmpName = pName, IsActive = pIsActive });
            dbContext.SaveChanges();
        }
        public static void Update(string pName, string pUpdatedValue)
        {
            var tobeUpdated = dbContext.Employee1
                    .ToList()
                    .Where(p => p.EmpName == pName)
                    .FirstOrDefault();

            tobeUpdated.EmpName = pUpdatedValue;
            dbContext.SaveChanges();
        }

        public static void Delete(string pName)
        {
            var tobedeleted = dbContext.Employee1
                     .ToList()
                     .Where(p => p.EmpName == pName)
                     .FirstOrDefault();
            dbContext.Employee1.Remove(tobedeleted);
            dbContext.SaveChanges();
        }
        public static List<Employee1> Get()
        {
            return dbContext.Employee1.ToList() as List<Employee1>;
        }
        public static Employee1 SearchOne(string pName)
        {
            var result = dbContext.Employee1
                .ToList()
                .Where(p => p.EmpName == p.EmpName)
                .FirstOrDefault();
            return result as Employee1;
        }

    }
}
