using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceUPD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbDeps.DataSource = Config.hCntMain.GetDeps();
            cmbDeps.ValueMember = "id";
            cmbDeps.DisplayMember = "name";

            cmbDeps_SelectionChangeCommitted(null, null);


            cmbType.DataSource = Config.hCntMain.GetOperand();
            cmbType.ValueMember = "id";
            cmbType.DisplayMember = "name";

            cmbShop.DataSource = Config.hCntMain.GetShop();
            cmbShop.ValueMember = "id";
            cmbShop.DisplayMember = "cName";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (col.Name.Equals(cTTH.Name))
                {
                    tbTTN.Location = new Point(dgvData.Location.X + width + 1, tbTTN.Location.Y);
                    tbTTN.Size = new Size(cTTH.Width, tbTTN.Size.Height);
                }
                width +=col.Width;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
                dtpEnd.Value = dtpStart.Value.Date;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
                dtpStart.Value = dtpEnd.Value.Date;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDep = (int)cmbDeps.SelectedValue;
            cmbUL.DataSource  =Config.hCntMain.GetLegalPersons(idDep);
            cmbUL.ValueMember = "id";
            cmbUL.DisplayMember = "cname";
        }
    }
}
