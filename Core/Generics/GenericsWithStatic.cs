using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Generics
{
    public class GenericsWithStatic<T>
    {
        public static int ConfigValue { get; set; }

        public void Process(T source)
        {
            //Do something
        }

        public int GetStaticValue()
        {
            return ConfigValue;
        }
    }

    public class Logic
    {
        public void DoSomething()
        {
            GenericsWithStatic<int>.ConfigValue = 10;       //GenericsWithStatic<int> is a full type!
            GenericsWithStatic<string>.ConfigValue = 11;
            GenericsWithStatic<bool>.ConfigValue = 12;

            var genericInt = new GenericsWithStatic<int>();         
            var genericString = new GenericsWithStatic<string>();   

            int val1 = genericInt.GetStaticValue();                 //=> 10
            int val2 = genericString.GetStaticValue();              //=> 11

        }
    }
}
