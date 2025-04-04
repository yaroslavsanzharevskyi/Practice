using Moq;

namespace JokeGenerator.Tests;

[TestFixture]
public class ProgramTests
{
    private Mock<IJokeStore> _mockJokeStore;
    private StringWriter _consoleOutput;
    private StringReader _consoleInput;

    [SetUp]
    public void Setup()
    {
        _mockJokeStore = new Mock<IJokeStore>();
        _consoleOutput = new StringWriter();
        Console.SetOut(_consoleOutput);
    }

    [TearDown]
    public void Cleanup()
    {
        _consoleInput.Dispose();
        _consoleOutput.Dispose();
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));
    }

    [Test]
    public async Task GetCategories()
    {
        // Arrange
        _mockJokeStore.Setup(s => s.GetCategories()).ReturnsAsync(["animal", "career"]);

        // Simulate user input (pressing 'c' and then 'q' to quit)
        _consoleInput = new StringReader("?\nc\nq\n");
        Console.SetIn(_consoleInput);

        // Act
        await Program.Run(_mockJokeStore.Object);

        // Assert
        string output = _consoleOutput.ToString();
        Assert.That(output, Does.Contain("[animal]").And.Contain("[career]"));
    }

    [Test]
    public async Task GetRandomJokes_WithCategory()
    {
        // Arrange: Fake categories and jokes
        _mockJokeStore.Setup(s => s.GetCategories()).ReturnsAsync(["animal", "career"]);
        _mockJokeStore.Setup(s => s.GetRandomJokes("animal", 2)).ReturnsAsync(["Joke 1", "Joke 2"]);

        _consoleInput = new StringReader("?\nr\ny\nanimal\n2\nq\n");
        Console.SetIn(_consoleInput);

        // Act
        await Program.Run(_mockJokeStore.Object);

        // Assert
        string output = _consoleOutput.ToString();
        Assert.That(output, Does.Contain("[Joke 1]").And.Contain("[Joke 2]"));
    }

    [Test]
    public async Task GetRandomJokes_InvalidCategory()
    {
        // Arrange
        _mockJokeStore.Setup(s => s.GetCategories()).ReturnsAsync(["animal", "career"]);

        // Simulate invalid category input
        _consoleInput = new StringReader("?\nr\ny\ninvalid\nanimal\n2\nq\n");
        Console.SetIn(_consoleInput);

        // Act
        await Program.Run(_mockJokeStore.Object);

        // Assert
        string output = _consoleOutput.ToString();
        Assert.That(output, Does.Contain("You've entered a wrong category"));
    }

    [Test]
    public async Task GetRandomJokes_InvalidNumberOfJokes()
    {
        // Arrange
        _mockJokeStore.Setup(s => s.GetCategories()).ReturnsAsync(["animal", "career"]);

        // Simulate invalid category input
        _consoleInput = new StringReader("?\nr\ny\nanimal\n99\n2\nq\n");
        Console.SetIn(_consoleInput);

        // Act
        await Program.Run(_mockJokeStore.Object);

        // Assert
        string output = _consoleOutput.ToString();
        Assert.That(output, Does.Contain("You've entered a wrong number"));
    }
}
