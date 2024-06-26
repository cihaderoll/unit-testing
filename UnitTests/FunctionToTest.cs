using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Console
{
    public class FunctionToTest
    {
        public string ReturnsSomethingIfZero(int number)
        {
            if (number == 0) return "Something";

            return "SomethingElse";
        }
    }
}
