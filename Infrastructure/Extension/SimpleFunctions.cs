using SampleHorse.Contract.Extension;

namespace SampleHorse.Infrastructure.Extension
{
    //Just an implementation of event holder
    public class SimpleFunctions : ISimpleEventHolder
    {
        public string LastEvent { get; set; }

        public void Handle()
        {
            //.... Some important calculation ....
            this.LastEvent = "Executing";
        }
    }


}
