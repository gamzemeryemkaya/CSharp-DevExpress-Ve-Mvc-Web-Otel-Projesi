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

namespace Otel_01.Formlar.Rezervasyon
{
    public partial class FrmRezervasyonKarti : Form
    {
        public FrmRezervasyonKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
        Repository<TblRezervasyon> repo = new Repository<TblRezervasyon>();
    
        public int id;
        private void FrmRezervasyonKarti_Load(object sender, EventArgs e)
        {
            //Öncellikle Misafir listesi
            lookUpEditMisafir.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad
                                                       }).ToList();
            //2
            lookUpEditKisi2.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad
                                                       }).ToList();
            //3
            lookUpEditKisi3.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad
                                                       }).ToList();
            //4
            lookUpEditKisi4.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad
                                                       }).ToList();

            //Oda Listesi
            lookUpEditOda.Properties.DataSource = (from x in db.TblOda
                                                   select new
                                                   {
                                                       x.OdaID,
                                                       x.OdaNo,
                                                       x.TblDurum.DurumAdı
                                                   }).Where(y => y.DurumAdı == "Aktif").ToList();
            //Durum listesi
            lookUpEditDurum.Properties.DataSource = (from x in db.TblDurum
                                                     select new
                                                     {
                                                         x.DurumID,
                                                         x.DurumAdı
                                                     }).ToList();
            //Güncelleme için var lan bilgileri getirme
            if (id != 0)
            {
                var rezervasyon = repo.Find(x => x.RezervasyonID == id);
                lookUpEditMisafir.EditValue = rezervasyon.Misafir;
                dateEditGiris.Text = rezervasyon.GirisTarih.ToString();
                dateEditCikis.Text = rezervasyon.CikisTarih.ToString();
                numericUpDown1.Value = decimal.Parse(rezervasyon.Kisi.ToString());
                lookUpEditOda.EditValue = rezervasyon.Oda;
                TxtTelefon.Text = rezervasyon.Telefon;
                lookUpEditDurum.EditValue = rezervasyon.Durum;
                TxtAciklama.Text = rezervasyon.Aciklama;
                lookUpEditKisi2.EditValue = rezervasyon.Kisi1;
                lookUpEditKisi3.EditValue = rezervasyon.Kiis2;
                lookUpEditKisi4.EditValue = rezervasyon.Kisi3;
              
            }

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblRezervasyon t = new TblRezervasyon();
            if (numericUpDown1.Value == 1)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            }
            if (numericUpDown1.Value == 2)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            }
            if (numericUpDown1.Value == 3)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                t.Kiis2 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            }
            if (numericUpDown1.Value == 4)
            {
                t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                t.Kiis2 = int.Parse(lookUpEditKisi3.EditValue.ToString());
                t.Kisi3 = int.Parse(lookUpEditKisi4.EditValue.ToString());
            }
           
            t.GirisTarih = DateTime.Parse(dateEditGiris.Text);
            t.CikisTarih = DateTime.Parse(dateEditCikis.Text);
            t.Kisi = numericUpDown1.Value.ToString();
            t.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
            //t.RezervasyonAdSoyad = TxtRezervasyonAdSoyad.Text;
            t.Telefon = TxtTelefon.Text;
            t.Aciklama = TxtAciklama.Text;
            t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            //t.Toplam = decimal.Parse(TxtToplam.Text);
            repo.TAdd(t);
            XtraMessageBox.Show("Rezervasyon başarılı bir şekilde oluşturuldu");
        }

        private void lookUpEditMisafir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditMisafir.EditValue.ToString());
            var telefon = db.TblMisafir.Where(x => x.MisafirID == secilen).Select(y => y.Telefon).FirstOrDefault();
            TxtTelefon.Text = telefon.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var rezervasyon = repo.Find(x => x.RezervasyonID == id);
            if (numericUpDown1.Value == 1)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
            }
            if (numericUpDown1.Value == 2)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
            }
            if (numericUpDown1.Value == 3)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                rezervasyon.Kiis2 = int.Parse(lookUpEditKisi3.EditValue.ToString());
            }
            if (numericUpDown1.Value == 4)
            {
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.Kisi1 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                rezervasyon.Kiis2 = int.Parse(lookUpEditKisi3.EditValue.ToString());
                rezervasyon.Kisi3 = int.Parse(lookUpEditKisi4.EditValue.ToString());
            }
            rezervasyon.GirisTarih = DateTime.Parse(dateEditGiris.Text);
            rezervasyon.CikisTarih = DateTime.Parse(dateEditCikis.Text);
            rezervasyon.Kisi = numericUpDown1.Value.ToString();
            rezervasyon.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
            rezervasyon.Telefon = TxtTelefon.Text;
            rezervasyon.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            rezervasyon.Aciklama = TxtAciklama.Text;
            repo.TUpdate(rezervasyon);
            XtraMessageBox.Show("Rezervasyon başarılı bir şekilde güncellendi");


        }
    }
}
