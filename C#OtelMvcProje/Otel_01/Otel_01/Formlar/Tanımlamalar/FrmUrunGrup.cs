using DevExpress.XtraEditors;
using Otel_01.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_01.Formlar.Tanımlamalar
{
    public partial class FrmUrunGrup : Form
    {
        public FrmUrunGrup()
        {
            InitializeComponent();
        }
        DbOtelEntities1 db = new DbOtelEntities1();
        private void FrmUrunGrup_Load(object sender, EventArgs e)
        {
            db.TblUrunGrup.Load();
            bindingSource1.DataSource = db.TblUrunGrup.Local;
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurum
                                                        select new
                                                        {
                                                            x.DurumID,
                                                            x.DurumAdı

                                                        }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Bilgileri kontrol edip tekrar  deneyiniz", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }
    }
}
