using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BarcodeTracking.DAL
{
	/// <summary>
	/// 数据访问类:reference
	/// </summary>
	public partial class reference
	{
		public reference()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "reference"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from reference");
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
		public int Add(BarcodeTracking.Model.reference model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into reference(");
			strSql.Append("name,project,color,boxType,productVersion,apn,label,jdeNo,outJDENo,oemCustNo,outCustNo,packingQty,description,version,factoryCode,operatedBy,operatedTime)");
			strSql.Append(" values (");
			strSql.Append("@name,@project,@color,@boxType,@productVersion,@apn,@label,@jdeNo,@outJDENo,@oemCustNo,@outCustNo,@packingQty,@description,@version,@factoryCode,@operatedBy,@operatedTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,100),
					new SqlParameter("@project", SqlDbType.VarChar,100),
					new SqlParameter("@color", SqlDbType.VarChar,10),
					new SqlParameter("@boxType", SqlDbType.VarChar,10),
					new SqlParameter("@productVersion", SqlDbType.VarChar,50),
					new SqlParameter("@apn", SqlDbType.VarChar,50),
					new SqlParameter("@label", SqlDbType.VarChar,100),
					new SqlParameter("@jdeNo", SqlDbType.VarChar,100),
					new SqlParameter("@outJDENo", SqlDbType.VarChar,100),
					new SqlParameter("@oemCustNo", SqlDbType.VarChar,100),
					new SqlParameter("@outCustNo", SqlDbType.VarChar,100),
					new SqlParameter("@packingQty", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,100),
					new SqlParameter("@version", SqlDbType.Int,4),
					new SqlParameter("@factoryCode", SqlDbType.VarChar,50),
					new SqlParameter("@operatedBy", SqlDbType.VarChar,50),
					new SqlParameter("@operatedTime", SqlDbType.DateTime)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.project;
			parameters[2].Value = model.color;
			parameters[3].Value = model.boxType;
			parameters[4].Value = model.productVersion;
			parameters[5].Value = model.apn;
			parameters[6].Value = model.label;
			parameters[7].Value = model.jdeNo;
			parameters[8].Value = model.outJDENo;
			parameters[9].Value = model.oemCustNo;
			parameters[10].Value = model.outCustNo;
			parameters[11].Value = model.packingQty;
			parameters[12].Value = model.description;
			parameters[13].Value = model.version;
			parameters[14].Value = model.factoryCode;
			parameters[15].Value = model.operatedBy;
			parameters[16].Value = model.operatedTime;

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
		public bool Update(BarcodeTracking.Model.reference model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update reference set ");
			strSql.Append("name=@name,");
			strSql.Append("project=@project,");
			strSql.Append("color=@color,");
			strSql.Append("boxType=@boxType,");
			strSql.Append("productVersion=@productVersion,");
			strSql.Append("apn=@apn,");
			strSql.Append("label=@label,");
			strSql.Append("jdeNo=@jdeNo,");
			strSql.Append("outJDENo=@outJDENo,");
			strSql.Append("oemCustNo=@oemCustNo,");
			strSql.Append("outCustNo=@outCustNo,");
			strSql.Append("packingQty=@packingQty,");
			strSql.Append("description=@description,");
			strSql.Append("version=@version,");
			strSql.Append("factoryCode=@factoryCode,");
			strSql.Append("operatedBy=@operatedBy,");
			strSql.Append("operatedTime=@operatedTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,100),
					new SqlParameter("@project", SqlDbType.VarChar,100),
					new SqlParameter("@color", SqlDbType.VarChar,10),
					new SqlParameter("@boxType", SqlDbType.VarChar,10),
					new SqlParameter("@productVersion", SqlDbType.VarChar,50),
					new SqlParameter("@apn", SqlDbType.VarChar,50),
					new SqlParameter("@label", SqlDbType.VarChar,100),
					new SqlParameter("@jdeNo", SqlDbType.VarChar,100),
					new SqlParameter("@outJDENo", SqlDbType.VarChar,100),
					new SqlParameter("@oemCustNo", SqlDbType.VarChar,100),
					new SqlParameter("@outCustNo", SqlDbType.VarChar,100),
					new SqlParameter("@packingQty", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,100),
					new SqlParameter("@version", SqlDbType.Int,4),
					new SqlParameter("@factoryCode", SqlDbType.VarChar,50),
					new SqlParameter("@operatedBy", SqlDbType.VarChar,50),
					new SqlParameter("@operatedTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.project;
			parameters[2].Value = model.color;
			parameters[3].Value = model.boxType;
			parameters[4].Value = model.productVersion;
			parameters[5].Value = model.apn;
			parameters[6].Value = model.label;
			parameters[7].Value = model.jdeNo;
			parameters[8].Value = model.outJDENo;
			parameters[9].Value = model.oemCustNo;
			parameters[10].Value = model.outCustNo;
			parameters[11].Value = model.packingQty;
			parameters[12].Value = model.description;
			parameters[13].Value = model.version;
			parameters[14].Value = model.factoryCode;
			parameters[15].Value = model.operatedBy;
			parameters[16].Value = model.operatedTime;
			parameters[17].Value = model.id;

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
			strSql.Append("delete from reference ");
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
			strSql.Append("delete from reference ");
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
		public BarcodeTracking.Model.reference GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,project,color,boxType,productVersion,apn,label,jdeNo,outJDENo,oemCustNo,outCustNo,packingQty,description,version,factoryCode,operatedBy,operatedTime from reference ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			BarcodeTracking.Model.reference model=new BarcodeTracking.Model.reference();
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
		public BarcodeTracking.Model.reference DataRowToModel(DataRow row)
		{
			BarcodeTracking.Model.reference model=new BarcodeTracking.Model.reference();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
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
				if(row["productVersion"]!=null)
				{
					model.productVersion=row["productVersion"].ToString();
				}
				if(row["apn"]!=null)
				{
					model.apn=row["apn"].ToString();
				}
				if(row["label"]!=null)
				{
					model.label=row["label"].ToString();
				}
				if(row["jdeNo"]!=null)
				{
					model.jdeNo=row["jdeNo"].ToString();
				}
				if(row["outJDENo"]!=null)
				{
					model.outJDENo=row["outJDENo"].ToString();
				}
				if(row["oemCustNo"]!=null)
				{
					model.oemCustNo=row["oemCustNo"].ToString();
				}
				if(row["outCustNo"]!=null)
				{
					model.outCustNo=row["outCustNo"].ToString();
				}
				if(row["packingQty"]!=null)
				{
					model.packingQty=row["packingQty"].ToString();
				}
				if(row["description"]!=null)
				{
					model.description=row["description"].ToString();
				}
				if(row["version"]!=null && row["version"].ToString()!="")
				{
					model.version=int.Parse(row["version"].ToString());
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
			strSql.Append("select id,name,project,color,boxType,productVersion,apn,label,jdeNo,outJDENo,oemCustNo,outCustNo,packingQty,description,version,factoryCode,operatedBy,operatedTime ");
			strSql.Append(" FROM reference ");
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
			strSql.Append(" id,name,project,color,boxType,productVersion,apn,label,jdeNo,outJDENo,oemCustNo,outCustNo,packingQty,description,version,factoryCode,operatedBy,operatedTime ");
			strSql.Append(" FROM reference ");
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
			strSql.Append("select count(1) FROM reference ");
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
			strSql.Append(")AS Row, T.*  from reference T ");
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
			parameters[0].Value = "reference";
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

