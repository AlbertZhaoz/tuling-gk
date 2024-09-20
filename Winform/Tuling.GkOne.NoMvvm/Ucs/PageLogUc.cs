using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tuling.GkOne.NoMvvm.Models;

namespace Tuling.GkOne.NoMvvm.Ucs
{
    public partial class PageLogUc : DevExpress.XtraEditors.XtraUserControl
    {
        // 每页记录数、当前页码、总页数
        private int _pageSize = 20, _page = 1, _totalPage=1; 
        // 是否由用户改变每页记录数或页码，注意何时使用该变量，以及何时赋值
        private bool _isChangeByUser = true;   
        // 总记录数
        private long _totalRecord = 999; 
        // 记录列表
        private BindingList<LogModel> _records;  

        public PageLogUc()
        {
            InitializeComponent();
            InitUI();
        }

        private void  InitUI()
        {
            dtStart.DateTime = DateTime.Now.AddDays(-1);
            dtEnd.DateTime = DateTime.Now;
            
            barStaticItemStatus.Caption = "数据加载中...";
            var records = FindRecords();
            _totalRecord = records.Count;
            _records = new BindingList<LogModel>(records);
            SetPage(1,_totalRecord);
            BindDataSource();
            barStaticItemStatus.Caption = "数据加载成功...";
        }

        private void btnFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetPage(1,_totalRecord);
            BindDataSource();
        }

        private void btnPrevious_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetPage(_page-1,_totalRecord);
            BindDataSource();
        }

        private void btnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetPage(_page+1,_totalRecord);
            BindDataSource();
        }

        private void btnLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetPage(_totalPage,_totalRecord);
            BindDataSource();
        }

        private void txtPage_EditValueChanged(object sender, EventArgs e)
        {
            if (!_isChangeByUser)
            {
                return;
            }
            if (txtPage.EditValue.ToString() == "")
            {
                SetPage(1,_totalRecord);
                return;
            }
            int page = Convert.ToInt32(txtPage.EditValue);
            if (page < 1)
            {
                SetPage(1,_totalRecord);
            }
            else if (page > _totalPage)
            {
                SetPage(_totalPage,_totalRecord);
            }
            else
            {
                SetPage(page,_totalRecord);
            }
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            // 模拟从数据库获取数据 select count(*) = RecordsCount
            var records = FindRecords().Where(x=>x.OperationTime >= dtStart.DateTime && x.OperationTime <= dtEnd.DateTime).ToList();
            _totalRecord = records.Count;
            _records = new BindingList<LogModel>(records); 
            SetPage(1,_totalRecord);
            BindDataSource();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtStart.DateTime = DateTime.Now.AddDays(-1);
            dtEnd.DateTime = DateTime.Now;
        }

        private List<LogModel> FindRecords()
        {
            var logModels = new List<LogModel>();
            Random random = new Random();
            DateTime now = DateTime.Now;

            for (int i = 0; i < 2000; i++)
            {
                TimeSpan randomTimeSpan = new TimeSpan(0, random.Next(0, 7 * 24 * 60), 0);  // 生成小于一周的随机时间间隔
                DateTime randomTime = now - randomTimeSpan;  // 将随机时间间隔减去当前时间得到过去一周内的随机时间

                logModels.Add(new LogModel() { 
                    Id = i, 
                    UserName = "Admin",
                    Operation = $"登录{i}",
                    OperationTime = randomTime,
                    IpAddress = "127.0.0.1"
                });
            }

            return logModels;

        }

        private void PageLogUc_Load(object sender, EventArgs e)
        {
            // 开启双缓冲，减少闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void BindDataSource()
        {
            gridControlLog.DataSource = _records.Skip((_page - 1) * _pageSize).Take(_pageSize).ToList();
        }

        /// <summary>
        /// 设置分页组件内部各控件状态，以及相关文字信息
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="total">总记录数</param>
        public void SetPage(int page, long total)
        {
            _totalPage = (int)Math.Ceiling((double)total / _pageSize);
            if (_totalPage <= 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                txtPage.Enabled = false;
            }
            else if (page == 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
                btnLast.Enabled = true;
                txtPage.Enabled = true;
            }
            else if (page == _totalPage)
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                txtPage.Enabled = true;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;
                txtPage.Enabled = true;
            }
            _page = page;
            _isChangeByUser = false;
            txtPage.EditValue = page;
            _isChangeByUser = true;
            if (total == 0)
            {
                lblSummary.Caption = "没有记录";
            }
            else
            {
                lblSummary.Caption = $"共 {_totalPage:N0} 页　第 {(_pageSize * (page - 1) + 1):N0} 到 {(page == _totalPage ? total : _pageSize * page):N0} 条　共 {total:N0} 条";
            }
        }
    }
}
