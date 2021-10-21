using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RamRajyaCrasmibWeb.Models;
namespace RamRajyaCrasmibWeb.App_Code
{
    public class CommonFunctionRR
    {
        public static string GenerateMemberCode()
        {
            CRASMIB_RAMRAJYADBEntities db = new CRASMIB_RAMRAJYADBEntities();
            string Result = string.Empty;
            try
            {
                //M_MembersMaster m_MembersMaster = db.M_MembersMaster.OrderByDescending(x => x.MemberID).Take(1).FirstOrDefault();
                //string LastStudentCode = m_MembersMaster.MemberID;
                //int LastStudentNo = Convert.ToInt32(LastStudentCode.Substring(4, LastStudentCode.Length - 4));
                //return "RRWP" + (LastStudentNo + 1).ToString("000000000");
                return "RRWP" + 1.ToString("000000000");
            }
            catch (Exception ex)
            {
                return "RRWP" + 1.ToString("000000000");
            }
        }
    }
}