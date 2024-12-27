using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnitExample.Controllers;
using xUnitExample.Service;

namespace xUnitExample.Test.Controller
{
    public class HomeControllerTest
    {
        [Fact]
        public void HomeController_Index_validate()
        {
            // Arrange
            var mockPrintService = new Mock<IPrintService>();
            string incorrectExpectedOutput = "IncorrectOutput"; // Intentionally incorrect expected output

            // Set up the mock's behavior
            mockPrintService.Setup(service => service.Print(It.IsAny<string>()))
                            .Returns("IncorrectOutput"); // Actual mock output

            var controller = new HomeController(mockPrintService.Object);

            // Act
            var result = controller.Index("inputData");

            // Assert
            // This will fail because the actual result ("ProcessedOutput") does not match the incorrectExpectedOutput
            Assert.Equal(incorrectExpectedOutput, result);

            // Verify that the Print method was called exactly once
            mockPrintService.Verify(service => service.Print(It.IsAny<string>()), Times.Once);
        }
    }
}
