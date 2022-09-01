using Otel_01.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_01.Formlar.Web
{
    public partial class FrmYeniKayit : Form
    {
        public FrmYeniKayit()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
        private void FrmYeniKayit_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblYeniKayitlar
                                       select new
                                       {
                                           x.AdSoyad,
                                           x.Mail,
                                           x.Telefon
                                       }).ToList();
        }
    }
}
