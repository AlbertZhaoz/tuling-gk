using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuling.GkOne.NoMvvm.Ucs
{
    public partial class PaintUc : DevExpress.XtraEditors.XtraUserControl
    {
        public PaintUc()
        {
            InitializeComponent();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            // 创建画板,这里的画板是由 panelControl1 提供的.
            Graphics g = e.Graphics; 
            // 定义了一个蓝色,宽度为的画笔
            Pen p = new Pen(Color.Blue, 2);
            // 在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            g.DrawLine(p, 10, 10, 100, 100);
            // 在画板上画矩形,起始坐标为(10,10),宽为,高为 100
            g.DrawRectangle(p, 10, 10, 100, 100);
            // 在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为 100
            g.DrawEllipse(p, 10, 10, 100, 100);
            g.DrawEllipse(p, 120, 10, 100, 100);

            //用渐变色填充
            Rectangle rect = new Rectangle(10, 200, 200, 200);//定义矩形,参数为起点横纵坐标以及其长和宽
            rect.Location = new Point(10, 200);
            LinearGradientBrush b3 = new  LinearGradientBrush(rect, Color.Yellow , Color.Black , LinearGradientMode.Horizontal);
            g.FillRectangle(b3, rect);

            p.Dispose();
        }

        public void PaintPanel()
        {
            // 使用 CreateGraphics 方法获取 Panel 的 Graphics 对象
            Graphics g = panelControl2.CreateGraphics();

            // 创建画笔 红色画笔，线条宽度为2
            Pen pen = new Pen(Color.Red, 2);  

            // 定义矩形 矩形的位置和大小
            Rectangle rect = new Rectangle(10, 10, 100, 50); 

            // 绘制矩形
            g.DrawRectangle(pen, rect);

            // 释放 Graphics 对象
            g.Dispose();
            // 画笔资源也需要释放
            pen.Dispose();
        }

        private void PaintUc_Load(object sender, EventArgs e)
        {
            // 开启双缓冲，减少闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }
}
