using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace VOL.Core.Utilities
{
    public static class VierificationCode
    {
        private static readonly string[] _chars = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static string RandomText()
        {
            string code = "";//产生的随机数
            int temp = -1;
            Random rand = new Random();
            for (int i = 1; i < 5; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(61);
                if (temp != -1 && temp == t)
                {
                    return RandomText();
                }
                temp = t;
                code += _chars[t];
            }
            return code;
        }     
    }
}
