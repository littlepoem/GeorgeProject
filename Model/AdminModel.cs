using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AdminModel : RootModel
    {
        public AdminModel()
        {

        }
        public AdminModel(int id, string adminid, string adminpwd, string adminname, string adminage, string adminsex, string adminroom, string adminpost, string adminadress)
        {
            this.Id = id;
            this.Adminid = adminid;
            this.Adminpwd = adminpwd;
            this.Adminname = adminname;
            this.Adminage = adminage;
            this.Adminsex = adminsex;
            this.Adminroom = adminroom;
            this.Adminpost = adminpost;
            this.Adminadress = adminadress;
        }

        private string _adminname;
        private string _adminage;
        private string _adminsex;
        private string _adminroom;
        private string _adminpost;
        private string _adminadress;

        public string Adminname { get => _adminname; set => _adminname = value; }
        public string Adminage { get => _adminage; set => _adminage = value; }
        public string Adminsex { get => _adminsex; set => _adminsex = value; }
        public string Adminroom { get => _adminroom; set => _adminroom = value; }
        public string Adminpost { get => _adminpost; set => _adminpost = value; }
        public string Adminadress { get => _adminadress; set => _adminadress = value; }

        public bool setSQL()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminInfo set ");
            strSql.Append("adminid=@adminid,adminpwd=@adminpwd,adminname=@adminname,adminage=@adminage,adminsex=@adminsex,adminroom=@adminroom,adminpost=@adminpost,adminadress=@adminadress");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("id",SqlDbType.Int){ Value=Id},
                    new SqlParameter("@adminid", SqlDbType.VarChar){ Value=Adminid},
                    new SqlParameter("@adminpwd", SqlDbType.VarChar){ Value=Adminpwd},
                    new SqlParameter("@adminname",SqlDbType.VarChar){ Value=Adminname},
                    new SqlParameter("@adminage",SqlDbType.VarChar){ Value=Adminage},
                    new SqlParameter("@adminsex",SqlDbType.VarChar){ Value=Adminsex},
                    new SqlParameter("@adminroom",SqlDbType.VarChar){ Value=Adminroom},
                    new SqlParameter("@adminpost",SqlDbType.VarChar){ Value=Adminpost},
                    new SqlParameter("@adminadress",SqlDbType.VarChar){ Value=_adminadress}
            };
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
