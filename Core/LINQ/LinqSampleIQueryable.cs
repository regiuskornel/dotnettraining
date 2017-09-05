using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.LINQ
{
    class LinqSampleIQueryable
    {
        readonly IQueryable<int> querySource = new EnumerableQuery<int>(Enumerable.Range(1,10));

        void DoSomething()
        {
            IQueryable<int> query = querySource.Skip(2);
            var list = query.ToList();
        }
    }
}
