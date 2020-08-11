using System.Text.RegularExpressions;

using BBUnity.Extensions;

namespace BBUnity.Validation {
    public static class Validate {

        public static bool Email(string toValidate) {
            return EmailAddress(toValidate);
        }


        public static bool EmailAddress(string toValidate) {
            Regex r = new Regex(@"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)");
            return r.IsMatch(toValidate);
        }

        public static bool URL(string toValidate) {
            Regex r = new Regex(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$");
            return r.IsMatch(toValidate);
        }

        /// <summary>
        /// Fast validation of the ipv4 format
        /// </summary>
        /// <param name="toValidate"></param>
        /// <returns></returns>
        public static bool IPv4Format(string toValidate) {
            Regex r = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
            return r.IsMatch(toValidate);
        }

        public static bool IPv4(string toValidate) {
            Regex r = new Regex(@"^([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])\.([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])\.([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])\.([01]?[0-9]?[0-9]|2[0-4][0-9]|25[0-5])$");
            return r.IsMatch(toValidate);
        }

        public static bool IPv6(string toValidate) {
            Regex r = new Regex(@"^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$");
            return r.IsMatch(toValidate);
        }

        public static bool NumberOfWords(string str, int minimum, int maximum) {
            int numberOfWords = str.NumberOfWords();

            if(numberOfWords < minimum) {
                return false;
            }

            if(numberOfWords > maximum) {
                return false;
            }

            return true;
        }

        public static bool MinimumNumberOfWords(string str, int minimum) {
            int numberOfWords = str.NumberOfWords();
            if(numberOfWords < minimum) {
                return false;
            }

            return true;
        }

        public static bool MaximumNumberOfWords(string str, int maximum) {
            int numberOfWords = str.NumberOfWords();
            if(numberOfWords < maximum) {
                return false;
            }

            return true;
        }

        public static bool NumberOfLetters(string str, int minimum, int maximum) {
            int numberOfLetters = str.Length;

            if(numberOfLetters < minimum) {
                return false;
            }
            
            if(numberOfLetters > maximum) {
                return false;
            }

            return true;
        }

        public static bool MinimumNumberOfLetters(string str, int minimum) {
            int numberOfLetters = str.Length;

            if(numberOfLetters < minimum) {
                return false;
            }
            
            return true;
        }

        public static bool MaximumNumberOfLetters(string str, int maximum) {
            int numberOfLetters = str.Length;

            if(numberOfLetters > maximum) {
                return false;
            }

            return true;
        }
    }
}