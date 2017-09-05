using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Delegates
{
    //Can be here, out of class definition:
    public delegate void PasswordHandlerDelegate(string str);

    public class LogicForHandlers
    {
        private readonly PasswordHandlerDelegate checkPassword;

        public LogicForHandlers()
        {
            checkPassword += ContainsNumber;
            checkPassword += ContainsAlpha;
            checkPassword += ContainsSymbol;
        }

        public void DoSomething()
        {
            NumericDelegates customConverter = new NumericDelegates();
            try
            {
                checkPassword("abc123-");
                //Strong password
            }
            catch (SecurityException ex)
            {
                //Too simple password
            }
        }
        

        private void ContainsNumber(string a)
        {
            if (!a.Contains('1'))               //TODO: Should I use regex?
                throw new SecurityException();
        }

        private void ContainsAlpha(string a)
        {
            if (!a.Contains('a'))
                throw new SecurityException();
        }

        private void ContainsSymbol(string a)
        {
            if (!a.Contains('-'))
                throw new SecurityException();
        }
    }
}
