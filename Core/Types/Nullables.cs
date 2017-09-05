using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core
{
    class Nullables
    {
        public void NullableVariables() {
            //Wrong: long number = null;
            long? number2 = null;
            number2 = 10;

            if (number2.HasValue ) //=> number2 != null
            {

            }

            var newNumber = number2.GetValueOrDefault(10);
            //Same:
            //var newNumber = number2.HasValue ? number2.Value : 10;
        }
    }
}
