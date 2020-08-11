using System;
using System.Text;

namespace BBUnity.Conversion {
    public static class NumberTo {
        public static string RomanNumeral(int number) {
            return NumberToRomanNumerals.Convert(number);
        }

        public static string Hex(int number) {
            return number.ToString("X");
        }

        public static String RetroScore(int score, int places = 10) {
            return NumberToRetroScore.Convert(score, places);
        }
    }

    internal static class NumberToRetroScore {
        static StringBuilder Builder;

        internal static string Convert(int number, int places) {
            int remainingPlaces = 10 - NumberOfDigits(number);
            places = places < remainingPlaces ? places : remainingPlaces;

            Builder.Clear();

            for(int i = 0; i < places; ++i) {
                Builder.Append("0");
            }

            Builder.Append(number);

            return Builder.ToString();
        }

        private static int NumberOfDigits(int number) {
            if (number < 0) number = (number == int.MinValue) ? int.MaxValue : -number;
            if (number < 10) return 1;
            if (number < 100) return 2;
            if (number < 1000) return 3;
            if (number < 10000) return 4;
            if (number < 100000) return 5;
            if (number < 1000000) return 6;
            if (number < 10000000) return 7;
            if (number < 100000000) return 8;
            if (number < 1000000000) return 9;

            return 10;
        }

        static NumberToRetroScore() {
            Builder = new StringBuilder(10);
        }
    }

    internal class NumberToRomanNumerals {
        private static int[] RomanNumeralDenominators = { 1, 5, 10, 50, 100, 500, 1000 };

        internal static string Convert(int number) {
            return EvaluateRomanNumeral(number);
        }

        private static string EvaluateRomanNumeral(int number) {
            int nextDenominator = ClosestRomanDenominator(number);
            int remainingNumber = number - nextDenominator;


            if(remainingNumber > 0) {
                return NumberToRomanNumeral(nextDenominator) + EvaluateRomanNumeral(Math.Abs(remainingNumber));
            }
            else if(remainingNumber < 0) {
                return EvaluateRomanNumeral(Math.Abs(remainingNumber)) + NumberToRomanNumeral(nextDenominator);
            }

            return NumberToRomanNumeral(nextDenominator);
        }

        private static int ClosestRomanDenominator(int number) {
            int closestValue = 0;
            for (int x = 0; x < RomanNumeralDenominators.Length; x++) {
                if (Math.Abs(number - RomanNumeralDenominators[x]) < Math.Abs(number - RomanNumeralDenominators[closestValue])) {
                    closestValue = x;
                }
            }
            return RomanNumeralDenominators[closestValue];
        }

        private static string NumberToRomanNumeral(int number) {
            switch (number) {
                case 1:
                    return "I";
                case 5:
                    return "V";
                case 10:
                    return "X";
                case 50:
                    return "L";
                case 100:
                    return "C";
                case 500:
                    return "D";
                case 1000:
                    return "M";
                default:
                    return "";
            }
        }
    }
}


