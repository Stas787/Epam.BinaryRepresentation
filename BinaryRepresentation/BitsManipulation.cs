using System;
using System.Text;

namespace BinaryRepresentation
{
    public static class BitsManipulation
    {
        /// <summary>
        /// Get binary memory representation of signed long integer.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Binary memory representation of signed long integer.</returns>
        public static string GetMemoryDumpOf(long number)
        {
            string result = string.Empty;
            long rem;
            long numberAbs;

            if (number != long.MinValue)
            {
                numberAbs = Math.Abs(number);
            }
            else
            {
                numberAbs = long.MaxValue;
            }

            while (numberAbs != 0)
            {
                rem = numberAbs % 2;
                numberAbs /= 2;
                result = rem.ToString(System.Globalization.CultureInfo.CurrentCulture) + result;
            }

            StringBuilder result64 = new StringBuilder();

            for (int i = 63; i > result.Length - 1; i--)
            {
                result64.Append('0');
            }

            result64.Append(result);
            if (number < 0)
            {
                NegativeNumber(result64);
                if (number == long.MinValue)
                {
                    result64[63] = '0';
                }
            }

            return result64.ToString();
        }

        private static void NegativeNumber(StringBuilder result64)
        {
            for (int i = 0; i < result64.Length; i++)
            {
                if (result64[i] == '0')
                {
                    result64[i] = '1';                    
                }
                else if (result64[i] == '1')
                {
                    result64[i] = '0';
                }                
            }
            
            for (int j = 63; j > 0; j--)
            {                
                if (result64[j] == '0' && j + 2 < 64 && result64[j + 1] == '1' && result64[j + 2] == '1')
                {
                    result64[j] = '1';
                    result64[j + 1] = '0';
                    result64[j + 2] = '0';
                    break;
                }
                else if (result64[j] == '0')
                {
                    result64[j] = '1';
                    break;
                }                
            }
        }
    }
}
