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
            ap.Add(ConnectionSettings.GetIdProgram());
            ap.Add(idDep);

            DataTable dtResult = executeProcedure("[invoices].[GetLegalPersons]",
                 new string[2] { "@id_prog", "@id_depart" },
                 new DbType[2] { DbType.Int32, DbType.Int32 }, ap);

            return dtResult;
        }

    }
}
