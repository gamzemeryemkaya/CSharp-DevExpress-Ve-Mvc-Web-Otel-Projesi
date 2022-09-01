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

namespace Otel_01.Formlar.Misafir
{
    public partial class FrmMisafir : Form
    {
        public FrmMisafir()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
        Repository<TblMisafir> repo = new Repository<TblMisafir>();
        TblMisafir t = new TblMisafir();
        public int id;
        string resim1, resim2;
        private void FrmMisafir_Load(object sender, EventArgs e)
        {   
            try
            { //Var Olan Kart Bilgileri 
                if (id != 0)
                {
                    var misafir = repo.Find(x => x.MisafirID == id);
                    TxtAdSoyad.Text = misafir.AdSoyad;
                    TxtTC.Text = misafir.TC;
                    TxtAdres.Text = misafir.Adres;
                    TxtTelefon.Text = misafir.Telefon;
                    TxtMail.Text = misafir.Mail;

                    TxtAciklama.Text = misafir.Aciklama;

                    PictureEditKimlikOn.Image = Image.FromFile(misafir.KimlikFoto1);
                    PictureEditKimlikArka.Image = Image.FromFile(misafir.KimlikFoto2);
                    resim1 = misafir.KimlikFoto1;
                    resim2 = misafir.KimlikFoto2;
                    lookUpEditSehir.EditValue = misafir.sehir;
                    lookUpEditUlke.EditValue = misafir.Ulke;
                    //lookUpEditIlce.EditValue = misafir.ilce;

                   
                }
            }
            catch (Exception)
            {

               XtraMessageBox.Show("Bir hata oluştu,lütfen girdiğiniz verileri kontrol ediniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

            //Ülke Listesi
            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlke
                                                    select new
                                                    {
                                                        x.UlkeID,
                                                        x.UlkeAd
                                                    }
                                                         ).ToList();
            //Şehir Listesi
            lookUpEditSehir.Properties.DataSource = (from x in db.iller
                                                     select new
                                                     {
                                                         Id = x.id,
                                                         Şehir = x.sehir
                                                     }
                                                         ).ToList();




        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditIlce.Properties.DataSource = (from x in db.ilceler
                                                    select new
                                                    {
                                                        Id = x.id,
                                                        İlçe = x.ilce,
                                                        Şehir = x.sehir,
                                                        }).Where(y => y.Şehir == secilen).ToList();
        }


        private void PictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            resim1 = PictureEditKimlikOn.GetLoadedImageLocation();

        }

        private void PictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            resim2 = PictureEditKimlikArka.GetLoadedImageLocation();

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.MisafirID == id);
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTC.Text;
            deger.Mail = TxtMail.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Adres = TxtAdres.Text;
            deger.Aciklama = TxtAciklama.Text;
            deger.KimlikFoto1 = resim1;
            deger.KimlikFoto2 = resim2;
            deger.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            deger.sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
           
            deger.Durum = 1;
            repo.TUpdate(deger);
            XtraMessageBox.Show("Misafir kartı bilgileri başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
          
          
            t.AdSoyad = TxtAdSoyad.Text;
            t.TC = TxtTC.Text;
            t.Telefon = TxtTelefon.Text;
            t.Mail = TxtMail.Text;
            t.Adres = TxtAdres.Text;
            t.Aciklama = TxtAciklama.Text;
            t.Durum = 1;
            t.sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
            //t.ilce = lookUpEditIlce.Text;
            t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            t.KimlikFoto1=resim1;
            t.KimlikFoto2 = resim2;
            repo.TAdd(t);
            XtraMessageBox.Show("Misafir sisteme başarılı bir şekilde kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
