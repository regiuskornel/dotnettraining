using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Collections
{
    class ThreadSafeCollection
    {
        public void Logic()
        {
            var ccDict = new ConcurrentDictionary<int, string>();

            if (ccDict.TryAdd(1, "First"))
            {
                //Success
            }
            else
            {
                //Concurrency
                //Somebody else already added the key '1'
            }

            ccDict.AddOrUpdate(2, i =>
            {
                //Add, because it's a new element
                return "Second";
            }, (i, s) =>
            {
                //Concurrency
                //You can be update, because somebody else already added the key '2'.
                return "Second";
            });

            ccDict.GetOrAdd(3, i =>
            {
                //'3' - "three" currently missing
                // return the value "three" and add to collection in thread-safe manner.
                return "Three";
            });
        }
    }
}
