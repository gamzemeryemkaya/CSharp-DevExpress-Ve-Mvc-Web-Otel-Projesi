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

namespace Otel_01.Formlar.Urun
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblUrun
                                       select new
                                       {
                                           x.UrunID,
                                           x.TblUrunGrup.UrunGrupAd,
                                           x.UrunAd,
                                           x.Fiyat,
                                           x.Birim,
                                           x.Toplam,
                                          
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
          

            FrmUrunKarti fr = new FrmUrunKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("UrunID").ToString());
            fr.Show();
        }
    }
}
