namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension class for string type
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Get MD5 hash of a string
        /// </summary>
        /// <param name="input">string from which to get the MD5 hash</param>
        /// <returns>Returns a hexadecimal string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            byte[] hashedDateBytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var hexadecimalRepresentation = new StringBuilder();

            for (int i = 0; i < hashedDateBytes.Length; i++)
            {
                hexadecimalRepresentation.Append(hashedDateBytes[i].ToString("x2"));
            }

            return hexadecimalRepresentation.ToString();
        }

        /// <summary>
        /// Check if a string contains true value(ex: true, ok, yes, 1, да)
        /// </summary>
        /// <param name="input">string to be checked whether has true value or not</param>
        /// <returns>boolean result if the input contains any of the true values</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer
        /// equivalent. A return value indicates whether the conversion succeeded or
        /// failed.
        /// </summary>
        /// <param name="input">A string representation of a number</param>
        /// <returns>16-bit signed integer if conversion is possible, or 0 otherwise</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer
        /// equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string representation of a number</param>
        /// <returns>32-bit signed integer if conversion is possible, or 0 otherwise</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer
        /// equivalent. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string representation of a number</param>
        /// <returns>64-bit signed integer if conversion is possible, or 0 otherwise</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its System.DateTime
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string representation of a date and time</param>
        /// <returns>A System.DateTime object with date and time set from the input if valid, else null
        /// </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalize the first letter of a string
        /// </summary>
        /// <param name="input">string with first letter to be capitalized</param>
        /// <returns>
        /// Returns the same string like the input parameter, but with capital first letter.
        /// If input parameter is null or empty string returns null or empty string.
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Get a string between two other strings (if found) starting from a given index
        /// </summary>
        /// <param name="input">the input string where the string between two other strings is searched</param>
        /// <param name="startString">the string that makes the left border of the searched string(input) </param>
        /// <param name="endString">the string that makes the right border of the searched string(input)</param>
        /// <param name="startFrom">a 32-bit signed integer value that specifies from where the searching is to be started</param>
        /// <returns>
        /// Returns string between two other strings. If the start string or end string do not 
        /// exist in the input, or some of them is null or empty returns empty string.
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts Cyrillic to Latin letters
        /// </summary>
        /// <param name="input">A string with Cyrillic letters</param>
        /// <returns>Returns new string with Latin letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts Latin to Cyrilic letters
        /// </summary>
        /// <param name="input">A string with Cyrillic letters</param>
        /// <returns>Returns new string with Cyrilic letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts a string representation of an user name to a valid representation of 
        /// an user name with Latin letters.
        /// </summary>
        /// <param name="input">A string representation of an user name to be validated</param>
        /// <returns>A valid string representation of an user name.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts a string representation of a file name to a valid representation of 
        /// a file name with Latin letters.
        /// </summary>
        /// <param name="input">A string representation of a file name to be validated</param>
        /// <returns>A valid string representation of a file name.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets a specified number of character from string
        /// </summary>
        /// <param name="input">String from which to get the characters</param>
        /// <param name="charsCount">32-signed integer value that shows how many characters to take</param>
        /// <returns>Returns a string with length charsCount or with length the lenght of the string 
        /// if the charsCount number is greater than the input length</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets file extension from a string representation of a file name
        /// </summary>
        /// <param name="fileName">String that represents file name</param>
        /// <returns>Returns file extension from file name, represented as sting. 
        /// If file name is invalid returns an empty string</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets the content type from a string representation of a file extension
        /// </summary>
        /// <param name="fileExtension">String that represents file extension</param>
        /// <returns>Returns the content type of file extension. If file extension is not found returns
        /// string with value "application/octet-stream"
        /// </returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Gets decimal representations in ASCII table of each character from a string
        /// </summary>
        /// <param name="input">String to be converted to byte array</param>
        /// <returns>Returns a byte array with the decimal representation of each character in ASCII table from the input string</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
