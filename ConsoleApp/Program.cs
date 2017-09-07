using System;
using SampleHorse.Core;
using SampleHorse.Core.Async;
using SampleHorse.Core.Delegates;
using SampleHorse.Core.Strings;

namespace SampleHorse.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleAttributeHandler handler = new SampleAttributeHandler();
            string[] strs = handler.GetAttributeValue(typeof(TestClass));
            Console.WriteLine(string.Join(",", strs));

            LogicForHandlers handlers = new LogicForHandlers();
            handlers.DoSomething();

            ProduceString ps= new ProduceString();
            ps.Culture();
            CompareStrings cs = new CompareStrings();
            cs.Culture();
            cs.EmptyCheck();

            //StringParser sp = new StringParser();
            //sp.DoSomething();

            SampleHorse.Core.Generics.Logic gs = new SampleHorse.Core.Generics.Logic();
            gs.DoSomething();

            var ls = new Core.LINQ.LinqSamples(); //Please see the namespaces SampleHorse is not required. This class and LinqSamples has common namesapce base
            ls.DoSomethingWithJoin();

            var asyncS = new AsyncSample();
            asyncS.DoSomething();

            Console.ReadKey();
        }
    }
}
