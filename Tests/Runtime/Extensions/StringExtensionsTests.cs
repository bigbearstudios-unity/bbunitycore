using NUnit.Framework;
using System.Collections.Generic;

using BBUnity.Extensions;
using BBUnity.TestSupport;

namespace Extensions {
    public class StringExtensionsTest {

        private int NumberOfWords(string str) {
            return str.NumberOfWords();
        }

            [Test]
        public void NumberOfWords_ShouldCountTheNumberOfWordsInAString_IfWordsAreASingleCharcter() {
            new Dictionary<string, int> {
                { "a", 1 },
                { "a b", 2 },
                { "a b c", 3 }
            }.AreEqual(NumberOfWords);
        }

        [Test]
        public void NumberOfWords_ShouldCountTheNumberOfWordsInAString_IfWordsAreSeperatedByASingleCharacter() {
            new Dictionary<string, int> {
                { "hello", 1 },
                { "hello motto", 2 },
                { "hello motto motto", 3 }
            }.AreEqual(NumberOfWords);
        }

        [Test]
        public void NumberOfWords_ShouldCountTheNumberOfWordsInAString_IfWordsAreSeperatedByMutlipleCharacters() {
            new Dictionary<string, int> {
                { "hello", 1 },
                { "hello  motto", 2 },
                { "hello  motto motto", 3 }
            }.AreEqual(NumberOfWords);
        }

        [Test]
        public void NumberOfWords_ShouldCountTheNumberOfWordsInAString_IfWordsStartWithWhitespace() {
            new Dictionary<string, int> {
                { " hello", 1 },
                { "  hello  motto", 2 },
                { "   hello  motto motto", 3 }
            }.AreEqual(NumberOfWords);
        }

        [Test]
        public void NumberOfWords_ShouldCountTheNumberOfWordsInAString_IfWordsEndWithWhitespace() {
            new Dictionary<string, int> {
                { "hello ", 1 },
                { "hello  motto   ", 2 },
                { "hello  motto motto    ", 3 }
            }.AreEqual(NumberOfWords);
        }

        [Test]
        public void ContainsWhitespace_ShouldReturnTrue_WhenStringStartsWithASpace() {
            Assert.IsTrue(" hello".ContainsWhitespace());
        }

        [Test]
        public void ContainsWhitespace_ShouldReturnTrue_WhenStringEndsWithASpace() {
            Assert.IsTrue("hello ".ContainsWhitespace());
        }

        [Test]
        public void ContainsWhitespace_ShouldReturnTrue_WhenStringContainsASpace() {
            Assert.IsTrue("hello motto".ContainsWhitespace());
        }

        [Test]
        public void ContainsWhitespace_ShouldReturnTrue_WhenStringHasMultipleSpaces() {
            Assert.IsTrue(" hello motto ".ContainsWhitespace());
        }

        [Test]
        public void ContainsWhitespace_ShouldReturnFalse_WhenStringHasNoSpace() {
            Assert.IsFalse("hello".ContainsWhitespace());
        }

        [Test]
        public void UpperCaseFirstLetter_ShouldUpperCaseTheFirstLetter() {
            Assert.AreEqual("Hello", "hello".UpperCaseFirstLetter());
        }

        [Test]
        public void UpperCaseFirstLetter_ShouldDoNothing_WhenFirstLetterIsNotALetter() {
            Assert.AreEqual("!hello", "!hello".UpperCaseFirstLetter());
        }
    }

}