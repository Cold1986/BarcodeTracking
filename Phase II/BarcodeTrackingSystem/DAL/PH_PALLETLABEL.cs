using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BarcodeTracking.DAL
{
	/// <summary>
	/// 数据访问类:PH_PALLETLABEL
	/// </summary>
	public partial class PH_PALLETLABEL
	{
		public PH_PALLETLABEL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string BARCODE,string CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PH_PALLETLABEL");
			strSql.Append(" where ID=@ID and BARCODE=@BARCODE and CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,255),
					new SqlParameter("@CODE", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;
			parameters[1].Value = BARCODE;
			parameters[2].Value = CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BarcodeTracking.Model.PH_PALLETLABEL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PH_PALLETLABEL(");
			strSql.Append("ID,BARCODE,CODE,NAME,APN,JDENO,BOXQTY,QTY,BOXSTATE,REMARKS,FACTORYCODE,CREATEBY,CREATEUSERID,CREATEON,MODIFIEDBY,MODIFIEDUSERID,MODIFIEDON,DELETEMARK,SORTCODE)");
			strSql.Append(" values (");
			strSql.Append("@ID,@BARCODE,@CODE,@NAME,@APN,@JDENO,@BOXQTY,@QTY,@BOXSTATE,@REMARKS,@FACTORYCODE,@CREATEBY,@CREATEUSERID,@CREATEON,@MODIFIEDBY,@MODIFIEDUSERID,@MODIFIEDON,@DELETEMARK,@SORTCODE)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,255),
					new SqlParameter("@CODE", SqlDbType.NVarChar,50),
					new SqlParameter("@NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@APN", SqlDbType.NVarChar,50),
					new SqlParameter("@JDENO", SqlDbType.NVarChar,50),
					new SqlParameter("@BOXQTY", SqlDbType.Int,4),
					new SqlParameter("@QTY", SqlDbType.Int,4),
					new SqlParameter("@BOXSTATE", SqlDbType.Int,4),
					new SqlParameter("@REMARKS", SqlDbType.NVarChar,255),
					new SqlParameter("@FACTORYCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CREATEBY", SqlDbType.NVarChar,50),
					new SqlParameter("@CREATEUSERID", SqlDbType.NVarChar,50),
					new SqlParameter("@CREATEON", SqlDbType.DateTime),
					new SqlParameter("@MODIFIEDBY", SqlDbType.NVarChar,50),
					new SqlParameter("@MODIFIEDUSERID", SqlDbType.NVarChar,50),
					new SqlParameter("@MODIFIEDON", SqlDbType.DateTime),
					new SqlParameter("@DELETEMARK", SqlDbType.NVarChar,1),
					new SqlParameter("@SORTCODE", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BARCODE;
			parameters[2].Value = model.CODE;
			parameters[3].Value = model.NAME;
			parameters[4].Value = model.APN;
			parameters[5].Value = model.JDENO;
			parameters[6].Value = model.BOXQTY;
			parameters[7].Value = model.QTY;
			parameters[8].Value = model.BOXSTATE;
			parameters[9].Value = model.REMARKS;
			parameters[10].Value = model.FACTORYCODE;
			parameters[11].Value = model.CREATEBY;
			parameters[12].Value = model.CREATEUSERID;
			parameters[13].Value = model.CREATEON;
			parameters[14].Value = model.MODIFIEDBY;
			parameters[15].Value = model.MODIFIEDUSERID;
			parameters[16].Value = model.MODIFIEDON;
			parameters[17].Value = model.DELETEMARK;
			parameters[18].Value = model.SORTCODE;

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
		public bool Update(BarcodeTracking.Model.PH_PALLETLABEL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PH_PALLETLABEL set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("APN=@APN,");
			strSql.Append("JDENO=@JDENO,");
			strSql.Append("BOXQTY=@BOXQTY,");
			strSql.Append("QTY=@QTY,");
			strSql.Append("BOXSTATE=@BOXSTATE,");
			strSql.Append("REMARKS=@REMARKS,");
			strSql.Append("FACTORYCODE=@FACTORYCODE,");
			strSql.Append("CREATEBY=@CREATEBY,");
			strSql.Append("CREATEUSERID=@CREATEUSERID,");
			strSql.Append("CREATEON=@CREATEON,");
			strSql.Append("MODIFIEDBY=@MODIFIEDBY,");
			strSql.Append("MODIFIEDUSERID=@MODIFIEDUSERID,");
			strSql.Append("MODIFIEDON=@MODIFIEDON,");
			strSql.Append("DELETEMARK=@DELETEMARK,");
			strSql.Append("SORTCODE=@SORTCODE");
			strSql.Append(" where ID=@ID and BARCODE=@BARCODE and CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@APN", SqlDbType.NVarChar,50),
					new SqlParameter("@JDENO", SqlDbType.NVarChar,50),
					new SqlParameter("@BOXQTY", SqlDbType.Int,4),
					new SqlParameter("@QTY", SqlDbType.Int,4),
					new SqlParameter("@BOXSTATE", SqlDbType.Int,4),
					new SqlParameter("@REMARKS", SqlDbType.NVarChar,255),
					new SqlParameter("@FACTORYCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CREATEBY", SqlDbType.NVarChar,50),
					new SqlParameter("@CREATEUSERID", SqlDbType.NVarChar,50),
					new SqlParameter("@CREATEON", SqlDbType.DateTime),
					new SqlParameter("@MODIFIEDBY", SqlDbType.NVarChar,50),
					new SqlParameter("@MODIFIEDUSERID", SqlDbType.NVarChar,50),
					new SqlParameter("@MODIFIEDON", SqlDbType.DateTime),
					new SqlParameter("@DELETEMARK", SqlDbType.NVarChar,1),
					new SqlParameter("@SORTCODE", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,255),
					new SqlParameter("@CODE", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.NAME;
			parameters[1].Value = model.APN;
			parameters[2].Value = model.JDENO;
			parameters[3].Value = model.BOXQTY;
			parameters[4].Value = model.QTY;
			parameters[5].Value = model.BOXSTATE;
			parameters[6].Value = model.REMARKS;
			parameters[7].Value = model.FACTORYCODE;
			parameters[8].Value = model.CREATEBY;
			parameters[9].Value = model.CREATEUSERID;
			parameters[10].Value = model.CREATEON;
			parameters[11].Value = model.MODIFIEDBY;
			parameters[12].Value = model.MODIFIEDUSERID;
			parameters[13].Value = model.MODIFIEDON;
			parameters[14].Value = model.DELETEMARK;
			parameters[15].Value = model.SORTCODE;
			parameters[16].Value = model.ID;
			parameters[17].Value = model.BARCODE;
			parameters[18].Value = model.CODE;

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
		public bool Delete(string ID,string BARCODE,string CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PH_PALLETLABEL ");
			strSql.Append(" where ID=@ID and BARCODE=@BARCODE and CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,255),
					new SqlParameter("@CODE", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;
			parameters[1].Value = BARCODE;
			parameters[2].Value = CODE;

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
		/// 得到一个对象实体
		/// </summary>
		public BarcodeTracking.Model.PH_PALLETLABEL GetModel(string ID,string BARCODE,string CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BARCODE,CODE,NAME,APN,JDENO,BOXQTY,QTY,BOXSTATE,REMARKS,FACTORYCODE,CREATEBY,CREATEUSERID,CREATEON,MODIFIEDBY,MODIFIEDUSERID,MODIFIEDON,DELETEMARK,SORTCODE from PH_PALLETLABEL ");
			strSql.Append(" where ID=@ID and BARCODE=@BARCODE and CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,255),
					new SqlParameter("@CODE", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ID;
			parameters[1].Value = BARCODE;
			parameters[2].Value = CODE;

			BarcodeTracking.Model.PH_PALLETLABEL model=new BarcodeTracking.Model.PH_PALLETLABEL();
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
		public BarcodeTracking.Model.PH_PALLETLABEL DataRowToModel(DataRow row)
		{
			BarcodeTracking.Model.PH_PALLETLABEL model=new BarcodeTracking.Model.PH_PALLETLABEL();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["BARCODE"]!=null)
				{
					model.BARCODE=row["BARCODE"].ToString();
				}
				if(row["CODE"]!=null)
				{
					model.CODE=row["CODE"].ToString();
				}
				if(row["NAME"]!=null)
				{
					model.NAME=row["NAME"].ToString();
				}
				if(row["APN"]!=null)
				{
					model.APN=row["APN"].ToString();
				}
				if(row["JDENO"]!=null)
				{
					model.JDENO=row["JDENO"].ToString();
				}
				if(row["BOXQTY"]!=null && row["BOXQTY"].ToString()!="")
				{
					model.BOXQTY=int.Parse(row["BOXQTY"].ToString());
				}
				if(row["QTY"]!=null && row["QTY"].ToString()!="")
				{
					model.QTY=int.Parse(row["QTY"].ToString());
				}
				if(row["BOXSTATE"]!=null && row["BOXSTATE"].ToString()!="")
				{
					model.BOXSTATE=int.Parse(row["BOXSTATE"].ToString());
				}
				if(row["REMARKS"]!=null)
				{
					model.REMARKS=row["REMARKS"].ToString();
				}
				if(row["FACTORYCODE"]!=null)
				{
					model.FACTORYCODE=row["FACTORYCODE"].ToString();
				}
				if(row["CREATEBY"]!=null)
				{
					model.CREATEBY=row["CREATEBY"].ToString();
				}
				if(row["CREATEUSERID"]!=null)
				{
					model.CREATEUSERID=row["CREATEUSERID"].ToString();
				}
				if(row["CREATEON"]!=null && row["CREATEON"].ToString()!="")
				{
					model.CREATEON=DateTime.Parse(row["CREATEON"].ToString());
				}
				if(row["MODIFIEDBY"]!=null)
				{
					model.MODIFIEDBY=row["MODIFIEDBY"].ToString();
				}
				if(row["MODIFIEDUSERID"]!=null)
				{
					model.MODIFIEDUSERID=row["MODIFIEDUSERID"].ToString();
				}
				if(row["MODIFIEDON"]!=null && row["MODIFIEDON"].ToString()!="")
				{
					model.MODIFIEDON=DateTime.Parse(row["MODIFIEDON"].ToString());
				}
				if(row["DELETEMARK"]!=null)
				{
					model.DELETEMARK=row["DELETEMARK"].ToString();
				}
				if(row["SORTCODE"]!=null && row["SORTCODE"].ToString()!="")
				{
					model.SORTCODE=int.Parse(row["SORTCODE"].ToString());
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
			strSql.Append("select ID,BARCODE,CODE,NAME,APN,JDENO,BOXQTY,QTY,BOXSTATE,REMARKS,FACTORYCODE,CREATEBY,CREATEUSERID,CREATEON,MODIFIEDBY,MODIFIEDUSERID,MODIFIEDON,DELETEMARK,SORTCODE ");
			strSql.Append(" FROM PH_PALLETLABEL ");
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
			strSql.Append(" ID,BARCODE,CODE,NAME,APN,JDENO,BOXQTY,QTY,BOXSTATE,REMARKS,FACTORYCODE,CREATEBY,CREATEUSERID,CREATEON,MODIFIEDBY,MODIFIEDUSERID,MODIFIEDON,DELETEMARK,SORTCODE ");
			strSql.Append(" FROM PH_PALLETLABEL ");
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
			strSql.Append("select count(1) FROM PH_PALLETLABEL ");
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
				strSql.Append("order by T.CODE desc");
			}
			strSql.Append(")AS Row, T.*  from PH_PALLETLABEL T ");
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
			parameters[0].Value = "PH_PALLETLABEL";
			parameters[1].Value = "CODE";
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

