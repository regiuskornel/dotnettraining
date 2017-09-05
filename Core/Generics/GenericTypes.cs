using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Types
{
    class SampleGenericClass<T>
    {
        public T GetById(int id)
        {
            return default(T);
        }
    }

    class SampleGenericClass2<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }

    class SampleGenericClass3<T> where T : SampleBaseClass
    {
        public void Process(T inputParam)
        {
            inputParam.MustOverrideMethod();
        }
    }

    class SampleGenericClass4<T1,T2,T3>
    {
        public void ProcessT1(T1 t)
        {
        }

        public void ProcessT2(T2 t)
        {
        }

        public void ProcessT3(T3 t)
        {
        }
    }

    //Advanced type dependency
    class SampleGenericClass5<T> : SampleBaseClass where T : ISampleInterface
    {
        public override void MustOverrideMethod() { }

        public void Process(T inputParam)
        {
            inputParam.Counter++;
        }
    }


    //Advanced co-/contravariance
    interface ISampleInterface<in TSource, out TResult> : ISampleInterface where TSource: ISampleInterface
    {
        void Process(TSource inputParam);

        TResult Get();
    }

    //More: https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance
}
