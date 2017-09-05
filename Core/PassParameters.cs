using System;

namespace SampleHorse.Core
{
    public class PassParameters
    {
        public void MainMethod()
        {
            {
                int aSource = 10;

                DateTime dtSource = DateTime.UtcNow;

                SampleStruct sSource = new SampleStruct();
                sSource.IntrnalValue = 9;

                SampleStruct sSourceV2 = new SampleStruct
                {
                    IntrnalValue = 9
                };


                PassValue(aSource, SampleEnum.Done, dtSource, sSource);

                Console.WriteLine(sSource.IntrnalValue); // => 9
            }

            {
                var scSource = new SampleClass();
                PassReference(scSource);
            }

            {
                int aSource = 10;
                PassValueAsReference(ref aSource);
            }

            {
                int aSource;
                AwaitValue(out aSource);
            }
        }

        private void PassValue(int a, SampleEnum se, DateTime dt, SampleStruct sst)
        {
            a = 50; //a local variable copied from aSource
            sst.IntrnalValue = 100; //won't touch sSource.InternalValue

            //Check the DateTime is immutable
        }

        private void PassReference(SampleClass sc)
        {
            sc = new SampleClass(); //sc local copy of reference, scSource still same as before
        }

        private void PassValueAsReference(ref int a)
        {
            a = 99; //change aSource value as well
        }

        private void AwaitValue(out int aSource)
        {
            aSource = 8888; //Must set value of 'out' parameter
            return;
        }

        #region Sample types
        enum SampleEnum
        {
            Start,
            Processing,
            Done
        }

        struct SampleStruct
        {
            public int IntrnalValue;
        }


        internal class SampleClass { }

        #region SubRegion
        //Will not help to much
        #endregion

        #endregion
    }
}