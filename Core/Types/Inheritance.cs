using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Types
{
    public class Baseclass
    {
        private string _baseFieldPriv;
        protected string _baseFieldProt;
    }

    public class SampleClass : Baseclass
    {
        public void DoSomething()
        {
            //Not available: this._baseFieldPriv = "No access";
            _baseFieldProt = "can access";
        }
    }

    public class Logic
    {
        public void MakeSomeNoise()
        {
            SampleClass ex1 = new SampleClass();
            Baseclass base1 = ex1;

            //Build error:SampleClass ex2 = base1;
            SampleClass ex1a = (SampleClass)base1;

            if (base1 is SampleClass)
            {
                //....
            }

            Baseclass base2 = new Baseclass();
            SampleClass ex2 = base2 as SampleClass;
            if (ex2 != null)
            {
                //...
            }

            //******************************

            object obj3 = ex1;
            Baseclass base3 = (Baseclass)obj3;

            //Check instance type is same or inherited from a type
            if (obj3.GetType().IsInstanceOfType(typeof(SampleClass)))  //true
            {
                //...
            }


            //******************************
            List<Baseclass> ex3List = new List<Baseclass>();
            ex3List.Add(new SampleClass());
            ex3List.Add(new SampleClass());
            ex3List.Add(new SampleClass());

            foreach (Baseclass item in ex3List)
            {
                //...
            }

            foreach (SampleClass item in ex3List)  //Cast in behind => will run
            {
                //...
            }
        }
    }
}
