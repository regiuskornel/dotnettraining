using System;

namespace SampleHorse.Core.Strings
{
    public class CompareStrings
    {
        public void Culture()
        {
            //Compare with culture info
            var str1 = "Strasse";
            var str2 = "Straße";

            if (str1 == str2) //You can't define comparizon method
            {
            }

            bool equals1 = str1.Equals(str2, StringComparison.Ordinal);           //false
            bool equals2 = str1.Equals(str2, StringComparison.InvariantCulture);  //true

            //Case insensitive comparizon
            var str3 = "UPPERCASE";
            var str4 = "upperCASE";

            bool equals3 = str3.Equals(str4, StringComparison.Ordinal);           //false
            bool equals4 = str3.Equals(str4, StringComparison.OrdinalIgnoreCase);  //true

            //Try to avoid:
            bool equals5 = str3.ToLowerInvariant() == str4.ToLowerInvariant();

        }

        public void EmptyCheck()
        {
            string nullString = null;
            string emptyString = String.Empty; // = ""
            string whiteSpace = "  \t\n\r";

            if (nullString == null)
            {
                //null
            }

            if (string.IsNullOrEmpty(emptyString))
            {
                //empty, or null, no white char
            }

            if (string.IsNullOrWhiteSpace(whiteSpace))
            {
                //contans only spaces, or anything that is invisible itself
            }
        }
    }
}