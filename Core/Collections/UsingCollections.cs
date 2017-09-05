using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleHorse.Core.Collections
{
    class UsingCollections
    {
        public void Logic()
        {
            IList<string> cities = new List<string>(5) //5 awaited number of possible items
            {
                "Budapest",
                "Szeged",
                "Miskolc"
            };

            //Override
            cities[0] = "Budaörs";

            var listFromlist = new List<string>(cities);
            listFromlist.Add("Budapest"); //Possible

            var onlyread = new ReadOnlyCollection<string>(cities);
            //Not implemented, readonly: onlyread.Add("Missing method");
            //Not implemented, readonly: onlyread[1] = "NowhereCity";


            IDictionary<int, string> dict = new Dictionary<int, string>()
            {
                {-1, "minus one"},
                {0, "zero"}
            };

            dict.Add(1, "one");
            dict.Add(2, "two");

            dict.Add(new KeyValuePair<int, string>(3, "three"));

            { //by two cpu core at once: Not thread safe!
                dict.Add(-2, "minus two");
                dict.Remove(2);
            }

            var hash = new HashSet<string>();
            hash.Add("One");
            hash.Add("One");
            hash.Add("One");
            //Only one item in the 'hash'-set
        }
    }
}
