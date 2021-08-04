using System;
using Xunit;

namespace Testing
{
    public class SessionControllerTests
    {

        /*  Naming conventions for the tests.
            (UnitOfWork_StateUnderTest_ExpectedBehavior)

            UnitOfWork ------> Method under Test.
            StateUnderTest---> Under which conditions do you test the method.
            ExpectedBehavior-> What do you expect from the test.
        */

        [Fact]
        public void logIn_WithCorrectUserAndPassword_ReturnsUserInformationJSON()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            
            // Act --> in this section we call the method(Perform the action) that we are testing.

            // Assert --> in this section we verify the result.
        }
    }
}
