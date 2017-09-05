using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core
{
    public class Disposable
    {
        public void DoSomething()
        {
            ResourceConsumer consumer = new ResourceConsumer();
            try
            {
                consumer.OpenLog();
            }
            finally
            {
                consumer.Dispose();
            }

            //Same as above:
            using (var consumer2 = new ResourceConsumer())
            {
                consumer2.OpenLog();
            }

            using (var consumer3 = new ResourceConsumer())
            {
                using (var consumer4 = new ResourceConsumer())
                {
                    consumer4.OpenLog();
                }

                consumer3.OpenLog();
                consumer3.WriteError("No error");
            }

        }
    }

    public class ResourceConsumer : IDisposable
    {
        private System.IO.FileStream _logfile;

        public void OpenLog()
        {
            _logfile = System.IO.File.Create("logfile.log");
        }

        public void WriteError(string error)
        {
            if (_logfile ==null)
                throw new InvalidOperationException("OpenLog before write it");

            //_logfile.Write();
        }

        public void Dispose()
        {
            if (_logfile != null)
            {
                _logfile.Close();
                GC.SuppressFinalize(_logfile); //Will skip finalizer method below
                _logfile = null;
            }

            _logfile?.Close();
        }

        //Finalizer, be careful
        ~ResourceConsumer()
        {
            Dispose();
        }
    }
}
