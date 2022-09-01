using DevExpress.XtraEditors;
using Otel_01.Entity;
using Otel_01.Repositories;
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
    public partial class UrunHareketTanimi : Form
    {
        public UrunHareketTanimi()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
     
        Repository<TblUrunHareket> repo = new Repository<TblUrunHareket>();
        TblUrunHareket t = new TblUrunHareket();
        public int id;
        private void UrunHareketTanimi_Load(object sender, EventArgs e)
        {
            //Ürün Listem
            lookUpEditUrunAdi.Properties.DataSource = (from x in db.TblUrun
                                                    select new
                                                    {
                                                        x.UrunID,
                                                        x.UrunAd
                                                    }).ToList();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            t.Urun = int.Parse(lookUpEditUrunAdi.EditValue.ToString());
            t.Tarih = DateTime.Parse(dateEdit1.Text);
            t.HareketTuru = comboBox1.Text;
            t.Miktar = decimal.Parse(TxtMiktar.Text);
            t.Aciklama = TxtAciklama.Text;
            repo.TAdd(t);
            XtraMessageBox.Show("Ürün hareketi sisteme kaydedildi");
        }
    }
}
