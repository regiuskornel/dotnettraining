using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core
{
    interface ISampleInterface {
        void DoSomething();
    }

    class SampleClass: ISampleInterface
    {
        public int MyProperty { get; set; }

        public void DoSomething()
        {
        }
    }

    class AnotherSampleClass : SampleClass
    {
        public new int MyProperty { get; set; }

        public int SampleProperty { get; set; }

    }
    
    struct SampleStruct : ISampleInterface
    {
        public int MyProperty { get; set; }

        public void DoSomething()
        {
        }
    }

    struct AnotherSampleStruct //Wrong: ": SampleStruct"
    { }
}
