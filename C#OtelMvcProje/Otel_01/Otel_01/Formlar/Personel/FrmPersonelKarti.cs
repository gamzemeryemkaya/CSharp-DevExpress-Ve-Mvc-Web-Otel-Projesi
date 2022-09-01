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

namespace Otel_01.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities1 db = new DbOtelEntities1();
        public int id;
        Repository<TblPersonel> repo = new Repository<TblPersonel>();
        TblPersonel t = new TblPersonel();
        private void FrmPersonelKarti_Load(object sender, EventArgs e)

        {
            this.Text = id.ToString();
            if(id != 0)
            {
                var personel = repo.Find(x => x.PersonelID == id);
                TxtAdSoyad.Text = personel.AdSoyad;
                TxtTC.Text = personel.TC;
                TxtAdres.Text = personel.Adres;
                TxtTelefon.Text = personel.Telefon;
                TxtMail.Text = personel.Mail;
                dateEditGiris.Text = personel.IseGırısTarih.ToString();
                dateEditCikis.Text = personel.IstenCikisTarih.ToString();
                TxtAciklama.Text = personel.Aciklama;
                TxtSifre.Text = personel.Sifre;
                PictureEditKimlikOn.Image = Image.FromFile(personel.KimlikOn);
                PictureEditKimlikArka.Image = Image.FromFile(personel.KimlikArka);
                labelControl15.Text=personel.KimlikOn;
                labelControl16.Text = personel.KimlikArka;
                lookUpEditDepartman.EditValue = personel.Departman;
                lookUpEditGorev.EditValue = personel.Gorev;
            }
            

            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman
                                                         select new
                                                         {
                                                             x.DepartmanID,
                                                             x.DepartmanAd
                                                         }
                                                         ).ToList();
            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev
                                                         select new
                                                         {
                                                             x.GorevID,
                                                             x.GorevAd
                                                         }
                                                         ).ToList();

        }
           

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
           
            
            t.AdSoyad = TxtAdSoyad.Text;
            t.TC = TxtTC.Text;
            t.Adres = TxtAdres.Text;
            t.Telefon = TxtTelefon.Text;
            t.Mail = TxtMail.Text;
            t.IseGırısTarih = DateTime.Parse( dateEditGiris.Text);
            t.Departman =int.Parse(lookUpEditDepartman.EditValue.ToString());
            t.Gorev =int.Parse (lookUpEditGorev.EditValue.ToString());
            t.Aciklama = TxtAciklama.Text;
            t.KimlikOn = PictureEditKimlikOn.GetLoadedImageLocation();
            t.KimlikArka= PictureEditKimlikArka.GetLoadedImageLocation();
            t.Sifre = TxtSifre.Text;
            t.Durum = 1;
            repo.TAdd(t);
            XtraMessageBox.Show("Personel başarılı bir şekilde sisteme kaydedildi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.PersonelID == id);
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTC.Text;
            deger.Adres = TxtAdres.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.IseGırısTarih = DateTime.Parse(dateEditGiris.Text);
            deger.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            deger.Aciklama = TxtAciklama.Text;
            deger.Mail= TxtMail.Text;
            deger.Sifre = TxtSifre.Text;
            deger.KimlikOn = labelControl15.Text;
            deger.KimlikArka = labelControl16.Text;


            repo.TUpdate(deger);
            XtraMessageBox.Show("Personel başarılı bir şekilde güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void PictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            labelControl15.Text = PictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void PictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            labelControl16.Text = PictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }
    }
}
