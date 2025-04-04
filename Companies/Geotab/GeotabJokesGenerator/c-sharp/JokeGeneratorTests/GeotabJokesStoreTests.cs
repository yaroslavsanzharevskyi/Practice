using Moq;
using Moq.Protected;
using System.Net;
using Newtonsoft.Json;

namespace JokeGenerator.Tests;

public class GeotabJokesStoreTests
{
    [Test]
    public async Task GetCategories_ReturnArrayOfCategories()
    {
        // Arrange
        var fakeCategories = new string[] { "chuck", "norris" };
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(fakeCategories))
            });

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object);
        mockHttpClient.BaseAddress = new Uri("http://localhost/");
        mockHttpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(mockHttpClient);

        var service = new GeotabJokesStore(mockHttpClientFactory.Object);

        // Act
        var categories = await service.GetCategories();

        // Assert
        mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
        );

        Assert.That(categories, Is.EqualTo(fakeCategories));
    }

    [Test]
    public async Task GetCategories_HttpExceptionOccurs_ReturnsError()
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ThrowsAsync(new HttpRequestException("Network error"));

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object);
        mockHttpClient.BaseAddress = new Uri("http://localhost/");
        mockHttpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(mockHttpClient);

        var service = new GeotabJokesStore(mockHttpClientFactory.Object);

        // Act
        var categories = await service.GetCategories();

        // Assert
        mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
        );

        // Assert
        Assert.That(categories, Is.EqualTo(new string[] { "Error fetching categories." }));
    }

    [TestCase(1)]
    [TestCase(5)]
    [TestCase(9)]
    public async Task GetRandomJokes_OnlyNumberOfJokesProvided_ReturnRequestedNumberOfJokes(int numberOfJokes)
    {
        // Arrange
        var jokeApiResponse = JsonConvert.SerializeObject(new { value = "joke" });
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(() => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jokeApiResponse)
            });

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object, false);
        mockHttpClient.BaseAddress = new Uri("http://localhost/");
        mockHttpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(mockHttpClient);

        var service = new GeotabJokesStore(mockHttpClientFactory.Object);

        // Act
        var jokes = await service.GetRandomJokes(string.Empty, numberOfJokes);

        // Assert
        mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Exactly(numberOfJokes),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>()
        );

        Assert.That(jokes.Length, Is.EqualTo(numberOfJokes));
    }

    [Test]
    public async Task GetRandomJokes_CategoryProvided_CategoryFilterHasBeenAdded()
    {
        // Arrange
        var jokeApiResponse = JsonConvert.SerializeObject(new { value = "joke" });
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(() => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jokeApiResponse)
            });

        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
        var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object, false);
        mockHttpClient.BaseAddress = new Uri("http://localhost/");
        mockHttpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(mockHttpClient);

        var service = new GeotabJokesStore(mockHttpClientFactory.Object);
        var fakeCategory = "popcorn";
        // Act
        var jokes = await service.GetRandomJokes(fakeCategory, 1);

        // Assert
        mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(r => r.RequestUri!.AbsoluteUri.Contains($"?category={fakeCategory}")),
            ItExpr.IsAny<CancellationToken>()
        );
    }
}