using System;

namespace SampleHorse.Core.Types
{
    public class InstantiationClass
    {
        //#1
        private static int privStat;
        private static readonly int privStat2 = 2;
        public static int PubStat; //Avoid

        //#2
        static InstantiationClass()
        {
            privStat = 1;
        }

        //#3
        private readonly int privReadOnly;
        private readonly int privReadOnly2 = 20;

        public int Pub; //Avoid!
        private int priv = 30;

        //#4
        InstantiationClass()
        {
            privReadOnly = 10;
            this.priv = 10 * 10;
        }

        InstantiationClass(int val) : this()
        {
            this.priv = val;
        }

        //Advanced access
        private class SubClass
        {
            private static int subClassPriv = 100;
            public SubClass()
            {
                privStat = 100;
            }
        }
    }
}
