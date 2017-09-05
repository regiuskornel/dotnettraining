using System.Collections.Generic;

namespace SampleHorse.Core.Collections
{
    class Logic
    {
        public IEnumerable<string> GetAllOptions()
        {
            //sequence init
            IList<string> cities = new List<string>()
            {
                "Budapest",
                "Szeged",
                "Miskolc"
            };

            var uy = new UsingYield();

            return uy.GetNumbers();
            //return uy.OptionsFromCities(cities, true);
        }
    }

    class UsingYield
    {
        public IEnumerable<string> GetNumbers()
        {
            yield return "One";
            yield return "Two";
            yield return "Three";
        }

        public IEnumerable<string> OptionsFromCities(IList<string> cities)
        {
            yield return "Please select one city";

            foreach (var city in cities)
            {
                yield return city;
            }

            //bool possibleUknown
            //if (!possibleUknown)
            //    yield break;

            yield return "I don't know";
        }

    }
}