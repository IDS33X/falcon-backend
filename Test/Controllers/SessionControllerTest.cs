using System;
using Xunit;
using System.Threading.Tasks;
using FakeItEasy;
using Service.Service;
using Util.dto;
using Util.exceptions;
using Domain.Models;
using FalconApi.Controllers;

namespace Test
{
    public class UnitTest1
    {
        /*  Naming conventions for the tests.
            (UnitOfWork_StateUnderTest_ExpectedBehavior)

            UnitOfWork ------> Method under Test.
            StateUnderTest---> Under which conditions do you test the method.
            ExpectedBehavior-> What do you expect from the test.
        */

        [Fact]
        public async void logIn_WithCorrectUserAndPassword_ReturnsUserInformation()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            ISessionService sessionService = A.Fake<ISessionService>();
            Employee emp = new Employee(1,"Adriel","Rosario","12345","abcde");
            Task<Employee> taskemp = Task.Run(() => (emp));
            DtoLogin dto = new DtoLogin(emp.Code,emp.Password);
            A.CallTo(() => sessionService.LogIn(dto)).Returns(taskemp);

            // Act --> in this section we call the method(Perform the action) that we are testing.
            SessionController controller = new SessionController(sessionService);
            var employee = await controller.LogIn(dto);
            

            // Assert --> in this section we verify the result.
            Assert.IsType<Employee>(employee.Value);
            Assert.Equal(emp.Code,employee.Value.Code);
            Assert.Equal(emp.Password,employee.Value.Password);
        }
        
    }
}
