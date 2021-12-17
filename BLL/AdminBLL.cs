using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class AdminBLL
    {
        public AdminModel SetUser(string userLoginId, string Pwd)
        {
            AdminModel model = new AdminModel();
            AdminDAL usersDAL = new AdminDAL();
            string strWhere = String.Format("adminid='{0}' and adminpwd='{1}'", userLoginId, Pwd);
            DataSet ds = usersDAL.GetList(strWhere);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                model = usersDAL.GetModel(ds.Tables[0].Rows[0]);
            }
            return model;
        }
    }
}
