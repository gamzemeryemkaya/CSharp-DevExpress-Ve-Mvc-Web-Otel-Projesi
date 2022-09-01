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
    public partial class FrmUrunHareketTanimi : Form
    {
        public FrmUrunHareketTanimi()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
        Repository<TblUrunHareket> repo = new Repository<TblUrunHareket>();
        TblUrunHareket t = new TblUrunHareket();
        public int id;
        private void FrmUrunHareketTanimi_Load(object sender, EventArgs e)
        {


            //id değeri
            TxtID.Text = id.ToString();
            TxtID.Enabled = false;

            //Ürün Listem

            lookUpEditUrunAdi.Properties.DataSource = (from x in db.TblUrun
                                                    select new
                                                    {
                                                        x.UrunID,
                                                        x.UrunAd
                                                    }).ToList();

            //Var  olan değerlerin getirilmesi
            if (id != 0)
            {
                var urun = repo.Find(x => x.HareketID == id);
                lookUpEditUrunAdi.EditValue = urun.Urun;
                TxtMiktar.Text = urun.Miktar.ToString();
                TxtAciklama.Text = urun.Aciklama;
                comboBox1.Text = urun.HareketTuru;
                dateEdit1.Text = urun.Tarih.ToString();
            }
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urun = repo.Find(x => x.HareketID == id);
            urun.Urun = int.Parse(lookUpEditUrunAdi.EditValue.ToString());
            urun.Tarih = DateTime.Parse(dateEdit1.Text);
            urun.HareketTuru = comboBox1.Text;
            urun.Miktar = decimal.Parse(TxtMiktar.Text);
            urun.Aciklama = TxtAciklama.Text;
            repo.TUpdate(urun);
            XtraMessageBox.Show("Ürün hareketi başarılı bir şekilde güncellendi");
        }
    }
}
