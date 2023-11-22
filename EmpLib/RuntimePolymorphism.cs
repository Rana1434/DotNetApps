using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EmpLib
{
    public class RuntimePolymorphism : Talents
    {//permitting different logic in derived

        public virtual string Settle()
        {
            return "Get a government Job,Retire by 60yrs abd settle in native";
        }

        public string GetMarried()
        {
            return "Match horoscope,marry person from same religion,caste,settle in joint family";
        }

        public override string Drawing()
        {
            return "Draw Portraits,Manoj Paintings";
        }

        public override string WhatIsDating()
        {
            return "Meeting special friend at restaurant";
        }

    }
    public abstract class Talents
    {
        public abstract string WhatIsDating();
        public abstract string Drawing();
        public string cool()
        {
            return $"Rana is a BadBoy";

        }
    }
    public class Child : RuntimePolymorphism
    {
        public override string Drawing()
        {
            return "Drawing abstract art,Sketch";
        }

        public override string WhatIsDating()
        {
            return "Use Tinder App";
        }
        public override string Settle()
        {
            string howToLive = "Get a fat salaried job in fortune 500 company,Visit different countries,live outside hometown";
            howToLive = $"{howToLive}and later follow this: {base.Settle()}";
            return howToLive;
        }

        new public string GetMarried()
        {
            return "Register marriage,Surprise parents and settle abroad";
        }
    }
}

