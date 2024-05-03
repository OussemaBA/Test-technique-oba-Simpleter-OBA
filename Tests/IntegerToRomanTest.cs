using Microsoft.AspNetCore.Components;
using Test_technique_oba_Simpleter_OBA.Pages;

namespace Tests
{
    [TestClass]
    public class IntegerToRomanTest
    {
        [TestMethod]
        [DataRow("5", "V")]
        [DataRow("4", "IV")]
        [DataRow("9", "IX")]
        [DataRow("58", "LVIII")]
        [DataRow("1994", "MCMXCIV")]
        [DataRow("3999", "MMMCMXCIX")]
        public void ConvertToRoman_ShouldConvertCorrectly(string input, string expected)
        {
            var converter = new RomanConverter();
            converter.HandleInput(new ChangeEventArgs { Value = input });
            converter.ConvertToRoman();
            Assert.AreEqual(string.Empty, converter.errorMessage);
            Assert.AreEqual(expected, converter.romanNumeral);
        }

        [TestMethod]
        [DataRow("0")]
        [DataRow("-1")]
        [DataRow("10000")]
        [DataRow("abc")]
        public void HandleInput_ShouldThrowError(string input)
        {
            var converter = new RomanConverter();
            converter.HandleInput(new ChangeEventArgs { Value = input });
            Assert.IsFalse(string.IsNullOrEmpty(converter.errorMessage));
            Assert.IsNull(converter.romanNumeral);
        }

        [TestMethod]
        public void ConvertToRoman_ShouldInitializeCorrectly()
        {
            var converter = new RomanConverter();
            converter.ConvertToRoman();
            Assert.IsNull(converter.romanNumeral);
        }
    }
}