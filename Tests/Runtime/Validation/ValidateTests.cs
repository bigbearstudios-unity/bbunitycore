using NUnit.Framework;

using BBUnity.Validation;
using BBUnity.TestSupport;
using System.Collections.Generic;

namespace Validation {
    public class ValidateTest {

        [Test]
        public void IPv4Format_ShouldPassOnValidIps() {
            new string[] {
                "1.1.1.1", 
                "255.255.255.255"
            }.IsTrue(Validate.IPv4Format);
        }

        [Test]
        public void IPv4Format_ShouldFailOnInvalidIPs() {
            new string[] {
                "a.1.1.1", 
                "a.b.c.d", 
                "1-1-1-1"
            }.IsFalse(Validate.IPv4Format);
        }

        [Test]
        public void IPv4_ShouldPassOnValidIps() {
            new string[] {
                "1.1.1.1", 
                "255.255.255.255"
            }.IsTrue(Validate.IPv4);
        }

        [Test]
        public void IPv4_ShouldFailOnInvalidIPs() {
            new string[] {
                "a.1.1.1", 
                "a.b.c.d", 
                "1-1-1-1", 
                "125.125.125.300"
            }.IsFalse(Validate.IPv4);
        }

        [Test]
        public void IPv6_ShouldPassOnValidIps() {
            new string[] {
                "2001:470:9b36:1::2",
                "2001:cdba:0000:0000:0000:0000:3257:9652",
                "2001:cdba:0:0:0:0:3257:9652",
                "2001:cdba::3257:9652"
            }.IsTrue(Validate.IPv6);
        }

        [Test]
        public void IPv6_ShouldFailOnInvalidIps() {
            new string[] {
                "1200::AB00:1234::2552:7777:1313",
                "1200:0000:AB00:1234:O000:2552:7777:1313"
            }.IsFalse(Validate.IPv6);
        }

        [Test]
        public void Email_ShouldPassOnValidEmailAddress() {
            new string[] {
                "test@mail.com"
            }.IsTrue(Validate.Email);
        }

        [Test]
        public void EmailAddress_ShouldPassOnValidEmailAddress() {
            new string[] {
                "test@mail.com"
            }.IsTrue(Validate.EmailAddress);
        }

        [Test]
        public void Email_ShouldFailOnInvalidEmailAddress() {
            new string[] {
                "testmail.com", 
                "@testmail.com", 
                "test@mailcom"
            }.IsFalse(Validate.Email);
        }

        [Test]
        public void EmailAddress_ShouldFailOnInvalidEmailAddress() {
            new string[] {
                "testmail.com", 
                "@testmail.com", 
                "test@mailcom"
            }.IsFalse(Validate.EmailAddress);
        }

        [Test]
        public void URL_ShouldPassOnValidURLs() {
            new string[] {
                "https://testsite.com",
                "http://testsite.com",
                "www.testsite.com",
                "testsite.com" +
                "test.de",
                "https://github.com/atestproject"
            }.IsTrue(Validate.URL);
        }

        [Test]
        public void URL_ShouldFailOnInvalidURLs () {
            new string[] {
                "testmailcom", 
                "http:testmailcom"
            }.IsFalse(Validate.URL);
        }

        [Test]
        public void NumberOfWords_ShouldPass_IfMinimumAndMaximumIsMet() {
            Assert.IsTrue(Validate.NumberOfWords("hello", 1, 1));
            Assert.IsTrue(Validate.NumberOfWords("hello motto", 2, 2));
            Assert.IsTrue(Validate.NumberOfWords("hello motto hello", 3, 3));
            Assert.IsTrue(Validate.NumberOfWords("hello motto hello motto", 4, 4));
        }

        [Test]
        public void NumberOfWords_ShouldFail_IfMinimumIsNotMet() {
            Assert.IsFalse(Validate.NumberOfWords("hello", 2, 3));
            Assert.IsFalse(Validate.NumberOfWords("hello motto", 3, 3));
        }

        [Test]
        public void NumberOfWords_ShouldFail_IfMaximumIsNotMet() {
            Assert.IsFalse(Validate.NumberOfWords("hello motto", 1, 1));
            Assert.IsFalse(Validate.NumberOfWords("hello motto yes please", 1, 3));
        }

        [Test]
        public void MinimumNumberOfWords_ShouldPass_IfMinimumIsMet() {
            Assert.IsTrue(Validate.MinimumNumberOfWords("one", 1));
            Assert.IsTrue(Validate.MinimumNumberOfWords("one two three", 2));
        }

        [Test]
        public void MaximumNumberOfWords_ShouldPass_IfMaximumIsMet() {
            Assert.IsTrue(Validate.MaximumNumberOfWords("one", 1));
            Assert.IsTrue(Validate.MaximumNumberOfWords("one two three", 3));
        }

        [Test]
        public void NumberOfLetters_ShouldPass_IfMinimumAndMaximumIsMet() {
            Assert.IsTrue(Validate.NumberOfLetters("hello", 1, 5));
        }
    }
}