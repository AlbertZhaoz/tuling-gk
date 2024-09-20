using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tuling.GkOne.NoMvvm.Helper
{
    public class ScreenShotHelper
    {
        public static void CaptureScreenAndSave(bool isManualShot = false, bool isRemindInfo = true, WaterMarkParam waterMarkParam = null)
        {
            try
            {
                var imgs = ScreenShot.CaptureAllScreen(waterMarkParam);
                //考虑用户使用截图结果应该分析的是沿时间所有图片，因此captureType标识在文件名称中而不是单独创建文件夹区分
                var captureType = isManualShot ? "手动截图" : "自动截图";
                string sPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenShot");
                string sName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                var remindInfo = $"截图成功，保存至";
                imgs.ForEach(p =>
                {
                    var fullName = Path.Combine(sPath, $"{sName}_{captureType}_Screen{p.ScreenId}.jpg");
                    p.Image.Save(fullName);
                    remindInfo += $"{Environment.NewLine}{fullName}";
                });

                if (isManualShot && isRemindInfo)
                {
                    MessageBox.Show(remindInfo);
                }
            }
            catch (Exception ex)
            {
                var msg = "截图异常";
            }
        }


        public static void CaptureFullScreenAndSave(bool isManualShot = false, bool isRemindInfo = true, WaterMarkParam waterMarkParam = null)
        {
            try
            {
                var img = ScreenShot.CaptureFullScreen(waterMarkParam);
                //考虑用户使用截图结果应该分析的是沿时间所有图片，因此captureType标识在文件名称中而不是单独创建文件夹区分
                var captureType = isManualShot ? "手动截图" : "自动截图";
                //选择保存目录&保存
                var fullName = string.Empty;
                if (isManualShot)
                {
                    var dialog = new FolderBrowserDialog();
                    dialog.Description = "请选择保存路径";
                    dialog.RootFolder = Environment.SpecialFolder.Desktop;
                    var baseDir = string.Empty;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        baseDir = dialog.SelectedPath;
                    }
                    else
                    {
                        return;
                    }
                    var frm = new SetImageNameForm();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    var sName = frm.imageName;
                    fullName = Path.Combine(baseDir, $"{sName}.jpg");
                }
                else
                {
                    string sPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenShot");
                    string sName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    if (!Directory.Exists(sPath))
                    {
                        Directory.CreateDirectory(sPath);
                    }
                    fullName = Path.Combine(sPath, $"{sName}_{captureType}_Screen.jpg");
                }

                img.Save(fullName);
                var remindInfo = $"截图成功，保存至";
                remindInfo += $"{Environment.NewLine}{fullName}";

                if (isManualShot && isRemindInfo)
                {
                    MessageBox.Show(remindInfo);
                }
            }
            catch (Exception ex)
            {
                var msg = "截图异常";
            }
        }
    }

    public class ScreenShot
    {
        /// <summary>
        ///  截取所有屏幕(一个屏幕一个图片)
        /// </summary>
        /// <param name="onlyWorkingArea">是否只截取工作区域(不包含任务栏)</param>
        /// <returns></returns>
        public static List<ScreenImage> CaptureAllScreen(WaterMarkParam waterMarkParam = null, bool onlyWorkingArea = false)
        {
            List<ScreenImage> screenImages = new List<ScreenImage>();
            Screen[] scs = Screen.AllScreens;
            for (int i = 0; i < scs.Length; i++)
            {
                var scImg = new ScreenImage()
                {
                    ScreenId = i,
                    Image = CaptureScreen(i, waterMarkParam, onlyWorkingArea),
                };
                screenImages.Add(scImg);
            }
            return screenImages;
        }


        public static Bitmap CaptureScreen(int screenID = 0, WaterMarkParam waterMarkParam = null, bool onlyWorkingArea = false)
        {
            Screen[] scs = Screen.AllScreens;
            var sc = scs[screenID];
            Rectangle captureArea = sc.Bounds;//截取整个屏幕
            Point upperLeftPoint = sc.Bounds.Location;
            if (onlyWorkingArea)
            {
                //截取工作区
                captureArea = sc.WorkingArea;
                upperLeftPoint = sc.WorkingArea.Location;
            }
            var myImage = new Bitmap(captureArea.Width, captureArea.Height);
            Graphics g = Graphics.FromImage(myImage);
            g.CopyFromScreen(upperLeftPoint, new Point(0, 0), new Size(captureArea.Width, captureArea.Height));
            g.ReleaseHdc(g.GetHdc());
            if (waterMarkParam != null)
            {
                myImage = AddWaterMark(myImage,waterMarkParam);
            }

            return myImage;
        }

        public static string Bracket(string str)
        {
            return $"[{str}]";
        }

        public static Bitmap AddWaterMark(Bitmap srcImg, WaterMarkParam waterMark)
        {
            try
            {
                if (waterMark == null || string.IsNullOrEmpty(waterMark.MarkContext) || waterMark.FontSize <= 0)
                {
                    var msg = "水印设置无效";
                    if (waterMark == null)
                    {
                        msg += "，水印设置为空。";
                    }
                    else
                    {
                        msg = $"，内容为空或是字体大小异常。水印内容：{Bracket(waterMark.MarkContext)},字体大小：{Bracket(waterMark.FontSize.ToString())}";
                    }
                    return srcImg;
                }
                Bitmap targetImg = new Bitmap(srcImg);

                int width = targetImg.Width;
                int height = targetImg.Height;

                string markContext = waterMark.MarkContext;
                Graphics g = Graphics.FromImage(targetImg);
                g.DrawImage(targetImg, 0, 0, width, height);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g.DrawImage(srcImg, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);

                Font font = new Font("微软雅黑", waterMark.FontSize, FontStyle.Bold);

                SizeF crSize = new SizeF();
                crSize = g.MeasureString(markContext, font);


                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(120, 177, 171, 171));


                //π/4即旋转角度45  计算位置忽略文本高度 只考虑文本宽度 
                var x = (float)(width / 2 - (crSize.Width / 2) * Math.Cos(Math.PI / 4));//水平处于中间位置

                var y = (float)(height / 2 + (crSize.Width / 2) * Math.Sin(Math.PI / 4));
                g.TranslateTransform(x, height / 2);

                g.RotateTransform(-45);

                g.DrawString(markContext, font, solidBrush, new PointF(0, 0));
                return targetImg;
            }
            catch (Exception ex)
            {
                return srcImg;
            }
        }

        /// <summary>
        /// 截图整个大屏，两块屏一张图
        /// </summary>
        /// <returns></returns>
        public static Bitmap CaptureFullScreen(WaterMarkParam waterMarkParam = null, bool onlyWorkingArea = false)
        {
            Screen[] scs = Screen.AllScreens;

            int imageWidth = 0;
            int imageHeight = 0;
            Point upperLeftPoint = scs[0].Bounds.Location;
            for (int i = 0; i < scs.Length; i++)
            {
                imageWidth += scs[i].Bounds.Width;
                imageHeight = scs[i].Bounds.Height;
            }

            if (onlyWorkingArea)
            {
                //TODO:
            }
            var myImage = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(myImage);
            g.CopyFromScreen(upperLeftPoint, new Point(0, 0), new Size(imageWidth, imageHeight));
            g.ReleaseHdc(g.GetHdc());
            if (waterMarkParam != null)
            {
                myImage = AddWaterMark(myImage,waterMarkParam);
            }

            return myImage;
        }


    }

    public class WaterMarkParam
    {
        public string MarkContext
        {
            get;
            set;
        }

        public int FontSize
        {
            get;
            set;
        }
    }

    public class ScreenImage
    {
        public int ScreenId
        {
            get;
            set;
        }

        public Bitmap Image
        {
            get;
            set;
        }
    }
}
