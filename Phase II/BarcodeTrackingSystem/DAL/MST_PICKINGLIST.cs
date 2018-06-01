using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BarcodeTracking.DAL
{
    /// <summary>
    /// 数据访问类:MST_PICKINGLIST
    /// </summary>
    public partial class MST_PICKINGLIST
    {
        public MST_PICKINGLIST()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MST_PICKINGLIST");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NVarChar,50)          };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BarcodeTracking.Model.MST_PICKINGLIST model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MST_PICKINGLIST(");
            strSql.Append("ID,CODE,COMPANY,ORDERNO,ORDERTYPE,ROWNO,BRANCH,CUSTOMERNO,CUSTOMERNAME,TRANSPORT,PROJECTNO,Explain1,Explain2,UNIT,QTY,SHORTPROJECTNO,PROJECT_DESCRIBE,LIBRARY,BATCH,UKID,CREATEBY,CREATEUSERID,CREATEON,MODIFIEDBY,MODIFIEDUSERID,MODIFIEDON,DELETEMARK,SORTCODE)");
            strSql.Append(" values (");
            strSql.Append("@ID,@CODE,@COMPANY,@ORDERNO,@ORDERTYPE,@ROWNO,@BRANCH,@CUSTOMERNO,@CUSTOMERNAME,@TRANSPORT,@PROJECTNO,@Explain1,@Explain2,@UNIT,@QTY,@SHORTPROJECTNO,@PROJECT_DESCRIBE,@LIBRARY,@BATCH,@UKID,@CREATEBY,@CREATEUSERID,@CREATEON,@MODIFIEDBY,@MODIFIEDUSERID,@MODIFIEDON,@DELETEMARK,@SORTCODE)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NVarChar,50),
                    new SqlParameter("@CODE", SqlDbType.NVarChar,50),
                    new SqlParameter("@COMPANY", SqlDbType.NVarChar,50),
                    new SqlParameter("@ORDERNO", SqlDbType.NVarChar,50),
                    new SqlParameter("@ORDERTYPE", SqlDbType.NVarChar,50),
                    new SqlParameter("@ROWNO", SqlDbType.Int,4),
                    new SqlParameter("@BRANCH", SqlDbType.NVarChar,50),
                    new SqlParameter("@CUSTOMERNO", SqlDbType.NVarChar,50),
                    new SqlParameter("@CUSTOMERNAME", SqlDbType.NVarChar,50),
                    new SqlParameter("@TRANSPORT", SqlDbType.NVarChar,100),
                    new SqlParameter("@PROJECTNO", SqlDbType.NVarChar,50),
                    new SqlParameter("@Explain1", SqlDbType.NVarChar,100),
                    new SqlParameter("@Explain2", SqlDbType.NVarChar,100),
                    new SqlParameter("@UNIT", SqlDbType.NVarChar,50),
                    new SqlParameter("@QTY", SqlDbType.Int,4),
                    new SqlParameter("@SHORTPROJECTNO", SqlDbType.NVarChar,50),
                    new SqlParameter("@PROJECT_DESCRIBE", SqlDbType.NVarChar,50),
                    new SqlParameter("@LIBRARY", SqlDbType.NVarChar,50),
                    new SqlParameter("@BATCH", SqlDbType.NVarChar,50),
                    new SqlParameter("@UKID", SqlDbType.NVarChar,50),
                    new SqlParameter("@CREATEBY", SqlDbType.NVarChar,50),
                    new SqlParameter("@CREATEUSERID", SqlDbType.NVarChar,50),
                    new SqlParameter("@CREATEON", SqlDbType.DateTime),
                    new SqlParameter("@MODIFIEDBY", SqlDbType.NVarChar,50),
                    new SqlParameter("@MODIFIEDUSERID", SqlDbType.NVarChar,50),
                    new SqlParameter("@MODIFIEDON", SqlDbType.DateTime),
                    new SqlParameter("@DELETEMARK", SqlDbType.NVarChar,1),
                    new SqlParameter("@SORTCODE", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CODE;
            parameters[2].Value = model.COMPANY;
            parameters[3].Value = model.ORDERNO;
            parameters[4].Value = model.ORDERTYPE;
            parameters[5].Value = model.ROWNO;
            parameters[6].Value = model.BRANCH;
            parameters[7].Value = model.CUSTOMERNO;
            parameters[8].Value = model.CUSTOMERNAME;
            parameters[9].Value = model.TRANSPORT;
            parameters[10].Value = model.PROJECTNO;
            parameters[11].Value = model.Explain1;
            parameters[12].Value = model.Explain2;
            parameters[13].Value = model.UNIT;
            parameters[14].Value = model.QTY;
            parameters[15].Value = model.SHORTPROJECTNO;
            parameters[16].Value = model.PROJECT_DESCRIBE;
            parameters[17].Value = model.LIBRARY;
            parameters[18].Value = model.BATCH;
            parameters[19].Value = model.UKID;
            parameters[20].Value = model.CREATEBY;
            parameters[21].Value = model.CREATEUSERID;
            parameters[22].Value = model.CREATEON;
            parameters[23].Value = model.MODIFIEDBY;
            parameters[24].Value = model.MODIFIEDUSERID;
            parameters[25].Value = model.MODIFIEDON;
            parameters[26].Value = model.DELETEMARK;
            parameters[27].Value = model.SORTCODE;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(BarcodeTracking.Model.MST_PICKINGLIST model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MST_PICKINGLIST set ");
            strSql.Append("CODE=@CODE,");
            strSql.Append("COMPANY=@COMPANY,");
            strSql.Append("ORDERNO=@ORDERNO,");
            strSql.Append("ORDERTYPE=@ORDERTYPE,");
            strSql.Append("ROWNO=@ROWNO,");
            strSql.Append("BRANCH=@BRANCH,");
            strSql.Append("CUSTOMERNO=@CUSTOMERNO,");
            strSql.Append("CUSTOMERNAME=@CUSTOMERNAME,");
            strSql.Append("TRANSPORT=@TRANSPORT,");
            strSql.Append("PROJECTNO=@PROJECTNO,");
            strSql.Append("Explain1=@Explain1,");
            strSql.Append("Explain2=@Explain2,");
            strSql.Append("UNIT=@UNIT,");
            strSql.Append("QTY=@QTY,");
            strSql.Append("SHORTPROJECTNO=@SHORTPROJECTNO,");
            strSql.Append("PROJECT_DESCRIBE=@PROJECT_DESCRIBE,");
            strSql.Append("LIBRARY=@LIBRARY,");
            strSql.Append("BATCH=@BATCH,");
            strSql.Append("UKID=@UKID,");
            strSql.Append("CREATEBY=@CREATEBY,");
            strSql.Append("CREATEUSERID=@CREATEUSERID,");
            strSql.Append("CREATEON=@CREATEON,");
            strSql.Append("MODIFIEDBY=@MODIFIEDBY,");
            strSql.Append("MODIFIEDUSERID=@MODIFIEDUSERID,");
            strSql.Append("MODIFIEDON=@MODIFIEDON,");
            strSql.Append("DELETEMARK=@DELETEMARK,");
            strSql.Append("SORTCODE=@SORTCODE");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CODE", SqlDbType.NVarChar,50),
                    new SqlParameter("@COMPANY", SqlDbType.NVarChar,50),
                    new SqlParameter("@ORDERNO", SqlDbType.NVarChar,50),
                    new SqlParameter("@ORDERTYPE", SqlDbType.NVarChar,50),
                    new SqlParameter("@ROWNO", SqlDbType.Int,4),
                    new SqlParameter("@BRANCH", SqlDbType.NVarChar,50),
                    new SqlParameter("@CUSTOMERNO", SqlDbType.NVarChar,50),
                    new SqlParameter("@CUSTOMERNAME", SqlDbType.NVarChar,50),
                    new SqlParameter("@TRANSPORT", SqlDbType.NVarChar,100),
                    new SqlParameter("@PROJECTNO", SqlDbType.NVarChar,50),
                    new SqlParameter("@Explain1", SqlDbType.NVarChar,100),
                    new SqlParameter("@Explain2", SqlDbType.NVarChar,100),
                    new SqlParameter("@UNIT", SqlDbType.NVarChar,50),
                    new SqlParameter("@QTY", SqlDbType.Int,4),
                    new SqlParameter("@SHORTPROJECTNO", SqlDbType.NVarChar,50),
                    new SqlParameter("@PROJECT_DESCRIBE", SqlDbType.NVarChar,50),
                    new SqlParameter("@LIBRARY", SqlDbType.NVarChar,50),
                    new SqlParameter("@BATCH", SqlDbType.NVarChar,50),
                    new SqlParameter("@UKID", SqlDbType.NVarChar,50),
                    new SqlParameter("@CREATEBY", SqlDbType.NVarChar,50),
                    new SqlParameter("@CREATEUSERID", SqlDbType.NVarChar,50),
                    new SqlParameter("@CREATEON", SqlDbType.DateTime),
                    new SqlParameter("@MODIFIEDBY", SqlDbType.NVarChar,50),
                    new SqlParameter("@MODIFIEDUSERID", SqlDbType.NVarChar,50),
                    new SqlParameter("@MODIFIEDON", SqlDbType.DateTime),
                    new SqlParameter("@DELETEMARK", SqlDbType.NVarChar,1),
                    new SqlParameter("@SORTCODE", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.CODE;
            parameters[1].Value = model.COMPANY;
            parameters[2].Value = model.ORDERNO;
            parameters[3].Value = model.ORDERTYPE;
            parameters[4].Value = model.ROWNO;
            parameters[5].Value = model.BRANCH;
            parameters[6].Value = model.CUSTOMERNO;
            parameters[7].Value = model.CUSTOMERNAME;
            parameters[8].Value = model.TRANSPORT;
            parameters[9].Value = model.PROJECTNO;
            parameters[10].Value = model.Explain1;
            parameters[11].Value = model.Explain2;
            parameters[12].Value = model.UNIT;
            parameters[13].Value = model.QTY;
            parameters[14].Value = model.SHORTPROJECTNO;
            parameters[15].Value = model.PROJECT_DESCRIBE;
            parameters[16].Value = model.LIBRARY;
            parameters[17].Value = model.BATCH;
            parameters[18].Value = model.UKID;
            parameters[19].Value = model.CREATEBY;
            parameters[20].Value = model.CREATEUSERID;
            parameters[21].Value = model.CREATEON;
            parameters[22].Value = model.MODIFIEDBY;
            parameters[23].Value = model.MODIFIEDUSERID;
            parameters[24].Value = model.MODIFIEDON;
            parameters[25].Value = model.DELETEMARK;
            parameters[26].Value = model.SORTCODE;
            parameters[27].Value = model.ID;

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
        public bool Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MST_PICKINGLIST ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NVarChar,50)          };
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MST_PICKINGLIST ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public BarcodeTracking.Model.MST_PICKINGLIST GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CODE,COMPANY,ORDERNO,ORDERTYPE,ROWNO,BRANCH,CUSTOMERNO,CUSTOMERNAME,TRANSPORT,PROJECTNO,Explain1,Explain2,UNIT,QTY,SHORTPROJECTNO,PROJECT_DESCRIBE,LIBRARY,BATCH,UKID,CREATEBY,CREATEUSERID,CREATEON,MODIFIEDBY,MODIFIEDUSERID,MODIFIEDON,DELETEMARK,SORTCODE from MST_PICKINGLIST ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NVarChar,50)          };
            parameters[0].Value = ID;

            BarcodeTracking.Model.MST_PICKINGLIST model = new BarcodeTracking.Model.MST_PICKINGLIST();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public BarcodeTracking.Model.MST_PICKINGLIST DataRowToModel(DataRow row)
        {
            BarcodeTracking.Model.MST_PICKINGLIST model = new BarcodeTracking.Model.MST_PICKINGLIST();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["CODE"] != null)
                {
                    model.CODE = row["CODE"].ToString();
                }
                if (row["COMPANY"] != null)
                {
                    model.COMPANY = row["COMPANY"].ToString();
                }
                if (row["ORDERNO"] != null)
                {
                    model.ORDERNO = row["ORDERNO"].ToString();
                }
                if (row["ORDERTYPE"] != null)
                {
                    model.ORDERTYPE = row["ORDERTYPE"].ToString();
                }
                if (row["ROWNO"] != null && row["ROWNO"].ToString() != "")
                {
                    model.ROWNO = int.Parse(row["ROWNO"].ToString());
                }
                if (row["BRANCH"] != null)
                {
                    model.BRANCH = row["BRANCH"].ToString();
                }
                if (row["CUSTOMERNO"] != null)
                {
                    model.CUSTOMERNO = row["CUSTOMERNO"].ToString();
                }
                if (row["CUSTOMERNAME"] != null)
                {
                    model.CUSTOMERNAME = row["CUSTOMERNAME"].ToString();
                }
                if (row["TRANSPORT"] != null)
                {
                    model.TRANSPORT = row["TRANSPORT"].ToString();
                }
                if (row["PROJECTNO"] != null)
                {
                    model.PROJECTNO = row["PROJECTNO"].ToString();
                }
                if (row["Explain1"] != null)
                {
                    model.Explain1 = row["Explain1"].ToString();
                }
                if (row["Explain2"] != null)
                {
                    model.Explain2 = row["Explain2"].ToString();
                }
                if (row["UNIT"] != null)
                {
                    model.UNIT = row["UNIT"].ToString();
                }
                if (row["QTY"] != null && row["QTY"].ToString() != "")
                {
                    model.QTY = int.Parse(row["QTY"].ToString());
                }
                if (row["SHORTPROJECTNO"] != null)
                {
                    model.SHORTPROJECTNO = row["SHORTPROJECTNO"].ToString();
                }
                if (row["PROJECT_DESCRIBE"] != null)
                {
                    model.PROJECT_DESCRIBE = row["PROJECT_DESCRIBE"].ToString();
                }
                if (row["LIBRARY"] != null)
                {
                    model.LIBRARY = row["LIBRARY"].ToString();
                }
                if (row["BATCH"] != null)
                {
                    model.BATCH = row["BATCH"].ToString();
                }
                if (row["UKID"] != null)
                {
                    model.UKID = row["UKID"].ToString();
                }
                if (row["CREATEBY"] != null)
                {
                    model.CREATEBY = row["CREATEBY"].ToString();
                }
                if (row["CREATEUSERID"] != null)
                {
                    model.CREATEUSERID = row["CREATEUSERID"].ToString();
                }
                if (row["CREATEON"] != null && row["CREATEON"].ToString() != "")
                {
                    model.CREATEON = DateTime.Parse(row["CREATEON"].ToString());
                }
                if (row["MODIFIEDBY"] != null)
                {
                    model.MODIFIEDBY = row["MODIFIEDBY"].ToString();
                }
                if (row["MODIFIEDUSERID"] != null)
                {
                    model.MODIFIEDUSERID = row["MODIFIEDUSERID"].ToString();
                }
                if (row["MODIFIEDON"] != null && row["MODIFIEDON"].ToString() != "")
                {
                    model.MODIFIEDON = DateTime.Parse(row["MODIFIEDON"].ToString());
                }
                if (row["DELETEMARK"] != null)
                {
                    model.DELETEMARK = row["DELETEMARK"].ToString();
                }
                if (row["SORTCODE"] != null && row["SORTCODE"].ToString() != "")
                {
                    model.SORTCODE = int.Parse(row["SORTCODE"].ToString());
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
            strSql.Append("select ID,CODE,COMPANY,ORDERNO,ORDERTYPE,ROWNO,BRANCH,CUSTOMERNO,CUSTOMERNAME,TRANSPORT,PROJECTNO,Explain1,Explain2,UNIT,QTY,SHORTPROJECTNO,PROJECT_DESCRIBE,LIBRARY,BATCH,UKID,CREATEBY,CREATEUSERID,CREATEON,MODIFIEDBY,MODIFIEDUSERID,MODIFIEDON,DELETEMARK,SORTCODE ");
            strSql.Append(" FROM MST_PICKINGLIST ");
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
            strSql.Append(" ID,CODE,COMPANY,ORDERNO,ORDERTYPE,ROWNO,BRANCH,CUSTOMERNO,CUSTOMERNAME,TRANSPORT,PROJECTNO,Explain1,Explain2,UNIT,QTY,SHORTPROJECTNO,PROJECT_DESCRIBE,LIBRARY,BATCH,UKID,CREATEBY,CREATEUSERID,CREATEON,MODIFIEDBY,MODIFIEDUSERID,MODIFIEDON,DELETEMARK,SORTCODE ");
            strSql.Append(" FROM MST_PICKINGLIST ");
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
            strSql.Append("select count(1) FROM MST_PICKINGLIST ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from MST_PICKINGLIST T ");
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
			parameters[0].Value = "MST_PICKINGLIST";
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
        public DataSet getPickingListBySO(string SO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT PROJECTNO, LIBRARY, sum(QTY)FROM[dbo].[MST_PICKINGLIST]");
            if (SO.Trim() != "")
            {
                strSql.Append(" where ORDERNO='" + SO + "'");
                strSql.Append(" GROUP BY PROJECTNO, LIBRARY");
                strSql.Append(" order by PROJECTNO, LIBRARY; ");
            }
            return DbHelperSQL.Query(strSql.ToString());

        }

        #endregion  ExtensionMethod
    }
}

