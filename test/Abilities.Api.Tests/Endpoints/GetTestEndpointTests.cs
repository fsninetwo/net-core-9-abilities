using Abilities.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Abilities.Api.Tests.Endpoints;

public class GetTestEndpointTests
{
    [Fact]
    public void GetTest_ReturnsExpectedMessage()
    {
        // Arrange: mock logger dependency
        var loggerMock = new Mock<ILogger<TestController>>();
        var controller = new TestController(loggerMock.Object);

        // Act
        var result = controller.GetTest();

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);

        // The controller returns an anonymous object; use dynamic to access the property
        dynamic payload = ok.Value!;
        Assert.Equal("Endpoint is working", (string)payload.message);

        // Optional: verify logger was called
        loggerMock.Verify(l => l.Log(
            It.IsAny<LogLevel>(),
            It.IsAny<EventId>(),
            It.IsAny<It.IsAnyType>(),
            It.IsAny<Exception?>(),
            (Func<It.IsAnyType, Exception?, string?>)It.IsAny<object>()), Times.AtLeastOnce);
    }
} 