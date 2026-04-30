namespace EnigmaSimulator.Domain;

public class BidirectionalCharEncoder
{
    private readonly Dictionary<char, char> _mappings = new();
    private readonly Dictionary<char, char> _reverseMappings = new();

    public BidirectionalCharEncoder(string mapping)
    {
        mapping = mapping.ToUpper();
        for (int i = 0; i < mapping.Length; i++)
        {
            char input = (char)('A' + i);
            char output = mapping[i];
            _mappings.Add(input, output);
            _reverseMappings.Add(output, input);

        }
    }

    public char Encode(char input, bool isForward, int offset = 0)
    {
        const int numLetters = 26; //Alphabet size

        //Adjust the input character for the offset
        //Using % to wrap around the alphabet from Z to A
        int inputIndex = input - 'A';
        int adjustedIndex = (inputIndex + offset + numLetters) % numLetters;
        char adjustedInput = (char)(adjustedIndex + 'A');

        Dictionary<char, char> mappings = isForward ? _mappings : _reverseMappings;
        char encodedChar = mappings.GetValueOrDefault(adjustedInput, input);

        //Adjust the encoded character back for the offset
        int encodedIndex = encodedChar - 'A';
        int finalIndex = (encodedIndex - offset + numLetters) % numLetters;
        return (char)(finalIndex + 'A');
    }
}