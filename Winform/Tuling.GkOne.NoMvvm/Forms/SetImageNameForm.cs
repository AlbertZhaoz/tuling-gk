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

namespace Tuling.GkOne.NoMvvm.Helper
{
    public partial class SetImageNameForm : DevExpress.XtraEditors.XtraForm
    {
        public string imageName =string.Empty;

        public SetImageNameForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditImageName.Text))
            {
                MessageBox.Show("请输入窗口名称");
                return;
            }
            imageName=textEditImageName.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}