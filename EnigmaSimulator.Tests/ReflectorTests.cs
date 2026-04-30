using EnigmaSimulator.Domain;

namespace EnigmaSimulator.Tests;

public class ReflectorTests
{
    [Theory]
    [InlineData('A', 'Y')]
    [InlineData('J', 'X')]
    [InlineData('X', 'J')]
    public void ReflectorShouldMapInputCorrectly(char input, char expected)
    {
        //Arrange
        Reflector reflector = new(ReflectorSets.ReflectorB);

        //Act
        char output = reflector.Encode(input);

        //Assert
        Assert.Equal(expected, output);
    }

}