using AutoUpdaterDotNET;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Tuling.GkOne.NoMvvm.Forms;
using Tuling.GkOne.NoMvvm.Helper;
using Tuling.GkOne.NoMvvm.Ucs;

namespace Tuling.GkOne.NoMvvm
{
    public partial class TulingGkForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private PageLogUc pageLogUc;
        private PaintUc paintUc;
        private PythonUc pythonUc;
        private bool isHyMisOpen = false;

        public TulingGkForm()
        {
            InitializeComponent();
            InitAction();
        }

        private void InitAction()
        {
            multiThreadRefreshUcOne.TransformTextAction += HandleTransformTextAction;
        }

        private void HandleTransformTextAction(string inputNumber)
        {
            this.labelControl1.Text = inputNumber;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pageLogUc == null)
            {
                pageLogUc = new PageLogUc();
            }

            pageLogUc.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(pageLogUc);
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (paintUc == null)
            {
                paintUc = new PaintUc();
            }

            paintUc.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(paintUc);
        }

        /// <summary>
        /// 跨线程刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            multiThreadRefreshUcOne?.ToggleUpdateUiByRandom();
        }

        private void btnScreen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ScreenShotHelper.CaptureFullScreenAndSave(isManualShot: true);
            }
            catch (Exception ex)
            {
                TulingLogHelper.Error("截图执行错误", ex);
            }
        }



        private void btnCatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();//隐藏当前窗体

            try
            {
                Thread.Sleep(50);//让线程睡眠一段时间，窗体消失需要一点时间
                var CatchForm = new CatchForm();
                Bitmap CatchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);//新建一个和屏幕大小相同的图片         
                Graphics g = Graphics.FromImage(CatchBmp);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));//保存全屏图片
                CatchForm.BackgroundImage = CatchBmp;//将Catch窗体的背景设为全屏时的图片
                if (CatchForm.ShowDialog() == DialogResult.OK)
                {
                    //如果Catch窗体结束,就将剪贴板中的图片放到信息发送框中
                    IDataObject iData = Clipboard.GetDataObject();
                    DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (iData.GetDataPresent(DataFormats.Bitmap))
                    {
                        // 将 myFormat 放到 richEditControl1 中
                        var richTextBoxCatch = new RichTextBox();
                        richTextBoxCatch.Dock = DockStyle.Fill;
                        panelContainer.Controls.Clear();
                        panelContainer.Controls.Add(richTextBoxCatch);
                        Thread.Sleep(50);
                        richTextBoxCatch.Paste(myFormat);
                        //清除剪贴板中的对象
                        Clipboard.Clear();
                    }
                    this.Show();//重新显示窗体
                }
            }
            catch (Exception exception)
            {
                this.Show();//重新显示窗体
            }

        }

        private void btnPython_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pythonUc == null)
            {
                pythonUc = new PythonUc();
            }

            pythonUc.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(pythonUc);
        }

       
        /// <summary>
        /// 低代码生成器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCmd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void TulingGkForm_Load(object sender, EventArgs e)
        {
            barStaticItemVersion.Caption = "版本:" + Application.ProductName + Application.ProductVersion;
        }

        /// <summary>
        /// 自动更新按钮实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AutoUpdater.Start("http://hongxianji.com/basictool/update.xml");
            // 若您不想在更新表单上显示“跳过”按钮，那个么只需在上面的代码中添加以下行即可。
            AutoUpdater.ShowSkipButton = false;

            // 如果要同步检查更新，请在启动更新之前将 Synchronous 设置为 true，如下所示。
            AutoUpdater.Synchronous = false;

            // 显示“以后提醒”按钮，那个么只需在上面的代码中添加以下一行即可。
            AutoUpdater.ShowRemindLaterButton = true;

            //如果要忽略先前设置的“以后提醒”和“跳过”设置，则可以将“强制”属性设置为 true。
            //它还将隐藏“跳过”和“稍后提醒”按钮。如果在代码中将强制设置为true，那么XML文件中的强制值将被忽略。
            AutoUpdater.Mandatory = false;

            //您可以通过添加以下代码来打开错误报告。如果执行此自动更新程序。NET 将显示错误消息，如果没有可用的更新或无法从 web 服务器获取 XML 文件。
            AutoUpdater.ReportErrors = true;

            // 如果服务器 xml 文件的版本大于 AssemblyInfo 中的版本则触发 CheckForUpdateEvent
            AutoUpdater.CheckForUpdateEvent += (args) =>
            {
                if (args.Error == null)
                {
                    // 检测到有可用的更新
                    if (args.IsUpdateAvailable)
                    {
                        DialogResult dialogResult;
                        if (args.Mandatory.Value)
                        {
                            dialogResult =
                                MessageBox.Show(
                                $@"当前有一个新版本{args.CurrentVersion}可用.你正在使用版本{args.InstalledVersion}.点击确认开始更新", @"更新可用",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            dialogResult =
                                MessageBox.Show(
                                $@"当前有一个新版本{args.CurrentVersion}可用.你正在使用版本{args.InstalledVersion}.确认要更新吗?", @"更新可用",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);
                        }

                        if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                        {
                            try
                            {
                                // 触发更新下载
                                if (AutoUpdater.DownloadUpdate(args))
                                {
                                    Application.Exit();
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    if (args.Error is WebException)
                    {
                        MessageBox.Show(
                            @"连接更新服务器失败,请检查网络连接.",
                            @"更新检查失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(args.Error.Message,
                                            args.Error.GetType().ToString(), MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                    }
                }
            };
        }

        private void btnMis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isHyMisOpen)
            {
                MessageBox.Show("通讯软件已经打开，不能重复打开。");

                return;
            }

            var editPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HyMis\\HyLeadTest.exe");

            if (File.Exists(editPath))
            {
                try
                {
                    var misProcess = Process.Start(editPath);
                    misProcess.EnableRaisingEvents = true;
                    misProcess.Exited += (s, args) => 
                    {
                        isHyMisOpen = false;
                        misProcess = null;
                    };

                    isHyMisOpen = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("打开编辑器异常");
                }
            }
            else
            {
                MessageBox.Show($"未在根目录找到{editPath}文件");
            }
        }
    }
}
