using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace VOL.Core.Utilities
{
    public static class VierificationCodeServices
    {        //验证码字体集合
        private static readonly string[] fonts = null;

        static VierificationCodeServices()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fonts = new string[] { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            }
            else
            {
                fonts = new string[] { "Arial", "Arial", "宋体", "宋体" };
            }
        }

       
        public static T GetRandom<T>(this Random random, T[] tArray)
        {
            if (random == null) random = new Random();
            return tArray[random.Next(tArray.Length)];
        }
    }
}