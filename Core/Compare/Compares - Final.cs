using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Final
{
    class CompareTestA
    {
        public int MyProperty { get; set; }

        public override bool Equals(object obj)
        {
            CompareTestB B_1 = (CompareTestB)obj; //Be careful!
            CompareTestB B = obj as CompareTestB;

            if (B != null)
            {
                return B.MyProperty == this.MyProperty;
            }

            return base.Equals(obj);
        }
    }

    class CompareTestB
    {
        public int MyProperty { get; set; }

        public override bool Equals(object obj)
        {
            CompareTestA A_1 = (CompareTestA)obj; //Be careful!
            CompareTestA A = obj as CompareTestA;

            if (A != null)
            {
                return A.MyProperty == this.MyProperty;
            }

            return base.Equals(obj);
        }
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
