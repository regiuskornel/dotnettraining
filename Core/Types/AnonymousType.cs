using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Types
{
    class AnonymousType
    {
        public AnonymousType()
        {
            var name3 = new { DeviceName = "New device" };
            InternalInit(name3);
            //name3.DeviceName = "Fix device"; //Build error
        }

        private void InternalInit(object name3) //Anonymous declaration not available
        {
            //name3. //Not available
        }
    }
}
