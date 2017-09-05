using System;
using System.Collections.Generic;

namespace SampleHorse.Core.Types
{
    /*See more in Extension folders across solution
     * ApplicationLevelValidation.cs
     * ISimpleEventHolder.cs
     * SimpleFunctions.cs
     * Logic.cs
     * */

    public class SampleUsage
    {
        public void DoSomething()
        {
            var result = new TobeExtendClass();

            result.AddFirstName("Herbert");
            result.AddLastName("Garrison");
        }
    }

    public class TobeExtendClass
    {
        public string Name { get; set; }
    }

    public static class TobeExtendClassExtensions
    {
        public static void AddFirstName(this TobeExtendClass tbex, string name)
        {
            tbex.Name = name + tbex.Name;
        }

        public static void AddLastName (this TobeExtendClass tbex, string name)
        {
            tbex.Name = tbex.Name + name;
        }
    }
}
