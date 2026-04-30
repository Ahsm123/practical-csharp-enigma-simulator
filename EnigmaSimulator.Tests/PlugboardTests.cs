using EnigmaSimulator.Domain;

namespace EnigmaSimulator.Tests;

public class PlugboardTests
{
    [Theory]
    [InlineData('A', 'B')]
    [InlineData('B', 'A')]
    [InlineData('C', 'C')]
    public void ConnectionPresentAfterBeingConfigured(char input, char expected)
    {
        //Arrange
        Plugboard plugboard = new("AB", "WH");

        //Act
        char output = plugboard.Encode(input);

        //Assert
        Assert.Equal(expected, output);
    }
}