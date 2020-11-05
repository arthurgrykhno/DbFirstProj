using DbFirstProj.Entities;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DbFirstProj.Infrastructure.Data.Classes
{
    /// <summary>
    /// Static class which contains methods for parsing code sent by user.
    /// </summary>
    public static class CodeParser
    {
        /// <summary>
        /// Method subtitutes code sent by user into mask from database.
        /// </summary>
        /// <param name="relation">
        /// Relation where you have to chande PostalCode.
        /// </param>
        /// <param name="context">
        /// Database context
        /// </param>
        /// <returns>
        /// String representation of new PostalCode.
        /// </returns>
        public static string ChangeCode(Relation relation, ApplicationDbContext context)
        {
            var code = relation.RelationAddresses[0].PostalCode;
            var oldCode = code.ToLower();
            var countryMask = context.Country.FirstOrDefault(c => c.Id == relation.RelationAddresses[0].CountryId).PostalCodeFormat;

            var pattern = CodeParser.ParseCode(countryMask);
            oldCode = CodeParser.DeleteSpecSymbols(oldCode);
            var isMatch = pattern != null && Regex.IsMatch(oldCode, pattern);

            char symbol = ' ';
            int symbolIndex = 0;

            string result = @"";

            if (isMatch)
            {
                CodeParser.GetSymbol(countryMask, ref symbol, ref symbolIndex);
                countryMask = countryMask.Remove(symbolIndex, 1);
                CodeParser.CreateNewCode(countryMask, oldCode, ref result);
                result = result.Insert(4, symbol.ToString());
            }
            else
            {
                result = code;
            }

            return result;
        }

        /// <summary>
        /// Generate pattern based on PostalCodeFormat from database.
        /// </summary>
        /// <param name="format">
        /// Representation of PostalCodeFormat.
        /// </param>
        /// <returns>
        /// Pattern for creating new code.
        /// </returns>
        private static string ParseCode(string format)
        {
            if (format == null)
            {
                return null;
            }

            string pattern = @"";

            for (int i = 0; i < format.Length; i++)
            {
                switch (Char.ToLower(format[i]))
                {
                    case 'n':
                        pattern += "[0-9]";
                        break;
                    case 'l':
                        pattern += "[a-z]";
                        break;
                }
            }
            return pattern;
        }

        private static string DeleteSpecSymbols(string code)
        {
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == ' ' || code[i] == '-' || code[i] == '_')
                {
                    code = code.Remove(i, 1);
                }
            }

            return code;
        }

        /// <summary>
        /// Find if PostalCodeFormat contains specific symbols.
        /// </summary>
        /// <param name="input">
        /// Code sent by user.
        /// </param>
        /// <param name="symbol">
        /// Container for saving symbol.
        /// </param>
        /// <param name="symbolIndex">
        /// Container for saving symbol's index.
        /// </param>
        private static void GetSymbol(string input, ref char symbol, ref int symbolIndex)
        {
            if (input.Contains('-'))
            {
                symbol = '-';
                symbolIndex = input.IndexOf(symbol);
            }
            else if (input.Contains(' '))
            {
                symbol = ' ';
                symbolIndex = input.IndexOf(symbol);
            }
            else if (input.Contains('_'))
            {
                symbol = '_';
                symbolIndex = input.IndexOf(symbol);
            }
        }

        /// <summary>
        /// Creating new code comparing code sent by user with generated mask based on database.
        /// </summary>
        /// <param name="countryMask">
        /// Pattern generated for different country.
        /// </param>
        /// <param name="oldCode">
        /// Code sent by user.
        /// </param>
        /// <param name="str">
        /// Variable for containing result.
        /// </param>
        private static void CreateNewCode(string countryMask, string oldCode, ref string str)
        {
            for (int i = 0; i < oldCode.Length; i++)
            {
                if (Char.IsSymbol(countryMask[i]))
                {
                    continue;
                }
                else if (Char.IsUpper(countryMask[i]))
                {
                    str += Char.ToUpper(oldCode[i]);
                }
                else
                {
                    str += Char.ToLower(oldCode[i]);
                }
            }
        }
    }
}
