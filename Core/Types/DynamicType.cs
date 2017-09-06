namespace SampleHorse.Core.Types
{
    class DynamicType
    {
        public DynamicType()
        {
            dynamic name4 = new object();
            name4.DeviceName = "New device";
            InternalInit(name4);
        }

        private void InternalInit(dynamic name4)
        {
            name4.DeviceName = "Available";
        }
    }
}