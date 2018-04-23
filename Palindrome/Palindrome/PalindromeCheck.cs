using System;
using System.Text;

namespace Palindrome
{
    public class PalindromeCheck
    {
        public bool IsPalindrome(string str)
        {
            string check = RemovePunctuation(str).ToLower().Replace(" ", String.Empty);
            if (check.Length <= 1)
            {
                return true;
            }
            else
            {
                int first = 0;
                int last = check.Length - 1;
                while (true)
                {
                    if (first > last)
                    {
                        return true;
                    }
                    char a = check[first];
                    char b = check[last];
                    if (a != b)
                    {
                        return false;
                    }
                    first++;
                    last--;
                }
            }
        }

        public string RemovePunctuation(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
