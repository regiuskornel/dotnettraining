using SampleHorse.Contract;
using SampleHorse.Contract.Extension;

namespace SampleHorse.Application.Extension
{
    public static class SimpleFunctionsExtensions
    {
        public static void Failed(this ISimpleEventHolder eventHolder)
        {
            eventHolder.LastEvent = "Failed";
        }
    }

    public class ApplicationLevelValidation
    {
        public void MakeSomeNoise(ISimpleEventHolder incomingEvent)
        {
            //...
            //...
            //Validation error:
            incomingEvent.Failed();
        }
    }
}
