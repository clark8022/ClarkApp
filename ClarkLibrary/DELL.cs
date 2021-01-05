using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarkLibrary
{
    public class DELL
    {
        /// <summary>
        /// Verifies if parentheses are balanced in a string.
        /// </summary>
        /// <param name="input">The input string to be verified.</param>
        /// <param name="leftParenthesis">The left parenthesis, which is default to '('.</param>
        /// <param name="rightParenthesis">The right parenthesis, which is default to ')'.</param>
        /// <returns>Attention, blank or empty string is considered as not balanced.</returns>
        public static bool VerifyParenthesesBalancing(string input)
        {
            bool balanced = true;
            char leftParenthesis = '(';
            char rightParenthesis = ')';

            // empty or blank is not available.
            if (input == null || string.IsNullOrEmpty(input.Trim()))
                return false;

            // Not contains (, false.
            if (!input.Contains(leftParenthesis.ToString()))
                return false;

            // Not contains ), false.
            if (!input.Contains(rightParenthesis.ToString()))
                return false;

            // the first should be (
            if (input.IndexOf(leftParenthesis) > input.IndexOf(rightParenthesis))
                return false;

            // the last should be )
            if (input.LastIndexOf(leftParenthesis) > input.LastIndexOf(rightParenthesis))
                return false;

            // total count of ( should be same as count of )
            if (Count(input, leftParenthesis) != Count(input, rightParenthesis))
                return false;

            return balanced;
        }

        //private static int Count(string str, char c)
        //{
        //  return  str.Count(x => x == c);
        //}

        private static int Count(string str, char c)
        {
            char[] cs = str.ToArray();
            int count = 0;
            for (int i = 0; i < cs.Length; i++)
            {
                if (cs[i] == c)
                    count++;
            }
            return count;
        }
    }
}
