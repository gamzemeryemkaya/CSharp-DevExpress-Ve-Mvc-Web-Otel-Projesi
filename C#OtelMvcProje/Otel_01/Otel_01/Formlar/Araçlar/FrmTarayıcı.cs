using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_01.Formlar.Araçlar
{
    public partial class FrmTarayıcı : Form
    {
        public FrmTarayıcı()
        {
            InitializeComponent();
        }

        private void FrmTarayıcı_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.google.com");
        }
    }
}
