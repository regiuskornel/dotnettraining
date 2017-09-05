using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Delegates
{
    class GenericDelegates
    {
        public delegate TResult GenericDelegate<in TSource, out TResult>(TSource source);
        
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

        /// <summary>
        /// Using our custom generic delegate
        /// </summary>
        public void DoSomething()
        {
            GenericDelegate<string, int> function = ConvertToCardinal;
            int result = function("two");
        }

        /// <summary>
        /// Using dotnet Func as a predefined generic delegate with result value
        /// </summary>
        public void DoSomethingWithFunc()
        {
            System.Func<string, int> function = ConvertToCardinal;
            int result = function("two");
        }


        /// <summary>
        /// Using dotnet Action as a predefined generic delegate without result
        /// </summary>
        public void DoSomethingWithAction()
        {
            System.Action<int, int> areEqual = MustBeEqualMethod;
            areEqual(33, 33);
        }

        private void MustBeEqualMethod(int a, int b)
        {
            if (a != b)
                throw new ArgumentException($"{a} does not equal to {b}");
        }
    }
}
