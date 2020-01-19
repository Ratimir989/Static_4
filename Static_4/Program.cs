using System;

namespace Static_4
{
    static class StringExtension
    {
        public static string MySubstring(this string str, int beg, int len)
        {
            char[] res = new char[len];
            for (int i = 0; i < len; i++)
                res[i] = str[i + beg];
            return new string(res);
        }
        public static int MyIndexOf(this string str, string value)
        {
            for (int i = 0; i < str.Length - value.Length + 1; i++)
                if (str.MySubstring(i, value.Length) == value)
                    return i;
            return -1;
        }
        public static string MyReplace(this string str, string oldValue, string newValue)
        {
            int i;
            while (str.MyIndexOf(oldValue) >= 0)
            {
                i = str.MyIndexOf(oldValue);
                str = str.Remove(i, oldValue.Length);
                str = str.Insert(i, newValue);
            }
            return str;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello world!";
            Console.WriteLine(str.MySubstring(6, 5));
            Console.WriteLine(str.MyIndexOf("world!"));
            Console.WriteLine(str.MyReplace("l", "I"));

            Console.ReadKey();
        }
    }
}
