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
	public class StudentDAL
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Student");
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
		public int Add(StudentModel model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into LateReturn(");
			strSql.Append("Sid,Spwd,Sname,Scolleges,Sroom,Slivedate,Sage,Ssex,Sadress,Sclass,Sphone)");
			strSql.Append(" values (");
			strSql.Append("@id,@Sid,@Spwd,@Sname,@Scolleges,@Sroom,@Slivedate,@Sage,@Ssex,@Sadress,@Sclass,@Sphone))");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.VarChar),
					new SqlParameter("@Spwd", SqlDbType.VarChar),
					new SqlParameter("@Sname",SqlDbType.VarChar),
					new SqlParameter("@Scolleges",SqlDbType.VarChar),
					new SqlParameter("@Sroom",SqlDbType.VarChar),
					new SqlParameter("@Slivedate",SqlDbType.VarChar),
					new SqlParameter("@Sage",SqlDbType.VarChar),
					new SqlParameter("@Ssex",SqlDbType.VarChar),
					new SqlParameter("@Sadress",SqlDbType.VarChar),
					new SqlParameter("@Sclass",SqlDbType.VarChar),
					new SqlParameter("@Sphone",SqlDbType.VarChar),
			};
			parameters[0].Value = model.Sid;
			parameters[1].Value = model.Spwd;
			parameters[2].Value = model.Sname;
			parameters[3].Value = model.Scolleges;
			parameters[4].Value = model.Sroom;
			parameters[5].Value = model.Slivedate;
			parameters[6].Value = model.Sage;
			parameters[7].Value = model.Ssex;
			parameters[8].Value = model.Sadress;
			parameters[9].Value = model.Sclass;
			parameters[10].Value = model.Sphone;

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
		public bool Update(StudentModel model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update Student set ");
			strSql.Append("Sid=@Sid,Spwd=@Spwd,Sname=@Sname, Scolleges=@Scolleges，Sroom=@Sroom，Slivedate=@Slivedate，Sage=@Sage，Ssex=@Ssex，Sadress=@Sadress，Sclass=@Sclass，Sphone=@Sphone");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
				new SqlParameter("id",SqlDbType.Int),
				new SqlParameter("Sid",SqlDbType.Int),
					new SqlParameter("@Spwd", SqlDbType.VarChar),
					new SqlParameter("@Sname",SqlDbType.VarChar),
					new SqlParameter("@Scolleges",SqlDbType.VarChar),
					new SqlParameter("@Sroom",SqlDbType.VarChar),
					new SqlParameter("@Slivedate",SqlDbType.VarChar),
					new SqlParameter("@Sage",SqlDbType.VarChar),
					new SqlParameter("@Ssex",SqlDbType.VarChar),
					new SqlParameter("@Sadress",SqlDbType.VarChar),
					new SqlParameter("@Sclass",SqlDbType.VarChar),
					new SqlParameter("@Sphone",SqlDbType.VarChar),

			};
			parameters[0].Value = model.Sid;
			parameters[1].Value = model.Spwd;
			parameters[2].Value = model.Sname;
			parameters[3].Value = model.Scolleges;
			parameters[4].Value = model.Sroom;
			parameters[5].Value = model.Slivedate;
			parameters[6].Value = model.Sage;
			parameters[7].Value = model.Ssex;
			parameters[8].Value = model.Sadress;
			parameters[9].Value = model.Sclass;
			parameters[10].Value = model.Sphone;

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
			strSql.Append("delete from Student ");
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
			strSql.Append("delete from Student ");
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
		public StudentModel GetModel(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 id,Sid,Spwd,Sname,Scolleges,Sroom,Slivedate,Sage,Ssex,Sadress,Sclass,Sphone from AdminInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			StudentModel model = new StudentModel();
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
		public StudentModel GetModel(DataRow row)
		{
			StudentModel model = new StudentModel();
			if (row != null)
			{
				if (row["id"] != null && row["id"].ToString() != "")
				{
					model.Id = int.Parse(row["id"].ToString());
				}
				if (row["Sid"] != null && row["Sid"].ToString() != "")
				{
					model.Sid = row["Sid"].ToString();
				}
				if (row["Spwd"] != null && row["Spwd"].ToString() != "")
				{
					model.Spwd = row["Spwd"].ToString();
				}
				if (row["Sname"] != null && row["Sname"].ToString() != "")
				{
					model.Sname = row["Sname"].ToString();
				}
				if (row["Scolleges"] != null && row["Scolleges"].ToString() != "")
				{
					model.Scolleges = row["Scolleges"].ToString();
				}
				if (row["Sroom"] != null && row["Sroom"].ToString() != "")
				{
					model.Sroom = row["Sroom"].ToString();
					if (row["Slivedate"] != null && row["Slivedate"].ToString() != "")
					{
						model.Slivedate = row["Slivedate"].ToString();
					}
					if (row["Sage"] != null && row["Sage"].ToString() != "")
					{
						model.Sage = row["Sage"].ToString();
					}
					if (row["Ssex"] != null && row["Ssex"].ToString() != "")
					{
						model.Ssex = row["Ssex"].ToString();
					}
					if (row["Sadress"] != null && row["Sadress"].ToString() != "")
					{
						model.Sadress = row["Sadress"].ToString();
					}
					if (row["Sclass"] != null && row["Sclass"].ToString() != "")
					{
						model.Sclass = row["Sclass"].ToString();
					}
					if (row["Sphone"] != null && row["Sphone"].ToString() != "")
					{
						model.Sphone = row["Sphone"].ToString();
					}
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
			strSql.Append("select  id,Sid,Spwd,Sname,Scolleges,Sroom,Slivedate,Sage,Ssex,Sadress,Sclass,Sphone");
			strSql.Append(" FROM Student ");
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
			strSql.Append(" id,Sid,Spwd,Sname,Scolleges,Sroom,Slivedate,Sage,Ssex,Sadress,Sclass,Sphone");
			strSql.Append(" FROM Student ");
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
			strSql.Append("select count(1) FROM Student ");
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
