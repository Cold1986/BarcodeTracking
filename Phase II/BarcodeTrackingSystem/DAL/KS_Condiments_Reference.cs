using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BarcodeTracking.DAL
{
	/// <summary>
	/// 数据访问类:KS_Condiments_Reference
	/// </summary>
	public partial class KS_Condiments_Reference
	{
		public KS_Condiments_Reference()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "KS_Condiments_Reference"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from KS_Condiments_Reference");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BarcodeTracking.Model.KS_Condiments_Reference model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into KS_Condiments_Reference(");
			strSql.Append("project,color,boxType,jdeNo,packingQty,description,factoryCode,operatedBy,operatedTime)");
			strSql.Append(" values (");
			strSql.Append("@project,@color,@boxType,@jdeNo,@packingQty,@description,@factoryCode,@operatedBy,@operatedTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@project", SqlDbType.VarChar,100),
					new SqlParameter("@color", SqlDbType.VarChar,10),
					new SqlParameter("@boxType", SqlDbType.VarChar,10),
					new SqlParameter("@jdeNo", SqlDbType.VarChar,100),
					new SqlParameter("@packingQty", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,100),
					new SqlParameter("@factoryCode", SqlDbType.VarChar,50),
					new SqlParameter("@operatedBy", SqlDbType.VarChar,50),
					new SqlParameter("@operatedTime", SqlDbType.DateTime)};
			parameters[0].Value = model.project;
			parameters[1].Value = model.color;
			parameters[2].Value = model.boxType;
			parameters[3].Value = model.jdeNo;
			parameters[4].Value = model.packingQty;
			parameters[5].Value = model.description;
			parameters[6].Value = model.factoryCode;
			parameters[7].Value = model.operatedBy;
			parameters[8].Value = model.operatedTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(BarcodeTracking.Model.KS_Condiments_Reference model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update KS_Condiments_Reference set ");
			strSql.Append("project=@project,");
			strSql.Append("color=@color,");
			strSql.Append("boxType=@boxType,");
			strSql.Append("jdeNo=@jdeNo,");
			strSql.Append("packingQty=@packingQty,");
			strSql.Append("description=@description,");
			strSql.Append("factoryCode=@factoryCode,");
			strSql.Append("operatedBy=@operatedBy,");
			strSql.Append("operatedTime=@operatedTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@project", SqlDbType.VarChar,100),
					new SqlParameter("@color", SqlDbType.VarChar,10),
					new SqlParameter("@boxType", SqlDbType.VarChar,10),
					new SqlParameter("@jdeNo", SqlDbType.VarChar,100),
					new SqlParameter("@packingQty", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,100),
					new SqlParameter("@factoryCode", SqlDbType.VarChar,50),
					new SqlParameter("@operatedBy", SqlDbType.VarChar,50),
					new SqlParameter("@operatedTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.project;
			parameters[1].Value = model.color;
			parameters[2].Value = model.boxType;
			parameters[3].Value = model.jdeNo;
			parameters[4].Value = model.packingQty;
			parameters[5].Value = model.description;
			parameters[6].Value = model.factoryCode;
			parameters[7].Value = model.operatedBy;
			parameters[8].Value = model.operatedTime;
			parameters[9].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KS_Condiments_Reference ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KS_Condiments_Reference ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public BarcodeTracking.Model.KS_Condiments_Reference GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,project,color,boxType,jdeNo,packingQty,description,factoryCode,operatedBy,operatedTime from KS_Condiments_Reference ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			BarcodeTracking.Model.KS_Condiments_Reference model=new BarcodeTracking.Model.KS_Condiments_Reference();
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
		public BarcodeTracking.Model.KS_Condiments_Reference DataRowToModel(DataRow row)
		{
			BarcodeTracking.Model.KS_Condiments_Reference model=new BarcodeTracking.Model.KS_Condiments_Reference();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["project"]!=null)
				{
					model.project=row["project"].ToString();
				}
				if(row["color"]!=null)
				{
					model.color=row["color"].ToString();
				}
				if(row["boxType"]!=null)
				{
					model.boxType=row["boxType"].ToString();
				}
				if(row["jdeNo"]!=null)
				{
					model.jdeNo=row["jdeNo"].ToString();
				}
				if(row["packingQty"]!=null)
				{
					model.packingQty=row["packingQty"].ToString();
				}
				if(row["description"]!=null)
				{
					model.description=row["description"].ToString();
				}
				if(row["factoryCode"]!=null)
				{
					model.factoryCode=row["factoryCode"].ToString();
				}
				if(row["operatedBy"]!=null)
				{
					model.operatedBy=row["operatedBy"].ToString();
				}
				if(row["operatedTime"]!=null && row["operatedTime"].ToString()!="")
				{
					model.operatedTime=DateTime.Parse(row["operatedTime"].ToString());
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
			strSql.Append("select id,project,color,boxType,jdeNo,packingQty,description,factoryCode,operatedBy,operatedTime ");
			strSql.Append(" FROM KS_Condiments_Reference ");
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
			strSql.Append(" id,project,color,boxType,jdeNo,packingQty,description,factoryCode,operatedBy,operatedTime ");
			strSql.Append(" FROM KS_Condiments_Reference ");
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
			strSql.Append("select count(1) FROM KS_Condiments_Reference ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from KS_Condiments_Reference T ");
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
			parameters[0].Value = "KS_Condiments_Reference";
			parameters[1].Value = "id";
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

