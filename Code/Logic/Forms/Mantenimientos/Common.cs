using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace InfogesEmape.Code.Logic
{
    class Common
    {
        public const string VERSION_APP  = "v.1.0.1";
        public const string DATE_APP = "04/03/2009 12:18:07";
        public const string KEY_GUID_PWD = "49546E6F-BCF4-4a10-9014-E6C785F52033";
        public const string ID_SEC_EJEC = "001273";


        public static string GetDateTime(DataRow dr1, string fieldName)
        {
            string r1 = "";
            r1 = dr1[fieldName].ToString();
            if (r1.Length>0)
            {
                DateTime dt1 = (System.DateTime)dr1[fieldName];
                r1 = dt1.Day.ToString().PadLeft(2, '0') + "/" + dt1.Month.ToString().PadLeft(2, '0') + "/" + dt1.Year.ToString();
            }
            return r1;
        }

        #region GetDecimal
        public static int GetDecimal(DataSet ds1, int row, string fieldName)
        {
            int r=-1;
            try{
                r = int.Parse(ds1.Tables[0].Rows[row][fieldName].ToString());
            }
            catch{}
            return r;
        }
        #endregion

        #region GetFileName
        public static string GetFileName(string extension)
        {
            Random RandomGenerator = new Random();
            long RandomNum = RandomGenerator.Next(1111, 9999);
            string strTime = DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
            string strDate = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString();
            RandomGenerator = null;
            return "sgc__" + RandomNum.ToString() + strTime + strDate + "." + extension;
        }
        #endregion

        #region MarkDeleteFile
        public static string MarkDeleteFile(string extension)
        {
            Random RandomGenerator = new Random();
            long RandomNum = RandomGenerator.Next(1111, 9999);
            string strTime = DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
            string strDate = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString();
            RandomGenerator = null;
            return "DELETE__" + RandomNum.ToString() + strTime + strDate + "." + extension;
        }
        #endregion

        #region GetIdUnique
        public static string GetIdUnique()
        {
            Random RandomGenerator = new Random();
            long RandomNum = RandomGenerator.Next(1111, 9999);
            string strTime = DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
            string strDate = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString();
            RandomGenerator = null;
            return (strDate + strTime + RandomNum.ToString());
        }
        #endregion

        #region Get Characteres
        public static string Character13()
        {
            //C# Equivalent:
            Byte[] myBytes2 = { 13 };
            string myStr = System.Text.Encoding.ASCII.GetString(myBytes2);
            return myStr;
        }
        public static string Character10()
        {
            //C# Equivalent:
            Byte[] myBytes2 = { 10 };
            string myStr = System.Text.Encoding.ASCII.GetString(myBytes2);
            return myStr;
        }
        public static string Character00()
        {
            //C# Equivalent:
            Byte[] myBytes2 = { 0 };
            string myStr = System.Text.Encoding.ASCII.GetString(myBytes2);
            return myStr;
        }

        public static string Character34()
        {
            //C# Equivalent:
            Byte[] myBytes2 = { 34 };
            string myStr = System.Text.Encoding.ASCII.GetString(myBytes2);
            return myStr;
        }
        #endregion

        #region SendToEmail
        public static void SendToEmail(string emailFrom, string emailFromPwd, string emailTo, string subjectMessage, string bodyMessage)
        {
            System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(emailFrom, emailTo, subjectMessage, bodyMessage);
            MyMailMessage.IsBodyHtml = false;
            System.Net.NetworkCredential mailAuthentication = new
            System.Net.NetworkCredential(emailFrom, emailFromPwd);
            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = mailAuthentication;
            mailClient.Send(MyMailMessage);
        }
        #endregion

        #region ConsisStringDouble
        public static double ConsisStringDouble(DataRow dr1, string fieldName)
        {
            string r1 = "0";
            double r2 = 0;
            try
            {
                r1 = dr1[fieldName].ToString();
            }
            catch { }
            r2 = double.Parse(r1);
            return r2;
        }
        #endregion

    }
}
