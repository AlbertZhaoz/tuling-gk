using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Tuling.GkOne.NoMvvm.Helper
{
    public class TulingLogHelper
    {
        private static Logger logger = LogManager.GetLogger("TulingGk");
        public static void Debug(string msg)
        {
            logger.Debug(msg);
        }

        public static void Info(string msg)
        {
            logger.Info(msg);
        }

        public static void Error(string msg, Exception ex = null)
        {
            var errMsg = ex != null ? $"{msg}{Environment.NewLine}{PackExceptionMessage(ex)}" : msg;
            logger.Error(errMsg, ex);
        }


        private static string PackExceptionMessage(Exception ex)
        {
            var message = $"-->Message:{ex.Message}{Environment.NewLine}-->StackTrace:{Environment.NewLine}{ex.StackTrace}";

            if (ex.InnerException == null)
            {
                return message;
            }
            else
            {
                return $"{message}{Environment.NewLine}-->InnerException:{Environment.NewLine}{PackExceptionMessage(ex.InnerException)}";
            }
        }
    }
}
