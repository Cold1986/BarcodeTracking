using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BarcodeTracking.DAL
{
	/// <summary>
	/// 数据访问类:PH_RELATIONHISTORY
	/// </summary>
	public partial class PH_RELATIONHISTORY
	{
		public PH_RELATIONHISTORY()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PH_RELATIONHISTORY");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BarcodeTracking.Model.PH_RELATIONHISTORY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PH_RELATIONHISTORY(");
			strSql.Append("ID,BOXCODE,PALLETNOCODE,CSTATUS,JDENO,INSERTTIME)");
			strSql.Append(" values (");
			strSql.Append("@ID,@BOXCODE,@PALLETNOCODE,@CSTATUS,@JDENO,@INSERTTIME)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@BOXCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@PALLETNOCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CSTATUS", SqlDbType.Int,4),
					new SqlParameter("@JDENO", SqlDbType.NVarChar,50),
					new SqlParameter("@INSERTTIME", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BOXCODE;
			parameters[2].Value = model.PALLETNOCODE;
			parameters[3].Value = model.CSTATUS;
			parameters[4].Value = model.JDENO;
			parameters[5].Value = model.INSERTTIME;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(BarcodeTracking.Model.PH_RELATIONHISTORY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PH_RELATIONHISTORY set ");
			strSql.Append("BOXCODE=@BOXCODE,");
			strSql.Append("PALLETNOCODE=@PALLETNOCODE,");
			strSql.Append("CSTATUS=@CSTATUS,");
			strSql.Append("JDENO=@JDENO,");
			strSql.Append("INSERTTIME=@INSERTTIME");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BOXCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@PALLETNOCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CSTATUS", SqlDbType.Int,4),
					new SqlParameter("@JDENO", SqlDbType.NVarChar,50),
					new SqlParameter("@INSERTTIME", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.BOXCODE;
			parameters[1].Value = model.PALLETNOCODE;
			parameters[2].Value = model.CSTATUS;
			parameters[3].Value = model.JDENO;
			parameters[4].Value = model.INSERTTIME;
			parameters[5].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PH_RELATIONHISTORY ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PH_RELATIONHISTORY ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public BarcodeTracking.Model.PH_RELATIONHISTORY GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BOXCODE,PALLETNOCODE,CSTATUS,JDENO,INSERTTIME from PH_RELATIONHISTORY ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;

			BarcodeTracking.Model.PH_RELATIONHISTORY model=new BarcodeTracking.Model.PH_RELATIONHISTORY();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BarcodeTracking.Model.PH_RELATIONHISTORY DataRowToModel(DataRow row)
		{
			BarcodeTracking.Model.PH_RELATIONHISTORY model=new BarcodeTracking.Model.PH_RELATIONHISTORY();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["BOXCODE"]!=null)
				{
					model.BOXCODE=row["BOXCODE"].ToString();
				}
				if(row["PALLETNOCODE"]!=null)
				{
					model.PALLETNOCODE=row["PALLETNOCODE"].ToString();
				}
				if(row["CSTATUS"]!=null && row["CSTATUS"].ToString()!="")
				{
					model.CSTATUS=int.Parse(row["CSTATUS"].ToString());
				}
				if(row["JDENO"]!=null)
				{
					model.JDENO=row["JDENO"].ToString();
				}
				if(row["INSERTTIME"]!=null && row["INSERTTIME"].ToString()!="")
				{
					model.INSERTTIME=DateTime.Parse(row["INSERTTIME"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BOXCODE,PALLETNOCODE,CSTATUS,JDENO,INSERTTIME ");
			strSql.Append(" FROM PH_RELATIONHISTORY ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,BOXCODE,PALLETNOCODE,CSTATUS,JDENO,INSERTTIME ");
			strSql.Append(" FROM PH_RELATIONHISTORY ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM PH_RELATIONHISTORY ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from PH_RELATIONHISTORY T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "PH_RELATIONHISTORY";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

