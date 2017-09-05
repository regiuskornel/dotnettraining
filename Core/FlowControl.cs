using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core
{
    class FlowControl
    {
        public void Check()
        {
            int value = 1;

            if (value == 0)
            {
                //Do
            }
            else if (value == 1)
            {
                //Do
            }
            else
            {
                //Do
            }

            //No curly braces
            if (value == 0)
                return;

            if (value > 0)
                if (value > 5)
                {
                }
                else
                    return;
            else
                return;
        }

        public void Switch()
        {
            int value = 1;
            switch (value)
            {
                case 1:
                    //Do
                    break;
                case 2:
                    //Do
                    break;
                case 3:
                    //Do
                    return;
                case 4:
                    //Please never use:
                    goto case 1;
                default: //Please use every time
                    return;
            }

            string strValue = "one";
            switch (strValue)
            {
                case "one":
                    break;
                case "two":
                    break;
            }
        }
    }
}
