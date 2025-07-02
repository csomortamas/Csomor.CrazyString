using System.Text;

namespace Csomor.CrazyString
{
    public static class CrazyString
    {   
        /// <summary>
        /// Converts a specified portion of the input string to uppercase using invariant culture.
        /// </summary>
        /// <remarks>This method uses <see cref="char.ToUpperInvariant"/> to convert characters to
        /// uppercase, ensuring  culture-independent behavior. The method adjusts <paramref name="startIndex"/> and
        /// <paramref name="length"/>  to ensure they remain within the bounds of the string.</remarks>
        /// <param name="input">The string to modify. Cannot be <see langword="null"/>.</param>
        /// <param name="startIndex">The zero-based index at which to begin converting characters to uppercase.  If negative, the index is
        /// calculated from the end of the string.</param>
        /// <param name="length">The number of characters to convert to uppercase. If <c>0</c>, the method converts all characters  from
        /// <paramref name="startIndex"/> to the end of the string. If negative, the length is calculated  as the number
        /// of characters to convert moving backward from the end of the string.</param>
        /// <returns>A new string with the specified portion converted to uppercase. If <paramref name="length"/> is  <c>0</c> or
        /// exceeds the remaining characters from <paramref name="startIndex"/>, the method converts  all characters
        /// from <paramref name="startIndex"/> to the end of the string.</returns>
        public static string ToUpperFrom(this string input, int startIndex, int length = 0)
        {
            // go to the end of the string if length is 0
            if (length == 0)
                length = input.Length - startIndex;

            // if length is negative, it means we want to go backwards from the end
            if (length < 0) 
                length = input.Length + length - startIndex;

            // if startIndex is negative, it means we want to go backwards from the end
            if (startIndex < 0)
                startIndex = input.Length + startIndex;

            // if startIndex + length exceeds the input length, adjust length to match the input length
            if (startIndex + length > input.Length)
                length = input.Length - startIndex;

            char[] chars = input.ToCharArray();
            for (int i = startIndex; i < startIndex + length; i++)
            {
                chars[i] = char.ToUpperInvariant(chars[i]);
            }
            return new string(chars);
        }


        /// <summary>
        /// Converts the characters in a specified range of a string to uppercase.
        /// </summary>
        /// <remarks>The method supports negative indices for <paramref name="startIndex"/> and <paramref
        /// name="endIndex"/>, which are interpreted as offsets from the end of the string. For example, a <paramref
        /// name="startIndex"/> of -3 refers to the third-to-last character in the string.</remarks>
        /// <param name="input">The input string to modify. Cannot be <see langword="null"/>.</param>
        /// <param name="startIndex">The starting index of the range to convert. If negative, the index is calculated from the end of the string.</param>
        /// <param name="endIndex">The ending index of the range to convert. If negative, the index is calculated from the end of the string.</param>
        /// <returns>A new string with the characters in the specified range converted to uppercase.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="startIndex"/> is greater than <paramref name="endIndex"/>.</exception>
        public static string ToUpperBetween(this string input, int startIndex, int endIndex)
        {
            // if startIndex is negative, it means we want to go backwards from the end
            if (startIndex < 0)
                startIndex = input.Length + startIndex;

            // if endIndex is negative, it means we want to go backwards from the end
            if (endIndex < 0)
                endIndex = input.Length + endIndex;

            if (startIndex > endIndex)
                throw new ArgumentException($"\nstartIndex={startIndex} cannot be greater than endIndex={endIndex}\n");

            char[] chars = input.ToCharArray();
            for (int i = startIndex; i <= endIndex; i++)
            {
                chars[i] = char.ToUpperInvariant(chars[i]);
            }
            return new string(chars);
        }


        /// <summary>
        /// Converts random characters in the specified string to uppercase.
        /// </summary>
        /// <remarks>This method uses a random number generator to determine which characters in the input
        /// string are converted to uppercase. The randomness ensures that the output may vary for the same input across
        /// different calls.</remarks>
        /// <param name="input">The input string to process. If the string is <see langword="null"/> or empty, it is returned unchanged.</param>
        /// <returns>A new string where random characters from the input are converted to uppercase. The original string remains
        /// unchanged.</returns>
        public static string ToUpperRandom(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char[] chars = input.ToCharArray();
            Random random = new Random();
            for (int i = 0; i < chars.Length; i++)
            {
                if (random.Next(2) == 0)
                    chars[i] = char.ToUpperInvariant(chars[i]);
            }
            return new string(chars);
        }


        /// <summary>
        /// Converts a specified portion of the input string to lowercase using invariant culture.
        /// </summary>
        /// <remarks>This method adjusts <paramref name="startIndex"/> and <paramref name="length"/> to
        /// ensure they fall within the bounds of the input string. If the calculated range exceeds the string's length,
        /// it is truncated to fit.</remarks>
        /// <param name="input">The string to modify. Cannot be <see langword="null"/>.</param>
        /// <param name="startIndex">The zero-based starting index of the substring to convert. If negative, the index is calculated from the end
        /// of the string.</param>
        /// <param name="length">The number of characters to convert to lowercase. If <c>0</c>, the conversion continues to the end of the
        /// string. If negative, the length is calculated as the number of characters backward from the end of the
        /// string.</param>
        /// <returns>A new string with the specified portion converted to lowercase. The original string remains unchanged.</returns>
        public static string ToLowerFrom(this string input, int startIndex, int length = 0)
        {
            // go to the end of the string if length is 0
            if (length == 0)
                length = input.Length - startIndex;

            // if length is negative, it means we want to go backwards from the end
            if (length < 0)
                length = input.Length + length - startIndex;

            // if startIndex is negative, it means we want to go backwards from the end
            if (startIndex < 0)
                startIndex = input.Length + startIndex;

            // if startIndex + length exceeds the input length, adjust length to match the input length
            if (startIndex + length > input.Length)
                length = input.Length - startIndex;

            char[] chars = input.ToCharArray();
            for (int i = startIndex; i < startIndex + length; i++)
            {
                chars[i] = char.ToLowerInvariant(chars[i]);
            }
            return new string(chars);
        }


        /// <summary>
        /// Converts the characters in a specified range of a string to lowercase.
        /// </summary>
        /// <remarks>The method creates a new string with the specified range of characters converted to
        /// lowercase. The original string remains unchanged. Indices can be specified as negative values to count
        /// backwards from the end of the string.</remarks>
        /// <param name="input">The input string to modify. Cannot be <see langword="null"/>.</param>
        /// <param name="startIndex">The starting index of the range to convert. If negative, the index is calculated from the end of the string.</param>
        /// <param name="endIndex">The ending index of the range to convert. If negative, the index is calculated from the end of the string.</param>
        /// <returns>A new string with the characters in the specified range converted to lowercase.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="startIndex"/> is greater than <paramref name="endIndex"/>.</exception>
        public static string ToLowerBetween(this string input, int startIndex, int endIndex)
        {
            // if startIndex is negative, it means we want to go backwards from the end
            if (startIndex < 0)
                startIndex = input.Length + startIndex;

            // if endIndex is negative, it means we want to go backwards from the end
            if (endIndex < 0)
                endIndex = input.Length + endIndex;

            if (startIndex > endIndex)
                throw new ArgumentException($"\nstartIndex={startIndex} cannot be greater than endIndex={endIndex}\n");

            char[] chars = input.ToCharArray();
            for (int i = startIndex; i <= endIndex; i++)
            {
                chars[i] = char.ToLowerInvariant(chars[i]);
            }
            return new string(chars);
        }


        /// <summary>
        /// Converts random characters in the specified string to lowercase.
        /// </summary>
        /// <remarks>This method uses a random number generator to determine which characters in the input
        /// string are converted to lowercase. The randomness ensures that the output may vary for the same input across
        /// different calls.</remarks>
        /// <param name="input">The input string to process. If the string is <see langword="null"/> or empty, it is returned unchanged.</param>
        /// <returns>A new string where random characters from the input have been converted to lowercase. The original string
        /// remains unmodified.</returns>
        public static string ToLowerRandom(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char[] chars = input.ToCharArray();
            Random random = new Random();
            for (int i = 0; i < chars.Length; i++)
            {
                if (random.Next(2) == 0)
                    chars[i] = char.ToLowerInvariant(chars[i]);
            }
            return new string(chars);
        }


        /// <summary>
        /// Converts the characters in the specified string to a random mix of uppercase and lowercase.
        /// </summary>
        /// <remarks>This method uses a random number generator to determine the case of each character in
        /// the input string. The randomness is applied independently to each character, and the original order of
        /// characters is preserved.</remarks>
        /// <param name="input">The input string to transform. If the string is <see langword="null"/> or empty, it is returned unchanged.</param>
        /// <returns>A new string where each character in the input string is randomly converted to uppercase or lowercase.</returns>
        public static string ToRandomCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            char[] chars = input.ToCharArray();
            Random random = new Random();
            for (int i = 0; i < chars.Length; i++)
            {
                if (random.Next(2) == 0)
                    chars[i] = char.ToUpperInvariant(chars[i]);
                else
                    chars[i] = char.ToLowerInvariant(chars[i]);
            }
            return new string(chars);
        }


        /// <summary>
        /// Reverses the characters in the specified string.
        /// </summary>
        /// <param name="input">The string to reverse. Cannot be <see langword="null"/>.</param>
        /// <returns>A new string with the characters in <paramref name="input"/> reversed.</returns>
        public static string Reverse(this string input)
        { 
            return new string(input.ToCharArray().Reverse().ToArray());
        }
    
        
        /// <summary>
        /// Pads the input string with the specified character on both sides.
        /// </summary>
        /// <remarks>This method first pads the left side of the string, then the right side, ensuring the
        /// total padding is evenly distributed.</remarks>
        /// <param name="input">The string to be padded. Cannot be <see langword="null"/>.</param>
        /// <param name="paddingSize">The number of padding characters to add to each side of the string. Must be non-negative.</param>
        /// <param name="paddingChar">The character to use for padding. Defaults to a space character.</param>
        /// <returns>A new string with the specified padding applied to both sides. If <paramref name="paddingSize"/> is 0, the
        /// original string is returned.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="input"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="paddingSize"/> is negative.</exception>
        public static string Pad(this string input, int paddingSize, char paddingChar = ' ')
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            if (paddingSize < 0)
                throw new ArgumentOutOfRangeException(nameof(paddingSize), "Padding size must be non-negative.");
            if (paddingSize == 0)
                return input;
            return input.PadLeft(input.Length + paddingSize, paddingChar)
                .PadRight(input.Length + paddingSize + paddingSize, paddingChar);
        }


        /// <summary>
        /// Pads the specified input string with a repeated padding string on both sides.
        /// </summary>
        /// <remarks>The padding string is repeated as needed to match the specified padding size. If
        /// <paramref name="mirrored"/> is <see langword="true"/>, the padding on the right side is reversed.</remarks>
        /// <param name="input">The string to be padded. Cannot be <see langword="null"/>.</param>
        /// <param name="paddingSize">The number of characters to pad on each side. Must be non-negative.</param>
        /// <param name="paddingString">The string used for padding. Cannot be <see langword="null"/> or empty.</param>
        /// <param name="mirrored">Indicates whether the padding on the right side should be reversed to create a mirrored effect. <see
        /// langword="true"/> to reverse the right-side padding; otherwise, <see langword="false"/>.</param>
        /// <returns>A new string with the specified padding applied to both sides of the input string. If <paramref
        /// name="paddingSize"/> is 0 or <paramref name="paddingString"/> is empty, the original input string is
        /// returned.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="input"/> or <paramref name="paddingString"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="paddingSize"/> is negative.</exception>
        public static string Pad(this string input, int paddingSize, string paddingString, bool mirrored = true)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            if (paddingString == null)
                throw new ArgumentNullException(nameof(paddingString), "Padding string cannot be null.");
            if (paddingSize < 0)
                throw new ArgumentOutOfRangeException(nameof(paddingSize), "Padding size must be non-negative.");
            if (paddingSize == 0)
                return input;
            if (paddingString.Length == 0)
                return input;

            string paddingLeft = paddingString.RepeatForWidth(paddingSize);
            string paddingRight = paddingLeft;
            if (mirrored) paddingRight = paddingRight.Reverse();

            return paddingLeft + input + paddingRight;
        }


        /// <summary>
        /// Repeats the specified string a given number of times and returns the concatenated result.
        /// </summary>
        /// <param name="input">The string to be repeated. Cannot be <see langword="null"/>.</param>
        /// <param name="count">The number of times to repeat the string. Must be non-negative.</param>
        /// <returns>A new string consisting of the input string repeated <paramref name="count"/> times. Returns an empty string
        /// if <paramref name="count"/> is 0.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="input"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="count"/> is negative.</exception>
        public static string Repeat(this string input, int count)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be non-negative.");
            if (count == 0)
                return string.Empty;
            StringBuilder sb = new StringBuilder(input.Length * count);
            for (int i = 0; i < count; i++)
            {
                sb.Append(input);
            }
            return sb.ToString();
        }


        /// <summary>
        /// Repeats the specified string a given number of times, with a separator inserted between each repetition.
        /// </summary>
        /// <remarks>This method constructs the resulting string efficiently using a <see
        /// cref="StringBuilder"/> to minimize memory allocations.</remarks>
        /// <param name="input">The string to be repeated. Cannot be <see langword="null"/>.</param>
        /// <param name="count">The number of times to repeat the string. Must be non-negative.</param>
        /// <param name="separator">The string to insert between repetitions. Cannot be <see langword="null"/>.</param>
        /// <returns>A new string consisting of the input string repeated <paramref name="count"/> times,  with the specified
        /// separator inserted between each repetition. Returns an empty string if <paramref name="count"/> is 0.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="input"/> or <paramref name="separator"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="count"/> is negative.</exception>
        public static string Repeat(this string input, int count, string separator)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be non-negative.");
            if (count == 0)
                return string.Empty;
            if (separator == null)
                throw new ArgumentNullException(nameof(separator), "Separator cannot be null.");
            StringBuilder sb = new StringBuilder(input.Length * count + separator.Length * (count - 1));
            for (int i = 0; i < count; i++)
            {
                sb.Append(input);
                if (i < count - 1)
                    sb.Append(separator);
            }
            return sb.ToString();
        }


        /// <summary>
        /// Repeats the specified string until the desired total width is reached.
        /// </summary>
        /// <remarks>This method ensures that the resulting string has exactly the specified <paramref
        /// name="totalWidth"/>. If the <paramref name="input"/> string is shorter than the desired width, it is
        /// repeated multiple times. If the <paramref name="input"/> string is longer than the desired width, it is
        /// truncated.</remarks>
        /// <param name="input">The string to repeat. Cannot be <see langword="null"/>.</param>
        /// <param name="totalWidth">The total width of the resulting string. Must be non-negative.</param>
        /// <returns>A string that is constructed by repeating the <paramref name="input"/> string until the specified <paramref
        /// name="totalWidth"/> is reached. If <paramref name="totalWidth"/> is zero, an empty string is returned. If
        /// <paramref name="input"/> is longer than <paramref name="totalWidth"/>, the result is truncated to fit.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="input"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="totalWidth"/> is negative.</exception>
        public static string RepeatForWidth(this string input, int totalWidth)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            if (totalWidth < 0)
                throw new ArgumentOutOfRangeException(nameof(totalWidth), "Total width must be non-negative.");
            if (totalWidth == 0)
                return string.Empty;
            if (input.Length >= totalWidth)
                return input.Substring(0, totalWidth);
            if (input.Length == 0)
                return String.Empty;
            int repeatCount = totalWidth / input.Length;
            int remainder = totalWidth % input.Length;

            string repeated = input.Repeat(repeatCount);

            if (remainder > 0)
                repeated += input.Substring(0, remainder);

            return repeated;
        }    
    }
}
