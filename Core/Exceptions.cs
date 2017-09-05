using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core
{
    class Exceptions
    {
        public void DoSomething()
        {
            FragileMethod(1000);

            try
            {
                FragileMethod(1000);

                DoSomethingSpecial(1001);
            }
            catch (Exception ex) when (ex.InnerException == null) //Exception filter
            {
                Console.WriteLine("Invalid value. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid value. " + ex.Message);
            }
            finally
            {
                //To release resource
            }
        }

        private void DoSomethingSpecial(int src)
        {
            int _systemErrorCount = 0;

            try
            {
                FragileMethod(src);
            }
            catch (ArgumentOutOfRangeException ex) //First check is more specific
            {
                //UserLog: user enter invalid value
                throw;
            }
            catch (Exception ex) //Last check is less specific
            {
                //Some other exception, not an ArgumentOutOfRangeException
                //SystemLog: store context
                _systemErrorCount++;
                throw;
            }
        }
        

        private void FragileMethod(int src)
        {
            if (src > 99)
                throw new ArgumentOutOfRangeException("'src' grater than 99");
            //....
        }
    }

    public class InvalidJwtException : Exception
    {
        private readonly string invalidPart;

        public InvalidJwtException(string invalidPart)
        {
            this.invalidPart = invalidPart;
        }

        public override string Message => "Jwt invalid part: " + invalidPart; //Getter
    }
}
