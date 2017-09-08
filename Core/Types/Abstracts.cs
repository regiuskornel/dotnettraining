using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Types
{
    public interface ISampleBaseInterface
    {
    }

    public abstract class SampleBaseClass: ISampleBaseInterface
    {
        private int priv;

        protected int prot;

        protected SampleBaseClass()
        {
        }

        protected void CommonImplementation()
        {

        }

        protected virtual void OptionalOverrideMethod()
        {
            //Default
        }

        public abstract void MustOverrideMethod();
    }

    public class SampleImp : SampleBaseClass
    {
        
        protected override void OptionalOverrideMethod()
        {
            SampleImp b =new SampleImp();
           
            int u = 1;
            base.OptionalOverrideMethod();
        }
        

        public override void MustOverrideMethod()
        {
            var x = this.prot + 1;
        }

        //Avoid if possible!
        protected new void CommonImplementation()
        {

        }
    }
}
