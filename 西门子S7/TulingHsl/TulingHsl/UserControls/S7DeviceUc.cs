using DevExpress.XtraEditors;
using HslCommunication.Profinet.Siemens;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TulingHsl.Helper;
using TulingHsl.Models;

namespace TulingHsl.UserControls
{
    public partial class S7DeviceUc : DevExpress.XtraEditors.XtraUserControl
    {
        public S7Device _s7Device;
        public event Action<S7DeviceUc> RefreshChooseS7DeviceAction;

        public S7DeviceUc(S7Device s7Device)
        {
            InitializeComponent();
            InitUi(s7Device);
        }

        private void InitUi(S7Device s7Device)
        {
            _s7Device = s7Device;
            this.labelName.Text = _s7Device.Name;
            this.labelType.Text = Enum.GetName(typeof(SiemensPLCS), _s7Device.Type);
            this.labelIp.Text = _s7Device.Ip+":"+_s7Device.Port;
            this.uiLightStatus.State = _s7Device.IsConnected ? UILightState.On : UILightState.Off;
        }

        public void RefreshCheckBox()
        {
            uiCheckBox1.Checked = _s7Device.IsSelected;
        }

        public void RefreshStatus()
        {
            Invoke(new Action(()=>{ 
                this.uiLightStatus.State = _s7Device.IsConnected ? UILightState.On : UILightState.Off;
            }));
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (uiCheckBox1.Checked)
            {
                RefreshChooseS7DeviceAction?.Invoke(this);
            }
        }
    }
}
