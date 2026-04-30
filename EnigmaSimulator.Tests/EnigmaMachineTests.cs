using EnigmaSimulator.Domain;

namespace EnigmaSimulator.Tests;

public class EnigmaMachineTests
{
    [Theory]
    [InlineData("HELLO", "ILBDA")]
    [InlineData("ILBDA", "HELLO")]
    public void EnigmaShouldEncodeStringsCorrectly(string input, string expected)
    {
        //Arrange
        EnigmaMachine machine = new(
            new Plugboard(),
            new Rotor(RotorSets.Enigma3),
            new Rotor(RotorSets.Enigma2),
            new Rotor(RotorSets.Enigma1),
            new Reflector(ReflectorSets.ReflectorB));

        //Act
        string output = machine.Encode(input);

        //Assert
        Assert.Equal(expected, output);

    }
}