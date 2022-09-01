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

namespace Otel_01.Formlar.Misafir
{
    public partial class FrmMisafirListesi : Form
    {
        public FrmMisafirListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
        private void FrmMisafirListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblMisafir
                                       select new
                                       {
                                           x.MisafirID,
                                           x.AdSoyad,
                                           x.TC,
                                           x.Telefon,
                                           x.Mail,
                                           x.sehir,
                                           //x.ilce,
                                          
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMisafir fr = new FrmMisafir();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("MisafirID").ToString());
            fr.Show();
        }
    }
}
