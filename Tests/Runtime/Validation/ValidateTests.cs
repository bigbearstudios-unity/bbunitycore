using NUnit.Framework;

using BBUnity.Validation;
using BBUnity.TestSupport;

namespace Validation {
    public class ValidateTest {

        [Test]
        public void IPv4Format_ShouldPassOnValidIps() {
            BBAssert.IsTrue(new string[] {
                "1.1.1.1", 
                "255.255.255.255"
            }, Validate.IPv4Format);
        }

        [Test]
        public void IPv4Format_ShouldFailOnInvalidIPs() {
            BBAssert.IsFalse(new string[] {
                "a.1.1.1", 
                "a.b.c.d", 
                "1-1-1-1"
            }, Validate.IPv4Format);
        }

        [Test]
        public void IPv4_ShouldPassOnValidIps() {
            BBAssert.IsTrue(new string[] {
                "1.1.1.1", 
                "255.255.255.255"
            }, Validate.IPv4);
        }

        [Test]
        public void IPv4_ShouldFailOnInvalidIPs() {
            BBAssert.IsFalse(new string[] {
                "a.1.1.1", 
                "a.b.c.d", 
                "1-1-1-1", 
                "125.125.125.300"
            }, Validate.IPv4);
        }

        [Test]
        public void IPv6_ShouldPassOnValidIps() {
            BBAssert.IsTrue(new string[] {
                "2001:470:9b36:1::2",
                "2001:cdba:0000:0000:0000:0000:3257:9652",
                "2001:cdba:0:0:0:0:3257:9652",
                "2001:cdba::3257:9652"
            }, Validate.IPv6);
        }

        [Test]
        public void IPv6_ShouldFailOnInvalidIps() {
            BBAssert.IsFalse(new string[] {
                "1200::AB00:1234::2552:7777:1313",
                "1200:0000:AB00:1234:O000:2552:7777:1313"
            }, Validate.IPv6);
        }

        [Test]
        public void Email_ShouldPassOnValidEmailAddress() {
            BBAssert.IsTrue(new string[] {
                "test@mail.com"
            }, Validate.Email);
        }

        [Test]
        public void EmailAddress_ShouldPassOnValidEmailAddress() {
            BBAssert.IsTrue(new string[] {
                "test@mail.com"
            }, Validate.EmailAddress);
        }

        [Test]
        public void Email_ShouldFailOnInvalidEmailAddress() {
            BBAssert.IsFalse(new string[] {
                "testmail.com", 
                "@testmail.com", 
                "test@mailcom"
            }, Validate.Email);
        }

        [Test]
        public void EmailAddress_ShouldFailOnInvalidEmailAddress() {
            BBAssert.IsFalse(new string[] {
                "testmail.com", 
                "@testmail.com", 
                "test@mailcom"
            }, Validate.EmailAddress);
        }

        [Test]
        public void URL_ShouldPassOnValidURLs() {
            BBAssert.IsTrue(new string[] {
                "https://testsite.com",
                "http://testsite.com",
                "www.testsite.com",
                "testsite.com",
                "test.de",
                "https://github.com/atestproject"
            }, Validate.URL);
        }

        [Test]
        public void URL_ShouldFailOnInvalidURLs () {
            BBAssert.IsFalse(new string[] {
                "testmailcom", 
                "http:testmailcom"
            }, Validate.URL);
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