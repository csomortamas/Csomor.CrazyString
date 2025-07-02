using Csomor.CrazyString;

namespace CrazyString.Tests
{
    public class CrazyStringTests
    {
        #region ToUpperFrom Tests

        [Fact]
        public void ToUpperFrom_ConvertsFromStartIndexToEnd()
        {
            string input = "hello world";
            string result = input.ToUpperFrom(6);
            Assert.Equal("hello WORLD", result);
        }

        [Fact]
        public void ToUpperFrom_ConvertsWithLength()
        {
            string input = "abcdef";
            string result = input.ToUpperFrom(2, 3);
            Assert.Equal("abCDEf", result);
        }

        [Fact]
        public void ToUpperFrom_NegativeStartIndex()
        {
            string input = "abcdef";
            string result = input.ToUpperFrom(-3, 2);
            Assert.Equal("abcDEf", result);
        }

        [Fact]
        public void ToUpperFrom_LengthZeroMeansToEnd()
        {
            string input = "abcdef";
            string result = input.ToUpperFrom(3, 0);
            Assert.Equal("abcDEF", result);
        }

        [Fact]
        public void ToUpperFrom_LengthExceedsString()
        {
            string input = "abcdef";
            string result = input.ToUpperFrom(4, 10);
            Assert.Equal("abcdEF", result);
        }

        [Fact]
        public void ToUpperFrom_NegativeLength()
        {
            string input = "abcdef";
            string result = input.ToUpperFrom(2, -1);
            Assert.Equal("abCDEf", result);
        }

        #endregion

        #region ToUpperBetween Tests

        [Fact]
        public void ToUpperBetween_ConvertsRange()
        {
            string input = "abcdef";
            string result = input.ToUpperBetween(1, 3);
            Assert.Equal("aBCDef", result);
        }

        [Fact]
        public void ToUpperBetween_NegativeIndices()
        {
            string input = "abcdef";
            string result = input.ToUpperBetween(-4, -2);
            Assert.Equal("abCDEf", result);
        }

        [Fact]
        public void ToUpperBetween_StartEqualsEnd()
        {
            string input = "abcdef";
            string result = input.ToUpperBetween(2, 2);
            Assert.Equal("abCdef", result);
        }

        [Fact]
        public void ToUpperBetween_StartGreaterThanEnd_Throws()
        {
            string input = "abcdef";
            Assert.Throws<ArgumentException>(() => input.ToUpperBetween(4, 2));
        }

        #endregion

        #region ToUpperRandom Tests

        [Fact]
        public void ToUpperRandom_ReturnsSameString_ForNullOrEmpty()
        {
            Assert.Equal(string.Empty, string.Empty.ToUpperRandom());
        }

        [Fact]
        public void ToUpperRandom_CanReturnAllUppercaseOrAllLowercase()
        {
            string input = "ab";
            // Run multiple times to increase chance of all upper or all lower
            bool seenAllUpper = false, seenAllLower = false;
            for (int i = 0; i < 10_000; i++)
            {
                string result = input.ToUpperRandom();
                if (result == input.ToUpperInvariant()) seenAllUpper = true;
                if (result == input) seenAllLower = true;
                if (seenAllUpper && seenAllLower) break;
            }
            Assert.True(seenAllUpper, "Should be possible to get all uppercase.");
            Assert.True(seenAllLower, "Should be possible to get all lowercase.");
        }

        [Fact]
        public void ToUpperRandom_DoesNotChangeNonAlphaCharacters()
        {
            string input = "1234!@#";
            string result = input.ToUpperRandom();
            Assert.Equal(input, result);
        }

        #endregion

        #region ToLowerRandom Tests

        [Fact]
        public void ToLowerRandom_ReturnsSameString_ForNullOrEmpty()
        {
            Assert.Equal(string.Empty, string.Empty.ToLowerRandom());
        }

        [Fact]
        public void ToLowerRandom_CanReturnAllUppercaseOrAllLowercase()
        {
            string input = "ab";
            // Run multiple times to increase chance of all upper or all lower
            bool seenAllUpper = false, seenAllLower = false;
            for (int i = 0; i < 10_000; i++)
            {
                string result = input.ToLowerRandom();
                if (result == input.ToLowerInvariant()) seenAllUpper = true;
                if (result == input) seenAllLower = true;
                if (seenAllUpper && seenAllLower) break;
            }
            Assert.True(seenAllUpper, "Should be possible to get all uppercase.");
            Assert.True(seenAllLower, "Should be possible to get all lowercase.");
        }

        [Fact]
        public void ToLowerRandom_DoesNotChangeNonAlphaCharacters()
        {
            string input = "1234!@#";
            string result = input.ToLowerRandom();
            Assert.Equal(input, result);
        }

        #endregion

        #region ToRandomCase Tests

        [Fact]
        public void ToRandomCase_ReturnsSameString_ForNullOrEmpty()
        {
            Assert.Equal(string.Empty, string.Empty.ToRandomCase());
        }


        [Fact]
        public void ToRandomCase_CanReturnAllUppercaseOrAllLowercase()
        {
            string input = "ab";
            // Run multiple times to increase chance of all upper or all lower
            bool seenAllUpper = false, seenAllLower = false;
            for (int i = 0; i < 10_000; i++)
            {
                string result = input.ToRandomCase();
                if (result == input.ToUpperInvariant()) seenAllUpper = true;
                if (result == input.ToLowerInvariant()) seenAllLower = true;
                if (seenAllUpper && seenAllLower) break;
            }
            Assert.True(seenAllUpper, "Should be possible to get all uppercase.");
            Assert.True(seenAllLower, "Should be possible to get all lowercase.");
        }

        [Fact]
        public void ToRandomCase_DoesNotChangeNonAlphaCharacters()
        {
            string input = "1234!@#";
            string result = input.ToRandomCase();
            Assert.Equal(input, result);
        }

        #endregion

        #region Reverse Tests
        
        [Fact]
        public void Reverse_ReturnsSameString_ForNullOrEmpty()
        {
            Assert.Equal(string.Empty, string.Empty.Reverse());
        }

        [Fact]
        public void Reverse_ReversesString()
        {
            string input = "abcdef1234+!~";
            string result = input.Reverse();
            Assert.Equal("~!+4321fedcba", result);
        }

        #endregion

        #region Pad Tests

        [Fact]
        public void Pad_AddsSpacesByDefault()
        {
            string input = "abc";
            string result = input.Pad(2);
            Assert.Equal("  abc  ", result);
        }

        [Fact]
        public void Pad_AddsCustomPaddingChar()
        {
            string input = "abc";
            string result = input.Pad(3, '*');
            Assert.Equal("***abc***", result);
        }

        [Fact]
        public void Pad_ZeroPaddingSize_ReturnsOriginal()
        {
            string input = "abc";
            string result = input.Pad(0, '-');
            Assert.Equal("abc", result);
        }

        [Fact]
        public void Pad_EmptyStringWithPadding()
        {
            string input = "";
            string result = input.Pad(2, '#');
            Assert.Equal("####", result);
        }

        [Fact]
        public void Pad_NegativePadding_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abc".Pad(-1));
        }

        [Fact]
        public void Pad_LongPadding()
        {
            string input = "x";
            string result = input.Pad(10, '0');
            Assert.Equal("0000000000x0000000000", result);
        }

        #endregion

        #region PadStringMirrored Tests

        [Fact]
        public void Pad_StringMirrored_PadsWithMirroredString()
        {
            string input = "abc";
            string result = input.Pad(3, "xy", true);
            // Left: "xyx", Right (mirrored): "xyx" reversed = "xyx"
            Assert.Equal("xyxabcxyx", result);
        }

        [Fact]
        public void Pad_StringMirrored_PadsWithNonMirroredString()
        {
            string input = "abc";
            string result = input.Pad(4, "12", false);
            // Left: "1212", Right: "1212" (not reversed)
            Assert.Equal("1212abc1212", result);
        }

        [Fact]
        public void Pad_StringMirrored_PadsWithLongerPaddingString()
        {
            string input = "x";
            string result = input.Pad(5, "abc", true);
            // Left: "abcab", Right: "abcab" reversed = "bacba"
            Assert.Equal("abcabxbacba", result);
        }

        [Fact]
        public void Pad_StringMirrored_ZeroPaddingSize_ReturnsOriginal()
        {
            string input = "abc";
            string result = input.Pad(0, "xyz", true);
            Assert.Equal("abc", result);
        }

        [Fact]
        public void Pad_StringMirrored_EmptyPaddingString_ReturnsOriginal()
        {
            string input = "abc";
            string result = input.Pad(3, "", true);
            Assert.Equal("abc", result);
        }

        [Fact]
        public void Pad_StringMirrored_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ((string)null).Pad(2, "xy", true));
        }

        [Fact]
        public void Pad_StringMirrored_NullPaddingString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => "abc".Pad(2, null!, true));
        }

        [Fact]
        public void Pad_StringMirrored_NegativePadding_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abc".Pad(-1, "xy", true));
        }

        [Fact]
        public void Pad_StringMirrored_EmptyInputWithPadding()
        {
            string input = "";
            string result = input.Pad(3, "ab", true);
            // Left: "aba", Right: "aba" reversed = "aba"
            Assert.Equal("abaaba", result);
        }

        #endregion

        #region Repeat Tests

        [Fact]
        public void Repeat_RepeatsString_CorrectNumberOfTimes()
        {
            string input = "ab";
            string result = input.Repeat(3);
            Assert.Equal("ababab", result);
        }

        [Fact]
        public void Repeat_ZeroCount_ReturnsEmptyString()
        {
            string input = "xyz";
            string result = input.Repeat(0);
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Repeat_OneCount_ReturnsOriginalString()
        {
            string input = "test";
            string result = input.Repeat(1);
            Assert.Equal("test", result);
        }

        [Fact]
        public void Repeat_EmptyStringWithPositiveCount_ReturnsEmptyString()
        {
            string input = "";
            string result = input.Repeat(5);
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Repeat_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ((string)null).Repeat(2));
        }

        [Fact]
        public void Repeat_NegativeCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abc".Repeat(-1));
        }

        [Fact]
        public void Repeat_LargeCount_ProducesExpectedLength()
        {
            string input = "x";
            int count = 1000;
            string result = input.Repeat(count);
            Assert.Equal(count, result.Length);
            Assert.All(result, c => Assert.Equal('x', c));
        }

        #endregion

        #region RepeatWithSeparator Tests

        [Fact]
        public void Repeat_WithSeparator_RepeatsStringAndInsertsSeparator()
        {
            string input = "ab";
            string result = input.Repeat(3, "-");
            Assert.Equal("ab-ab-ab", result);
        }

        [Fact]
        public void Repeat_WithSeparator_ZeroCount_ReturnsEmptyString()
        {
            string input = "xyz";
            string result = input.Repeat(0, ",");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void Repeat_WithSeparator_OneCount_ReturnsOriginalString()
        {
            string input = "test";
            string result = input.Repeat(1, "|");
            Assert.Equal("test", result);
        }

        [Fact]
        public void Repeat_WithSeparator_EmptyStringWithPositiveCount_ReturnsSeparatorsOnly()
        {
            string input = "";
            string result = input.Repeat(3, "-");
            Assert.Equal("--", result);
        }

        [Fact]
        public void Repeat_WithSeparator_NullSeparator_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => "abc".Repeat(2, null!));
        }

        [Fact]
        public void Repeat_WithSeparator_NegativeCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abc".Repeat(-1, ","));
        }

        [Fact]
        public void Repeat_WithSeparator_LongSeparator()
        {
            string input = "x";
            string result = input.Repeat(4, "123");
            Assert.Equal("x123x123x123x", result);
        }

        #endregion

        #region RepeatForWidth Tests

        [Fact]
        public void RepeatForWidth_RepeatsStringToExactWidth()
        {
            string input = "ab";
            string result = input.RepeatForWidth(6);
            Assert.Equal("ababab", result);
        }

        [Fact]
        public void RepeatForWidth_TruncatesIfInputLongerThanWidth()
        {
            string input = "abcdef";
            string result = input.RepeatForWidth(4);
            Assert.Equal("abcd", result);
        }

        [Fact]
        public void RepeatForWidth_RepeatsAndTruncatesToWidth()
        {
            string input = "abc";
            string result = input.RepeatForWidth(8);
            Assert.Equal("abcabcab", result);
        }

        [Fact]
        public void RepeatForWidth_ZeroWidth_ReturnsEmptyString()
        {
            string input = "abc";
            string result = input.RepeatForWidth(0);
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void RepeatForWidth_InputLengthEqualsWidth()
        {
            string input = "abc";
            string result = input.RepeatForWidth(3);
            Assert.Equal("abc", result);
        }

        [Fact]
        public void RepeatForWidth_EmptyInputWithPositiveWidth_ReturnsEmptyString()
        {
            string input = "";
            string result = input.RepeatForWidth(5);
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void RepeatForWidth_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ((string)null!).RepeatForWidth(5));
        }

        [Fact]
        public void RepeatForWidth_NegativeWidth_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abc".RepeatForWidth(-1));
        }

        #endregion
    }
}

