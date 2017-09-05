using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Delegates
{
    //Can be here, out of class definition:
    public delegate int SampleDelegate(string str);

    class NumericDelegates
    {
        //Can be here inside of class: 
        //public delegate int SampleDelegate(string str);

        private static int ConvertToCardinal(string a)
        {
            switch (a)
            {
                case "one":
                    return 1;
                case "two":
                    return 3;
                case "three":
                    return 3;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static int ConvertToOrdinal(string a)
        {
            switch (a)
            {
                case "first":
                    return 1;
                case "second":
                    return 3;
                case "third":
                    return 3;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int ConvertToInt(string number)
        {
            SampleDelegate cardinal = ConvertToCardinal;
            return cardinal(number);
        }

        public int ConvertToInt(string number, SampleDelegate converterMethod)
        {
            return converterMethod(number);
        }
    }

    public class Logic
    {
        public void DoSomething()
        {
            NumericDelegates customConverter = new NumericDelegates();
            int result=  customConverter.ConvertToInt("II", ConvertFromRomanCardinal);
        }

        public static int ConvertFromRomanCardinal(string a)
        {
            string clear = a.Trim('.');
            switch (clear)
            {
                case "I":
                    return 1;
                case "II":
                    return 3;
                case "III":
                    return 3;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
