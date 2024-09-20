using System;
using System.Collections.Generic;
using Python.Runtime;
using System.IO;
using System.Threading.Tasks;
using Masuit.Tools;
using Tuling.GkOne.NoMvvm.Helper;

namespace Tuling.GkOne.NoMvvm.Ucs
{
    public partial class PythonUc : DevExpress.XtraEditors.XtraUserControl
    {
        public PythonUc()
        {
            InitializeComponent();
            LoadPythonEnv();
        }

        private void LoadPythonEnv()
        {
            // 加载 Python 环境
            string pythonEnvPath = @"D:\Anaconda\envs\ForNet";
            string pythonSelfScriptPath = AppDomain.CurrentDomain.BaseDirectory + "Pythons";
            Runtime.PythonDLL = Path.Combine(pythonEnvPath, "python38.dll");
            PythonEngine.PythonHome = Path.Combine(pythonEnvPath, "python.exe");
            PythonEngine.PythonPath = $"{pythonEnvPath}\\Lib\\site-packages;{pythonEnvPath}\\Lib;" +
                $"{pythonEnvPath}\\DLLs;{pythonSelfScriptPath}";
            PythonEngine.Initialize();
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            try
            {
                using (Py.GIL())
                {
                    dynamic py = Py.Import("hello");
                    dynamic result = py.sayHello();

                    UpdateUi(() =>
                    {
                        memoEdit1.Text += result.ToString()+"\r\n";
                    });
                }
            }
            catch (Exception exception)
            {
                TulingLogHelper.Error("Python invoke sayHello error", exception);
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

            try
            {
                using (Py.GIL())
                {
                    dynamic py = Py.Import("hello");
                    dynamic result = py.add(textEdit1.Text.ToInt64(), textEdit2.Text.ToInt64());

                    UpdateUi(() =>
                    {
                        memoEdit1.Text += result.ToString()+"\r\n";
                    });
                }
            }
            catch (Exception exception)
            {
                TulingLogHelper.Error("Python invoke add error", exception);
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            // 使用第三方库 numpy
            // 必须在 PythonEngine.PythonPath 中包含 DLLs 路径，不然会抛 No module named '_ctypes'
            // https://github.com/pythonnet/pythonnet/issues/932
            try
            {
                using (Py.GIL())
                {
                    dynamic np = Py.Import("numpy");
                    memoEdit1.Text += "cos(2pi):"+np.cos(np.pi * 2).ToString()+"\r\n";

                    dynamic sin = np.sin;
                    memoEdit1.Text += "sin(5):"+sin(5).ToString()+"\r\n";

                    dynamic a = np.array(new List<float> { 1, 2, 3 });
                    memoEdit1.Text +=  "List<float> type is:"+a.dtype.ToString()+"\r\n";
                }
            }
            catch (Exception exception)
            {
                TulingLogHelper.Error("Python invoke numpy error", exception);
            }
        }

        private void UpdateUi(Action action)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(action);
            }
        }
    }
}
