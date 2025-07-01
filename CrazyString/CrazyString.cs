namespace Csomor.CrazyString
{
    public class CrazyString
    {
        public static string ToUpperCase(string input)
        {
            return input.ToUpperInvariant();
        }


        public static string ToUpperCaseFrom(string input, int startIndex, int length = 0)
        {
            if (length == 0)
            {
                length = input.Length - startIndex;
            }

            if (length < 0) {
                length = input.Length + length - startIndex;
            }

            if (startIndex < 0 || startIndex + length > input.Length)
            {
                throw new ArgumentOutOfRangeException($"Invalid start index or end index. For input=\"{input}\" that has length={input.Length} with startIndex={startIndex} and length={length}");
            }
            char[] chars = input.ToCharArray();
            for (int i = startIndex; i < startIndex + length; i++)
            {
                chars[i] = char.ToUpperInvariant(chars[i]);
            }
            return new string(chars);
        }


        public static string ToUpperCaseBetween(string input, int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex < 0 || startIndex > endIndex || endIndex > input.Length)
            {
                throw new ArgumentOutOfRangeException($"Invalid start index or end index. For input=\"{input}\" that has length={input.Length} with startIndex={startIndex} and endIndex={endIndex}");
            }
            char[] chars = input.ToCharArray();
            for (int i = startIndex; i <= endIndex; i++)
            {
                chars[i] = char.ToUpperInvariant(chars[i]);
            }
            return new string(chars);
        }
    }
}
