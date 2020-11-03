using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceUPD
{
    public class Config
    {
        public static readonly string PathFile = Application.StartupPath;

        public static Procedures hCntMain { get; set; } //осн. коннект
        public static Procedures hCntMainX14 { get; set; } //осн. коннект

        public static string centralText(string str)
        {
            int[] arra = new int[255];
            int count = 0;
            int maxLength = 0;
            int indexF = -1;
            arra[count] = 0;
            count++;
            indexF = str.IndexOf("\n");
            arra[count] = indexF;
            while (indexF != -1)
            {
                count++;
                indexF = str.IndexOf("\n", indexF + 1);
                arra[count] = indexF;
            }
            maxLength = arra[1] - arra[0];
            for (int i = 1; i < count; i++)
            {
                if (maxLength < (arra[i] - arra[i - 1]))
                {

                    maxLength = arra[i] - arra[i - 1];
                    if (i >= 2)
                    {
                        maxLength = maxLength - 1;
                    }
                }
            }
            string newString = "";
            string buffString = "";
            for (int i = 1; i < count; i++)
            {
                if (i >= 2)
                {

                    buffString = str.Substring(arra[i - 1] + 1, (arra[i] - arra[i - 1] - 1));
                    buffString = buffString.PadLeft(Convert.ToInt32(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2) * 1.8));
                    //    buffString = buffString.PadRight(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2)*2);
                    newString += buffString + "\n";
                }
                else
                {
                    buffString = str.Substring(arra[i - 1], arra[i]);
                    buffString = buffString.PadLeft(Convert.ToInt32(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2) * 1.8));
                    // buffString = buffString.PadRight(buffString.Length + ((maxLength - (arra[i] - arra[i - 1])) / 2)*2);
                    newString = buffString + "\n";
                }

            }

            return newString;
        }

        public static Settings ProgSettngs;
    }

    public class Settings
    {
        public string Path { set; get; }

        public string Login { set; get; }
     
        public string Password { set; get; }

        public string ServerK21 { set; get; }

        public string DataBaseK21 { set; get; }

        public string ServerX14 { set; get; }

        public string DataBaseX14 { set; get; }
    }
}
