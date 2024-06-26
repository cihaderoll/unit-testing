using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Console.tests
{
    public static class FunctionTests
    {
        //naming convention -> ClassName_MethodName_ExpectedResult
        public static void FunctionToTest_ReturnsSomethingIfZero_ReturnsZero()
        {
            try
            {
                //Arrange - go get yout variables, whatever you need,
                //classes, functions vs
                int testVal = 0;

                //Act - execute the function
                FunctionToTest toTest = new FunctionToTest();
                var result = toTest.ReturnsSomethingIfZero(testVal);

                //Assert - whatever is returned, is it what you want.
                if (result == "Something")
                    System.Console.WriteLine("True");
                else
                    System.Console.WriteLine("False");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
