using SampleHorse.Infrastructure;
using SampleHorse.Infrastructure.Extension;

namespace SampleHorse.Domain.Extension
{
    public class Logic
    {
        public void MakeSomeNoise()
        {
            SimpleFunctions sf = new SimpleFunctions();
            //Call class method
            sf.Handle();

            //Call extention method
            sf.Rollback("Revoked");

            //Extension method call chain
            sf.Clear()
                .Done()
                .Clear()
                .Done();
        }
    }

    public static class SimpleFunctionsExtensions
    {
        public static void Rollback(this SimpleFunctions simpleFunctions, string reason)
        {
            simpleFunctions.LastEvent = reason;
        }

        public static SimpleFunctions Clear(this SimpleFunctions eventHolder)
        {
            eventHolder.LastEvent = string.Empty;
            return eventHolder;
        }

        public static SimpleFunctions Done(this SimpleFunctions eventHolder)
        {
            eventHolder.LastEvent = "Done";
            return eventHolder;
        }
    }
}
