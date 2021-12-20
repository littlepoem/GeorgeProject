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
	public class LeaveDAL
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Leave");
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
		public int Add(LeaveModel model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into LateReturn(");
			strSql.Append("studentid,roomnumber,leavetime,leavereason,backtime)");
			strSql.Append(" values (");
			strSql.Append("@id,@studentid,@roomnumber,@leavetime,@leavereason,@backtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@studentid", SqlDbType.VarChar),
					new SqlParameter("@roomnumber", SqlDbType.VarChar),
					new SqlParameter("@leavetime",SqlDbType.VarChar),
					new SqlParameter("@leavereason",SqlDbType.VarChar),
					new SqlParameter("@backtime",SqlDbType.VarChar)
			};
			parameters[0].Value = model.Studentid;
			parameters[1].Value = model.Roomnumber;
			parameters[2].Value = model.Leavetime;
			parameters[3].Value = model.Leavereason;
			parameters[4].Value = model.Backtime;

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
		public bool Update(LeaveModel model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update Leave set ");
			strSql.Append("Studentid=@Studentid,Roomnumber=@Roomnumber,Leavetime=@Leavetime, Leavereason=@Leavereason,Backtime=@Backtime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
				new SqlParameter("id",SqlDbType.Int),
					new SqlParameter("@Studentid", SqlDbType.VarChar),
					new SqlParameter("@Roomnumber", SqlDbType.VarChar),
					new SqlParameter("@Leavetime",SqlDbType.VarChar),
					new SqlParameter("@Leavereason",SqlDbType.VarChar),
					new SqlParameter("@Backtime",SqlDbType.VarChar),
			};
			parameters[0].Value = model.Studentid;
			parameters[1].Value = model.Roomnumber;
			parameters[2].Value = model.Leavetime;
			parameters[3].Value = model.Leavereason;
			parameters[4].Value = model.Backtime;

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
			strSql.Append("delete from Leave ");
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
			strSql.Append("delete from Leave ");
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
		public LeaveModel GetModel(int id)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 id,Studentid,Roomnumber,Leavetime,Leavereason,Backtime from AdminInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			LeaveModel model = new LeaveModel();
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
		public LeaveModel GetModel(DataRow row)
		{
			LeaveModel model = new LeaveModel();
			if (row != null)
			{
				if (row["id"] != null && row["id"].ToString() != "")
				{
					model.Id = int.Parse(row["id"].ToString());
				}
				if (row["Studentid"] != null && row["Studentid"].ToString() != "")
				{
					model.Studentid = row["Studentid"].ToString();
				}
				if (row["Roomnumber"] != null && row["Roomnumber"].ToString() != "")
				{
					model.Roomnumber = row["Roomnumber"].ToString();
				}
				if (row["Leavetime"] != null && row["Leavetime"].ToString() != "")
				{
					model.Leavetime = row["Leavetime"].ToString();
				}
				if (row["Leavereason"] != null && row["Leavereason"].ToString() != "")
				{
					model.Leavereason = row["Leavereason"].ToString();
				}
				if (row["Backtime"] != null && row["Backtime"].ToString() != "")
				{
					model.Backtime = row["Backtime"].ToString();
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
			strSql.Append("select id,Studentid,Roomnumber,Leavetime,Leavereason,Backtime");
			strSql.Append(" FROM LateReturn ");
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
			strSql.Append(" id,Studentid,Roomnumber,Leavetime,Leavereason,Backtime");
			strSql.Append(" FROM Leave ");
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
			strSql.Append("select count(1) FROM Leave ");
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
