using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SampleHorse.Core.Async
{
    class SingletonSample
    {
        public void Logic()
        {
            var singleton = Singleton.Instance;
            var singleton2 = Singleton.Instance;
            Debug.Assert(singleton.Equals(singleton2));
            singleton.GlobalValue = 10;


            var lazySingleton = LazySingleton.Instance;
            lazySingleton.GlobalValue = 20;
        }
    }

    public class Singleton
    {
        private static Singleton _internalInstance;
        private static object _locker;

        public static Singleton Instance
        {
            get
            {
                if (_internalInstance != null) return _internalInstance;
                //T1,T2
                lock (_locker)
                {
                    //T1   //T2
                    if (_internalInstance != null) return _internalInstance;

                    var tempInstance = new Singleton();
                    Thread.MemoryBarrier();
                    //T1
                    _internalInstance = tempInstance;
                }
                return _internalInstance;
            }
        }

        public int GlobalValue { get; set; }

        //No external instantiation
        private Singleton()
        {
        }
    }

    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> InternalInstance =
            new Lazy<LazySingleton>(() => new LazySingleton(), LazyThreadSafetyMode.PublicationOnly);

        public static LazySingleton Instance => InternalInstance.Value;

        public int GlobalValue { get; set; }

        private LazySingleton() { }
    }
}
