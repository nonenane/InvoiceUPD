using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceUPD
{
    class print
    {
        #region "Печать УПД"
        private static string pathTemplateFile = "";
        private static string pathUnloadTemplateFile = "";
        private static string pathUnloadTemplateFile_tmp = "";
        public static void printUpd(DataTable dtHead, DataTable dtBody, int id)
        {
            pathTemplateFile = Application.StartupPath + @"\Report\templateReportUPD";// + ".xls";
            pathUnloadTemplateFile_tmp = Application.StartupPath + @"\ReportFinish\NewReport_tmp";// + ".xls";
            pathUnloadTemplateFile = Application.StartupPath + @"\ReportFinish\NewReport";// + ".xls";

            Nwuram.Framework.ToExcel.Report reportTemplate = new Nwuram.Framework.ToExcel.Report();
            //reportTemplate.getCountSheet(pathUnloadTemplateFile);

            //DataTable dtHead = new DataTable();// Config.hCntMain.get_report_upd_head(id);
            //if (dtHead == null) return;
            //if (dtHead.Rows.Count == 0) return;

            //DataTable dtBody = new DataTable();// Config.hCntMain.get_report_upd_body(id);
            //if (dtBody == null) return;
            //if (dtBody.Rows.Count == 0) return;

            //for (int i = 0; i < 40; i++)
            //    dtBody.ImportRow(dtBody.Rows[0]);



            #region "Шапка"

            reportTemplate.AddSingleValue("@status", "1");
            reportTemplate.AddSingleValue("@ttn_1", dtHead.Rows[0]["ttn"].ToString());
            reportTemplate.AddSingleValue("@date_1", ((DateTime)dtHead.Rows[0]["DocDate"]).ToShortDateString());
            reportTemplate.AddSingleValue("@ttn_2", "--");
            reportTemplate.AddSingleValue("@date_2", "--");

            reportTemplate.AddSingleValue("@post_name_1", dtHead.Rows[0]["namePost1"].ToString());
            reportTemplate.AddSingleValue("@LegalAdress_post1", dtHead.Rows[0]["LegalAdress"].ToString());
            reportTemplate.AddSingleValue("@inn_post_1", dtHead.Rows[0]["inn"].ToString());
            reportTemplate.AddSingleValue("@send_post_1", "он же");
            reportTemplate.AddSingleValue("@adress_post_2", dtHead.Rows[0]["adressPost2"].ToString());


            reportTemplate.AddSingleValue("@org_name_post2", dtHead.Rows[0]["org_name"].ToString());
            reportTemplate.AddSingleValue("@org_address_post2", dtHead.Rows[0]["org_address"].ToString());
            reportTemplate.AddSingleValue("@kpp_post2", dtHead.Rows[0]["kpp"].ToString());
            reportTemplate.AddSingleValue("@money_post2", "Российский рубль, 643");



            //reportTemplate.AddSingleValue("@org_name_post2", dtHead.Rows[0][""].ToString());
            //reportTemplate.AddSingleValue("@org_name_post2", dtHead.Rows[0][""].ToString());
            //reportTemplate.AddSingleValue("@org_name_post2", dtHead.Rows[0][""].ToString());

            #endregion

            #region "Тело"
            reportTemplate.AddMultiValues(dtBody, "_");


            object sum_tmp = dtBody.Compute("SUM(price_tovar)", "");
            reportTemplate.AddSingleValue("p5_summa", sum_tmp.ToString());

            sum_tmp = dtBody.Compute("SUM(p8)", "");
            reportTemplate.AddSingleValue("p8_summa", sum_tmp.ToString());
            sum_tmp = dtBody.Compute("SUM(price_netto)", "");
            reportTemplate.AddSingleValue("p9_summa", sum_tmp.ToString());

            #endregion

            #region "Подписи"            
            reportTemplate.AddSingleValue("@ResponsiblePerson", dtHead.Rows[0]["ResponsiblePerson"].ToString());
            reportTemplate.AddSingleValue("@FIOGlBuh", dtHead.Rows[0]["FIOGlBuh"].ToString());
            reportTemplate.AddSingleValue("@position", "Генеральный директор");
            reportTemplate.AddSingleValue("@fio_position", dtHead.Rows[0]["ResponsiblePerson"].ToString());

            reportTemplate.AddSingleValue("@day", ((DateTime)dtHead.Rows[0]["DocDate"]).Day.ToString().PadLeft(2, '0'));
            reportTemplate.AddSingleValue("@month", ((DateTime)dtHead.Rows[0]["DocDate"]).Month.ToString().PadLeft(2, '0'));
            reportTemplate.AddSingleValue("@year", ((DateTime)dtHead.Rows[0]["DocDate"]).Year.ToString());
            reportTemplate.AddSingleValue("@inn_kpp_post1", dtHead.Rows[0]["inn_kpp_post1"].ToString());
            reportTemplate.AddSingleValue("@inn_kpp_post2", dtHead.Rows[0]["inn_kpp_post2"].ToString());
            reportTemplate.AddSingleValue("@type_doc", "Основной договор");
            reportTemplate.AddSingleValue("@count_list", "1");

            #endregion

            if (reportTemplate.CreateTemplate(pathTemplateFile, pathUnloadTemplateFile_tmp, null))
            {
                File.Copy(pathUnloadTemplateFile_tmp + ".xls", pathUnloadTemplateFile + "_" + id.ToString() + ".xls", true);
                File.Delete(pathUnloadTemplateFile_tmp);
                reportTemplate.OpenFile(pathUnloadTemplateFile + "_" + id.ToString());

                /*
                reportTemplate = new Nwuram.Framework.ToExcel.Report();
                int countSHeet = reportTemplate.getCountSheet(pathUnloadTemplateFile_tmp);
                reportTemplate.AddSingleValue("@count_list", countSHeet.ToString());
                if (reportTemplate.CreateTemplate(pathUnloadTemplateFile_tmp, pathUnloadTemplateFile, null))
                {
                    File.Delete(pathUnloadTemplateFile_tmp + ".xls");
                    reportTemplate.OpenFile(pathUnloadTemplateFile);
                }*/

            }
        }
        #endregion

    }
}
