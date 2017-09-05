using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core
{
    [SampleAttribute("sample parameter")]
    [Sample("sample parameter2")]
    public class TestClass
    {
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class SampleAttribute : Attribute
    {
        private readonly string sParameter;
        public string Parameter
        {
            get { return sParameter; }
        }

        public SampleAttribute(string sParameter )
        {
            this.sParameter = sParameter;
        }

    }

    /// <summary>
    /// Demo to get attribute values
    /// </summary>
    public class SampleAttributeHandler
    {
        public string[] GetAttributeValue(Type clsType)
        {
            object[] attributes = clsType.GetCustomAttributes(typeof(SampleAttribute), true);

            List<string> attributeValues = new List<string>();
            foreach (SampleAttribute attribute in attributes)
            {
                if (attribute ==null) continue;
                attributeValues.Add(attribute.Parameter);
            }

            return attributeValues.ToArray();
        }
    }

}
