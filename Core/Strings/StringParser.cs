using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Strings
{
    public class StringParser
    {
        public void DoSomething()
        {
            bool val1 = bool.Parse("True");
            bool val2 = bool.Parse("false");

            bool val3 = bool.Parse("0");
            bool val4 = bool.Parse("1");
            bool val5 = bool.Parse(""); //Throw exception

            int intVal1 = int.Parse("99");

            int intVal2;
            if (int.TryParse("9-9", out intVal2)) //Doesn't throw exception
            {
                //Parsed successfuly
            }
            else
            {
                //not success
            }

            DateTime dt;
            if (DateTime.TryParse("1971-01-01", out dt))
            {
                // OK
            }

        }
    }
}
