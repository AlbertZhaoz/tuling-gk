using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOL.Test.Tool.Common
{
    public class CommandHelper
    {
        public static List<string> DataReceiveList { get; set; } = new List<string>();

        public static List<string> ReturnDataReceiveList()
        {
            return DataReceiveList;
        }

        /// <summary>
        /// 执行单条
        /// </summary>
        /// <param name="command"></param>
        /// <param name="directory"></param>
        public static void ExecuteCmd(string command, string directory = null)
        {
            using (var process = new Process())
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.WorkingDirectory = directory ?? Directory.GetCurrentDirectory();
                process.StartInfo.FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe");

                // Redirects the standard input so that commands can be sent to the shell.
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                //抓取事件
                process.OutputDataReceived += new DataReceivedEventHandler(OutputEventHandler);
                process.ErrorDataReceived += new DataReceivedEventHandler(ErrorEventHandler);
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                DataReceiveList.Clear();

                // Send command and exit.
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine("exit");
                process.StandardInput.AutoFlush = true;
                process.WaitForExit();
            }
        }
        /// <summary>
        /// 批量执行cmd
        /// </summary>
        /// <param name="command"></param>
        public static void ExecuteCmd(List<string> command, string directory = null)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WorkingDirectory = directory ?? Directory.GetCurrentDirectory();//工作目录
                process.StartInfo.CreateNoWindow = true;//隐藏窗口运行
                process.StartInfo.RedirectStandardError = true;//重定向错误流
                process.StartInfo.RedirectStandardInput = true;//重定向输入流
                process.StartInfo.RedirectStandardOutput = true;//重定向输出流
                process.StartInfo.UseShellExecute = false;

                // 设置编码为GBK
                process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("UTF-8");
                process.StartInfo.StandardErrorEncoding = Encoding.GetEncoding("UTF-8");

                //抓取事件
                process.OutputDataReceived += new DataReceivedEventHandler(OutputEventHandler);
                process.ErrorDataReceived += new DataReceivedEventHandler(ErrorEventHandler);
                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                foreach (string com in command)
                {
                    process.StandardInput.WriteLine(com);//输入CMD命令
                    process.StandardInput.AutoFlush = true;
                }
                process.StandardInput.WriteLine("exit");//结束执行，不可或缺
                process.StandardInput.AutoFlush = true;
                process.WaitForExit();
                process.Close();
            }
        }

        private static void OutputEventHandler(Object sender, DataReceivedEventArgs e)
        {
            DataReceiveList.Add($"{e.Data}");
            Console.WriteLine(e.Data);
        }
        private static void ErrorEventHandler(Object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
            //暂时先不报异常
            //Match message = Regex.Match(e.Data, ".*error\\s+nu.*", RegexOptions.IgnoreCase);
            //if (message.Success)
            //{
            //    throw new Exception(e.Data);
            //}
        }
    }
}
