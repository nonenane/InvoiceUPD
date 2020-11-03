using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;


namespace InvoiceUPD
{
    public class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
             : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();

        public DataTable GetDeps()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[invoices].[GetDeps]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public DataTable GetOperand()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[invoices].[invsGet_Operand]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }


        public DataTable GetShop()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[invoices].[GetShop]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public DataTable GetLegalPersons(int idDep)
        {
            ap.Clear();
            ap.Add(0);
            ap.Add(idDep);

            DataTable dtResult = executeProcedure("[invoices].[GetLegalPersons]",
                 new string[2] { "@id_prog", "@id_depart" },
                 new DbType[2] { DbType.Int32, DbType.Int32 }, ap);

            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                if (!dtResult.Columns.Contains("isMain"))
                {
                    dtResult.Columns.Add(new DataColumn("isMain", typeof(bool)) { DefaultValue = false });
                    DataRow row = dtResult.NewRow();

                    row["id"] = 0;
                    row["cname"] = "Все";
                    row["isMain"] = true;
                    row["nTypeOrg"] = 0;

                    dtResult.Rows.Add(row);

                    dtResult.DefaultView.Sort = "isMain desc";
                    dtResult = dtResult.DefaultView.ToTable();

                }
            }

            return dtResult;
        }


        public DataTable GetPostList()
        {
            ap.Clear();
            ap.Add(0);

            DataTable dtResult = executeProcedure("[invoices].[invsGetPostList]",
                 new string[1] { "@id_prog" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }

        public DataTable GetHeadUpd(DateTime dateStart, DateTime dateEnd)
        {
            ap.Clear();
            ap.Add(dateStart);
            ap.Add(dateEnd);

            DataTable dtResult = executeProcedure("[invoices].[GetHeadUpd]",
                 new string[2] { "@dateStart", "@dateEnd" },
                 new DbType[2] { DbType.Date, DbType.Date }, ap);

            return dtResult;
        }
    }
}
