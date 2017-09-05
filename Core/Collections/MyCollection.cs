using System.Collections;
using System.Collections.Generic;

namespace SampleHorse.Core.Collections
{
    class MyCollection : IEnumerable
    {
        private IList<string> _internalList = new List<string>();

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(_internalList);
        }

        public void Add(string newitem)
        {
            _internalList.Add(newitem); 
        }
    }

    public class MyEnumerator : IEnumerator
    {
        private IEnumerator<string> _internalList;

        public MyEnumerator(IList<string> internalList)
        {
            _internalList = internalList.GetEnumerator();
        }

        public bool MoveNext()
        {
            return _internalList.MoveNext();
        }

        public void Reset()
        {
            _internalList.Reset();
        }

        public object Current
        {
            get
            {
                return _internalList.Current;
            }
        }
    }
}