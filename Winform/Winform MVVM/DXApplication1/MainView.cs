using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        public MainView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();

            fluent.SetBinding(textEdit1,e=>e.Text,v=>v.TextEditContent);
            fluent.SetBinding(textEdit2,e=>e.Text,v=>v.TextEditContent2);
            fluent.BindCommand(simpleButton1,it=>it.ChangeTextEditOne());
        }
    }
}
