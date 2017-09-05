using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core
{
    public class Variables
    {
        public Variables()
        {
            int value = (int)45345L;
            int value2 = Convert.ToInt32('A');

            //String is immutable
            string srcA = "Hello";
            string srcB = "World";

            string result = srcA + " " + srcB;
            result = result + "!";
        }

        public void VariableScope(int parameter)
        {
            int number = new Int32();

            int outSideVariable = 1;

            if (true)
            {
                //Wrong: int outSideVariable = 10;
                var inSideVariable = 20;
            }
            else
            {
                var inSideVariable = 20;
            }

            //Wrong: int parameter = 5;
        }
    }
}
