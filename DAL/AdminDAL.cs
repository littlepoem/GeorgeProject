using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class AdminDAL
    {
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from AdminInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(AdminModel model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into AdminInfo(");
			strSql.Append("adminid,adminpwd,adminname,adminage,adminsex,adminroom,adminpost,adminadress)");
			strSql.Append(" values (");
			strSql.Append("@adminid,@adminpwd,@adminname,@adminage,@adminsex,@adminroom,@adminpost,@adminadress)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@adminid", SqlDbType.VarChar),
					new SqlParameter("@adminpwd", SqlDbType.VarChar),
					new SqlParameter("@adminname",SqlDbType.VarChar),
					new SqlParameter("@adminage",SqlDbType.VarChar),
					new SqlParameter("@adminsex",SqlDbType.VarChar),
					new SqlParameter("@adminroom",SqlDbType.VarChar),
					new SqlParameter("@adminpost",SqlDbType.VarChar),
					new SqlParameter("@adminadress",SqlDbType.VarChar)
			};		
			parameters[0].Value = model.Adminid;
			parameters[1].Value = model.Adminpwd;
			parameters[2].Value = model.Adminname;
			parameters[3].Value = model.Adminage;
			parameters[4].Value = model.Adminsex;
			parameters[5].Value = model.Adminroom;
			parameters[6].Value = model.Adminpost;
			parameters[7].Value = model.Adminadress;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(AdminModel model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update AdminInfo set ");
			strSql.Append("adminid=@adminid,adminpwd=@adminpwd,adminname=@adminname,adminage=@adminage,adminsex=@adminsex,adminroom=@adminroom,adminpost=@adminpost,adminadress=@adminadress");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
				new SqlParameter("id",SqlDbType.Int),
					new SqlParameter("@adminid", SqlDbType.VarChar),
					new SqlParameter("@adminpwd", SqlDbType.VarChar),
					new SqlParameter("@adminname",SqlDbType.VarChar),
					new SqlParameter("@adminage",SqlDbType.VarChar),
					new SqlParameter("@adminsex",SqlDbType.VarChar),
					new SqlParameter("@adminroom",SqlDbType.VarChar),
					new SqlParameter("@adminpost",SqlDbType.VarChar),
					new SqlParameter("@adminadress",SqlDbType.VarChar)
			};
			parameters[0].Value = model.Adminid;
			parameters[1].Value = model.Adminpwd;
			parameters[2].Value = model.Adminname;
			parameters[3].Value = model.Adminage;
			parameters[4].Value = model.Adminsex;
			parameters[5].Value = model.Adminroom;
			parameters[6].Value = model.Adminpost;
			parameters[7].Value = model.Adminadress;
			parameters[8].Value = model.Id;

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

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from AdminInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from AdminInfo ");
			strSql.Append(" where id in (" + idlist + ")  ");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AdminModel GetModel(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 id,adminid,adminpwd,adminname,adminage,adminsex,adminroom,adminpost,adminadress from AdminInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			AdminModel model = new AdminModel();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return GetModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AdminModel GetModel(DataRow row)
		{
			AdminModel model = new AdminModel();
			if (row != null)
			{
				if (row["id"] != null && row["id"].ToString() != "")
				{
					model.Id = int.Parse(row["id"].ToString());
				}
				if (row["adminid"] != null && row["adminid"].ToString() != "")
				{
					model.Adminid = row["adminid"].ToString();
				}
				if (row["adminpwd"] != null && row["adminpwd"].ToString() != "")
				{
					model.Adminpwd = row["adminpwd"].ToString();
				}
				if (row["adminname"] != null && row["adminname"].ToString() != "")
				{
					model.Adminname = row["adminname"].ToString();
				}
				if (row["adminage"] != null && row["adminage"].ToString() != "")
				{
					model.Adminage = row["adminage"].ToString();
				}
				if (row["adminsex"] != null && row["adminsex"].ToString() != "")
				{
					model.Adminsex = row["adminsex"].ToString();
				}
				if (row["adminroom"] != null && row["adminroom"].ToString() != "")
				{
					model.Adminroom = row["adminroom"].ToString();
				}
				if (row["adminpost"] != null && row["adminpost"].ToString() != "")
				{
					model.Adminpost = row["adminpost"].ToString();
				}
				if (row["adminadress"] != null && row["adminadress"].ToString() != "")
				{
					model.Adminadress = row["adminadress"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,adminid,adminpwd,adminname,adminage,adminsex,adminroom,adminpost,adminadress ");
			strSql.Append(" FROM AdminInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" id,adminid,adminpwd,adminname,adminage,adminsex,adminroom,adminpost,adminadress ");
			strSql.Append(" FROM AdminInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM AdminInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from City T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
	}
}
