using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleHorse.Core.Strings
{
    public class ProduceString
    {
        public void Logic()
        {
            string str1 = "first part" + " second part";    //=> "first part second part"
            string str2 = "To write one: " + 1;             //=> "To write one: 1"

            string firstName = "Tom";
            string lastName = "Cruise";
            string str3 = string.Format("Your name: {0} {1} ", firstName, lastName); //=> "Tom Cruise"

            string str4 = str3.ToLower();                   //=> "tom cruise"
            string str5 = str3.ToLowerInvariant();          //=> "tom cruise" culture independent

            string str6 = str3.Replace("Tom", "Emilia");    //=> "Emilia Cruise"

            DateTime dt = DateTime.Now;

            string str7 = dt.ToString();
            string str8 = dt.ToString("yyyy MM dd HH:mm:ss"); //=> similar to :"2017 09 07 13:40:22"
        }

        public void Build()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(true);
            sb.Append(12);
            sb.Append(" text ");
            sb.AppendLine("Test in new line");

            sb.AppendFormat("Numbers are: {0} {1} {2} {3} {4} ", 4, 12, 43, 11, 33, 12);  //See the last '12'

            string result = sb.ToString();
        }

        public void Culture()
        {
            var backup = CultureInfo.CurrentCulture; //Save default

            //Set actual thread culture info. The two way are same:
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("EN");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("EN");
            string result1 = DateTime.Now.ToLongDateString(); //Day and month name in English

            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfoByIetfLanguageTag("HU");
            string result2 = DateTime.Now.ToLongDateString(); //Day and month name in Hungarian

            CultureInfo.CurrentCulture = backup; //Restore default
        }
    }
}
