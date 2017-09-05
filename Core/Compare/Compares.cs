using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core
{
    class CompareTestA
    {
        public int MyProperty { get; set; }
    }

    class CompareTestB
    {
        public int MyProperty { get; set; }
    }

    class CompareTestBInherited : CompareTestB
    {
    }

    class CompareTest
    {
        public void Compare1(CompareTestA A, CompareTestB B)
        {
            //Never: if (A == B) { }
            if ((object)A == (object)B)
            {
                //Equals  
            }
        }

        public void Compare2(CompareTestA A, CompareTestB B)
        {
            if (A.Equals(B))
            {
                //Equals 
            }
        }

        public void Compare3(CompareTestB B, CompareTestBInherited Binherited)
        {
            if (B == Binherited)
            {
                //Equals 
            }
        }

        public void CompareString(string aStr, string bStr)
        {
            if (aStr == bStr) //Compare by char-by-char
            {
                //Equals 
            }

            if (string.Compare(aStr, bStr, StringComparison.InvariantCulture) == 0)
            {
                //Same
            }

            if (string.Compare(aStr, bStr, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
            }

            int order = string.Compare(aStr, bStr, StringComparison.CurrentCulture);
            //order is the relative position in sort!
        }
    }
}
