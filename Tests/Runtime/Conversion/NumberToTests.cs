﻿using NUnit.Framework;
using System.Collections.Generic;

using BBUnity.Conversion;
using BBUnity.TestSupport;

namespace Conversion {
    public class NumberToTests {
        [Test]
        public void RomanNumeral_ShouldReturnCorrectRomanNumeral() {
            UAssert.AreEqual(new Dictionary<int, string> {
                { 1, "I" },
                { 5, "V" },
                { 10, "X"  },
                { 50, "L"},
                { 100, "C" },
                { 500, "D" },
                { 1000, "M" },
                { 2, "II" },
                { 3, "III" },
                { 15, "XV" },
                { 28, "XXIIX" }
            }, NumberTo.RomanNumeral);
        }

        [Test]
        public void RetroScore_ShouldReturnCorrectRetroScore() {
            UAssert.AreEqual(new Dictionary<int, string> {
                { 1, "0000000001" },
                { 10, "0000000010" },
                { 100, "0000000100" },
                { 1000, "0000001000" },
                { 10000, "0000010000" },
                { 100000, "0000100000" },
                { 1000000, "0001000000" },
                { 10000000, "0010000000" },
                { 100000000, "0100000000" },
                { 1000000000, "1000000000" }
            }, (int value) => {
                return NumberTo.RetroScore(value);
            });
        }
    }
}