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
    public partial class frmSelectProvider : Form
    {
        public int id { get; private set; }
        public string name { get; private set; }

        private DataTable dtData;

        public frmSelectProvider()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void frmSelectProvider_Load(object sender, EventArgs e)
        {
            dtData = Config.hCntMain.GetPostList();
            setFilter();
            dgvData.DataSource = dtData;

        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (col.Name.Equals(cName.Name))
                {
                    tbName.Location = new Point(dgvData.Location.X + width + 1, tbName.Location.Y);
                    tbName.Size = new Size(cName.Width, tbName.Size.Height);
                }
                width += col.Width;
            }
        }

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Index == -1) return;

            DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
            id = (int)row["id"];
            name = (string)row["name"];
            this.DialogResult = DialogResult.OK;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void setFilter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btSelect.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if (tbName.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"name like '%{tbName.Text.Trim()}%'";

                dtData.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btSelect.Enabled =
                dtData.DefaultView.Count != 0;                
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            dgvData_CellMouseDoubleClick(null, null);
        }
    }
}
