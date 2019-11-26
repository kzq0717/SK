using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK
{
    class BASE36
    {
        private const string _charList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly char[] _charArray = _charList.ToCharArray();

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long Decode(string input)
        {
            long _result = 0;
            double _pow = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                char _c = input[i];
                int pos = _charList.IndexOf(_c);
                if (pos > -1)
                    _result += pos * (long)Math.Pow(_charList.Length, _pow);
                else
                    return -1;
                _pow++;
            }
            return _result;
        }


        /// <summary>加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Encode(ulong input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            do
            {
                stringBuilder.Append(_charArray[input % (ulong)_charList.Length]);
                input /= (ulong)_charList.Length;
            }
            while (input != 0);
            return Reverse(stringBuilder.ToString());
        }

        private static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
