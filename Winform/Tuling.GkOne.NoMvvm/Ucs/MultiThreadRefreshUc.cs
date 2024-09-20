using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuling.GkOne.NoMvvm.Forms
{
    public partial class MultiThreadRefreshUc : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _start;
        private Thread _randomThread;
        public Action<string> TransformTextAction;

        public MultiThreadRefreshUc()
        {
            InitializeComponent();
        }

        public void ToggleUpdateUiByRandom()
        {
            // 切换状态
            _start = !_start; 

            if (_start)
            {
                GenerateRandomByThread();
                GenerateRandomByTask().GetAwaiter();
            }
            else
            {
                _randomThread?.Abort();
            }
        }


        private void GenerateRandomByThread()
        {
            _randomThread = new Thread(()=>{ 
                while (_start)
                {
                    var randomNumber = new Random().Next(1,100).ToString();

                    UpdateUi(()=>{ 
                         textEditThread.Text = randomNumber.ToString();
                    });
                    
                    Thread.Sleep(300);
                }
            });

            _randomThread.Start();
        }

        private async Task GenerateRandomByTask()
        {
            await Task.Run(async () =>
            {
                while (_start)
                {
                    var randomNumber = new Random().Next(1, 100).ToString();
            
                    UpdateUi(() =>
                    {
                        textEditTask.Text = randomNumber.ToString();

                        TransformTextAction?.Invoke(this.textEditTask.Text);
                    });
            
                    await Task.Delay(300);
                } 
            });
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
