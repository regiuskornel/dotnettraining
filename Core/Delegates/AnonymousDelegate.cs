using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Delegates
{
    class AnonymousDelegate
    {
        public int ConvertToInt(string number)
        {
            SampleDelegate cardinal = delegate(string str)
            {
                switch (str)
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
            };

            SampleDelegate cardinal2 = str =>
            {
                switch (str)
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
            };


            return cardinal(number);

            return cardinal2(number);

        }

        //Works only in C# 7, in Visual studio 2017
        /*
        public int UsingLocalFunction(string number)
        {
            int Cardinal(string str)
            {
                switch (str)
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

            return Cardinal(number);
        }
        */
    }
}
