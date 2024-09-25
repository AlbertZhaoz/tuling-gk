using System;
using System.Collections.Generic;
using System.Text;

namespace VOL.Core.Utilities
{
    /// <summary>
    /// 根据各种规则自动生成单号
    /// </summary>
    public static class AutoCode
    {
        ///<summary>
        /// 生成单号
        /// 生成单号
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="length">长度</param>
        /// <param name="isDate">是否包含日期</param>
        /// <param name="isRandom">是否包含随机数</param>
        /// <returns></returns>
        public static string GetCode(string prefix, string suffix,int length = 0, bool isDate =true, bool isRandom = false)
        {
            string code = prefix;

            if (isDate)
            {
                code += DateTime.Now.ToString("yyyyMMdd");
            }

            if (isRandom)
            {
                code += new Random().Next(1000, 9999);
            }

            code += suffix;

            return code.PadRight(length, '0');
        }
    }
}
