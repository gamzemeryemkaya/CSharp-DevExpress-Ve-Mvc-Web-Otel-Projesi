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

namespace Otel_01.Formlar.Rezervasyon
{
    public partial class FrmButunRezervasyonlar : Form
    {
        public FrmButunRezervasyonlar()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
        private void FrmButunRezervasyonlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblRezervasyon
                                       select new
                                       {
                                           x.RezervasyonID,
                                           x.TblMisafir.AdSoyad,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Kisi,
                                           x.TblOda.OdaNo,
                                           x.Telefon,
                                           x.TblDurum.DurumAdı
                                       }).ToList();
        }
        

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            FrmRezervasyonKarti fr = new FrmRezervasyonKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("RezervasyonID").ToString());
            fr.Show();
        }
    }
}
