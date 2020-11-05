using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceUPD
{
    public partial class frmMain : Form
    {
        private int id_Post = 0;
        private DataTable dtData;

        public frmMain()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
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

            getData();
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

            EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
                .Where(r => r.Field<bool>("isSelect"));

            foreach (DataRow row in rowCollect)
            {
                int id = (int)row["id"];
                DataTable dtBody = Config.hCntMain.GetBodyUpd(id);

                if (dtBody.Rows.Count == 0) continue;

                if (dtBody.Columns.Contains("id_tovar"))
                    dtBody.Columns.Remove("id_tovar");

                print.printUpd(row, dtBody.Copy(), id);



            }

            /*
            Task<DataTable> task = Config.hCntMain.getNaklReportHead(id);
            task.Wait();
            if (task.Result == null || task.Result.Rows.Count == 0) continue;
            DataTable dtHead = task.Result;
            DataTable dtBody = new DataTable();

            foreach (var rGrp in rowGroupe)
            {
                task = Config.hCntMain.getNaklReportBody(rGrp.id_tInvoice_stage1, (DateTime)dtHead.Rows[0]["DocDate"]);
                task.Wait();
                if (task.Result != null || task.Result.Rows.Count != 0)
                    dtBody.Merge(task.Result);
            }

            if (dtBody.Rows.Count == 0) continue;

            foreach (DataRow rTovar in dtBody.Rows)
            {
                EnumerableRowCollection<DataRow> rsTovar = Config.dtFinTableBody.AsEnumerable()
                    .Where(r => r.Field<int>("id_tInvoice_parent") == id && r.Field<int>("id_tovar") == (int)rTovar["id_tovar"]);

                if (rsTovar.Count() > 0)
                {
                    decimal Zcena = (decimal)rsTovar.First()["Zcena"];

                    rTovar["price_unit"] = (Zcena * 100) / (100 + (decimal)rTovar["nds"]);
                    rTovar["price_tovar"] = Math.Round((decimal)rTovar["Netto"] * (Zcena * 100) / (100 + (decimal)rTovar["nds"]), 2);
                    rTovar["price_netto"] = Zcena * (decimal)rTovar["Netto"];
                    rTovar["p8"] = Math.Round((decimal)rTovar["price_netto"] - (decimal)rTovar["price_tovar"], 2);
                }
            }

            if (dtBody.Columns.Contains("id_tovar"))
                dtBody.Columns.Remove("id_tovar");
            */
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDep = (int)cmbDeps.SelectedValue;
            cmbUL.DataSource  =Config.hCntMain.GetLegalPersons(idDep);
            cmbUL.ValueMember = "nTypeOrg";
            cmbUL.DisplayMember = "cname";

            setFilter();
        }

        private void btSelectProvider_Click(object sender, EventArgs e)
        {
            frmSelectProvider fSP = new frmSelectProvider();

            if (DialogResult.OK == fSP.ShowDialog())
            {
                id_Post = fSP.id;                
                tbNamePost.Text = fSP.name;
                setFilter();
            }
        }

        private void btClearPost_Click(object sender, EventArgs e)
        {
            id_Post = 0;
            tbNamePost.Clear();
            setFilter();
        }

        private void getData()
        {
            _dateStart = dtpStart.Value.Date;
            _dateEnd = dtpEnd.Value.Date;

            if((int)cmbShop.SelectedValue==1)
            dtData = Config.hCntMain.GetHeadUpd(dtpStart.Value.Date, dtpEnd.Value.Date);
            else
                dtData = Config.hCntMainX14.GetHeadUpd(dtpStart.Value.Date, dtpEnd.Value.Date);
            setFilter();
            dgvData.DataSource = dtData;
        }

        private void setFilter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btPrint.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if (tbTTN.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"ttn like '%{tbTTN.Text.Trim()}%'";

                if ((int)cmbType.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_operand = {cmbType.SelectedValue}";

                if ((byte)cmbUL.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"ntypeorg = {cmbUL.SelectedValue}";

                if ((int)cmbDeps.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_otdel = {cmbDeps.SelectedValue}";

                if(id_Post!=0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_post = {id_Post}";

                dtData.DefaultView.RowFilter = filter;
                dtData.DefaultView.Sort = "id_otdel asc, dprihod asc, id_operand asc";
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btPrint.Enabled =
                dtData.DefaultView.Count != 0;
            }
        }

        private void cmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilter();
        }

        private void cmbShop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getData();
        }

        private void dtpStart_CloseUp(object sender, EventArgs e)
        {
            if (_dateStart.Date != dtpStart.Value.Date || _dateEnd.Date != dtpEnd.Value.Date)
                getData();
        }

        private DateTime _dateStart, _dateEnd;

        private void tbTTN_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DialogResult.OK == fbd.ShowDialog())
            {
                Console.WriteLine(fbd.SelectedPath);
                Config.ProgSettngs.Path = fbd.SelectedPath;

                File.WriteAllText(Config.PathFile+ @"\settings.json", JsonConvert.SerializeObject(Config.ProgSettngs));
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpStart_Leave(object sender, EventArgs e)
        {
            if (_dateStart.Date != dtpStart.Value.Date || _dateEnd.Date != dtpEnd.Value.Date)
                getData();
        }
    }
}
