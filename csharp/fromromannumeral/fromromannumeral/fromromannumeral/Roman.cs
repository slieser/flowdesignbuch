using System;
using System.Collections.Generic;

namespace fromromannumeral
{
    public static class Roman
    {
        private static readonly Dictionary<string, int> Digits = new Dictionary<string, int> {
            { "I", 1 },
            { "IV", 4 },
            { "V", 5 },
            { "IX", 9 },
            { "X", 10 },
            { "XL", 40 },
            { "L", 50 },
            { "XC", 90 },
            { "C", 100 },
            { "CD", 400 },
            { "D", 500 },
            { "CM", 900 },
            { "M", 1000 }
        };
        
        public static int FromRomanNumeral(string roman) {
            var result = 0;

            while (roman.Length > 0) {
                var (value, remainder) = GetDigitFromRight(roman);
                result += value;
                roman = remainder;
            }
            
            return result;
        }

        private static (int, string) GetDigitFromRight(string roman) {
            foreach (var digit in Digits) {
                if (!roman.EndsWith(digit.Key)) {
                    continue;
                }
                var value = digit.Value;
                var remainder = roman.Remove(roman.Length - digit.Key.Length);
                return (value, remainder);
            }
            throw new Exception($"No digit could be found in roman '{roman}'.");
        }
    }
}