using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Types
{
    public class Properies
    {
        //Property with backing field. Just an encapsulation
        private int _backingfield;
        public int Backingfield
        {
            get
            {
                return _backingfield;
            }
            set
            {
                _backingfield = value;
            }
        }

        //Implementation behind
        public int BackingfieldGet()
        {
            return _backingfield;
        }
        public void BackingfieldSet(int value)
        {
            _backingfield = value;
        }

        //Original conceptions
        public int PropertyWithCode
        {
            get
            {
                if (_backingfield >= 100)
                    _backingfield = 99;

                return _backingfield;
            }

            set
            {
                if (value < 0 || value > 99)
                    throw new ArgumentOutOfRangeException();

                _backingfield = value;
            }
        }

        public string PropertyWithConverter
        {
            get
            {
                return _backingfield.ToString();
            }

            set
            {
                int realValue;
                if (int.TryParse(value, out realValue))
                    throw new ArgumentOutOfRangeException();

                _backingfield = realValue;
            }
        }


        //With init, before constructor call
        private int _backingfieldWithInit = 10;
        public int BackingfieldWithInit
        {
            get { return _backingfield; }
            set { _backingfield = value; }
        }

        //Different access
        public int BackingfieldReadOnlyForOthers
        {
            get { return _backingfield; }
            private set { _backingfield = value; }
        }

        //Auto property
        public int AutoProperty { get; set; }

        public int AutoPropertyReadOnly { get; private set; }

        public int AutoPropertyReadOnlySimple { get; }

        public int AutoPropertyReadOnlySimpleWithInit { get; } = 10;

        public int AutoPropertyWithInit { get; set; } = 10;

        public int AutoPropertyReadOnlyWithBackingField => _backingfield + 10;

        public Properies()
        {
            AutoPropertyReadOnlySimple = 10;
        }

    }
}
