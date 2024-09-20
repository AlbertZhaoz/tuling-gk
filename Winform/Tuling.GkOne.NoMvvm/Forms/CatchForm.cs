using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuling.GkOne.NoMvvm.Forms
{
    public partial class CatchForm : DevExpress.XtraEditors.XtraForm
    {
        #region 用户变量
        private Point DownPoint = Point.Empty;//记录鼠标按下坐标，用来确定绘图起点
        private bool CatchFinished = false;//用来表示是否截图完成
        private bool CatchStart = false;//表示截图开始
        private Bitmap originBmp;//用来保存原始图像
        private Rectangle CatchRect;//用来保存截图的矩形
        #endregion

        public CatchForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 鼠标右键点击结束截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatchForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        /// <summary>
        /// 鼠标右键点击结束截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatchForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!CatchStart)
                {//如果捕捉没有开始
                    CatchStart = true;
                    DownPoint = new Point(e.X, e.Y);//保存鼠标按下坐标
                }
            }
        }

        private void CatchForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (CatchStart)
            {
                //如果捕捉开始
                Bitmap destBmp = (Bitmap)originBmp.Clone();//新建一个图片对象，并让它与原始图片相同
                Point newPoint = new Point(DownPoint.X, DownPoint.Y);//获取鼠标的坐标
                Graphics g = Graphics.FromImage(destBmp);//在刚才新建的图片上新建一个画板
                Pen p = new Pen(Color.Blue,1);
                int width = Math.Abs(e.X - DownPoint.X), height = Math.Abs(e.Y - DownPoint.Y);//获取矩形的长和宽
                if (e.X < DownPoint.X)
                {
                    newPoint.X = e.X;
                }
                if (e.Y < DownPoint.Y)
                {
                    newPoint.Y = e.Y;
                }
                CatchRect = new Rectangle(newPoint,new Size(width,height));//保存矩形
                g.DrawRectangle(p,CatchRect);//将矩形画在这个画板上
                g.Dispose();//释放目前的这个画板
                p.Dispose();
                Graphics g1 = this.CreateGraphics();//重新新建一个Graphics类
                //如果之前那个画板不释放，而直接g=this.CreateGraphics()这样的话无法释放掉第一次创建的g,因为只是把地址转到新的g了．如同string一样
                g1 = this.CreateGraphics();//在整个全屏窗体上新建画板
                g1.DrawImage(destBmp,new Point(0,0));//将刚才所画的图片画到这个窗体上
                //这个也可以属于二次缓冲技术，如果直接将矩形画在窗体上，会造成图片抖动并且会有无数个矩形．
                g1.Dispose();
                destBmp.Dispose();//要及时释放，不然内存将会被大量消耗
                
            }
        }

        private void CatchForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (CatchStart)
                {
                    CatchStart = false;
                    CatchFinished = true;
                  
                }
            }
        }

        private void CatchForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left&&CatchFinished)
            {
                if (CatchRect.Contains(new Point(e.X, e.Y)))
                {
                    Bitmap CatchedBmp = new Bitmap(CatchRect.Width, CatchRect.Height);//新建一个于矩形等大的空白图片
                    Graphics g = Graphics.FromImage(CatchedBmp);
                    g.DrawImage(originBmp, new Rectangle(0, 0, CatchRect.Width, CatchRect.Height), CatchRect, GraphicsUnit.Pixel);
                    //把orginBmp中的指定部分按照指定大小画在画板上
                    Clipboard.SetImage(CatchedBmp);//将图片保存到剪贴板
                    g.Dispose();
                    CatchFinished = false;
                    this.BackgroundImage = originBmp;
                    CatchedBmp.Dispose();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void CatchForm_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            //以上两句是为了设置控件样式为双缓冲，这可以有效减少图片闪烁的问题，关于这个大家可以自己去搜索下
            originBmp = new Bitmap(this.BackgroundImage);//BackgroundImage为全屏图片，我们另用变量来保存全屏图片
        }
    }
}