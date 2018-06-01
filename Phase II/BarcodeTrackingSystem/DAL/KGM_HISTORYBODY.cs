using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BarcodeTracking.DAL
{
	/// <summary>
	/// 数据访问类:KGM_HISTORYBODY
	/// </summary>
	public partial class KGM_HISTORYBODY
	{
		public KGM_HISTORYBODY()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PKID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from KGM_HISTORYBODY");
			strSql.Append(" where PKID=@PKID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PKID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = PKID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BarcodeTracking.Model.KGM_HISTORYBODY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into KGM_HISTORYBODY(");
			strSql.Append("PKID,OPERORDER,CVOUCHID,ID,CCODE,CCUSCODE,CVENCODE,BARCODE,OPERUSER,OPERDATE,CWHCODE,AUTOID,CINVCODE,COPOSCODE,CIPOSCODE,CBATCH,IMASSDATE,CMASSUNIT,DMDATE,DVDATE,IEXPIRATDATECALCU,DEXPIRATIONDATE,CEXPIRATIONDATE,SNNO,QTY,IINVEXCHRATE,INUM,CASSUNIT,CFREE1,CFREE2,CFREE3,CFREE4,CFREE5,CFREE6,CFREE7,CFREE8,CFREE9,CFREE10,CVMIVENCODE,CITEM_CLASS,CITEMCNAME,CITEMCODE,CNAME,ISOTYPE,CSOCODE,ISODID,CDEFINE22,CDEFINE23,CDEFINE24,CDEFINE25,CDEFINE26,CDEFINE27,CDEFINE28,CDEFINE29,CDEFINE30,CDEFINE31,CDEFINE32,CDEFINE33,CDEFINE34,CDEFINE35,CDEFINE36,CDEFINE37,CBATCHPROPERTY1,CBATCHPROPERTY2,CBATCHPROPERTY3,CBATCHPROPERTY4,CBATCHPROPERTY5,CBATCHPROPERTY6,CBATCHPROPERTY7,CBATCHPROPERTY8,CBATCHPROPERTY9,CBATCHPROPERTY10,ITRACKID,ITRACKTYPE,CBMEMO,TRAYNO,FLOWNO,RESERVE1,RESERVE2,RESERVE3,RESERVE4,RESERVE5,RESERVE6,RESERVE7,RESERVE8,RESERVE9,RESERVE10)");
			strSql.Append(" values (");
			strSql.Append("@PKID,@OPERORDER,@CVOUCHID,@ID,@CCODE,@CCUSCODE,@CVENCODE,@BARCODE,@OPERUSER,@OPERDATE,@CWHCODE,@AUTOID,@CINVCODE,@COPOSCODE,@CIPOSCODE,@CBATCH,@IMASSDATE,@CMASSUNIT,@DMDATE,@DVDATE,@IEXPIRATDATECALCU,@DEXPIRATIONDATE,@CEXPIRATIONDATE,@SNNO,@QTY,@IINVEXCHRATE,@INUM,@CASSUNIT,@CFREE1,@CFREE2,@CFREE3,@CFREE4,@CFREE5,@CFREE6,@CFREE7,@CFREE8,@CFREE9,@CFREE10,@CVMIVENCODE,@CITEM_CLASS,@CITEMCNAME,@CITEMCODE,@CNAME,@ISOTYPE,@CSOCODE,@ISODID,@CDEFINE22,@CDEFINE23,@CDEFINE24,@CDEFINE25,@CDEFINE26,@CDEFINE27,@CDEFINE28,@CDEFINE29,@CDEFINE30,@CDEFINE31,@CDEFINE32,@CDEFINE33,@CDEFINE34,@CDEFINE35,@CDEFINE36,@CDEFINE37,@CBATCHPROPERTY1,@CBATCHPROPERTY2,@CBATCHPROPERTY3,@CBATCHPROPERTY4,@CBATCHPROPERTY5,@CBATCHPROPERTY6,@CBATCHPROPERTY7,@CBATCHPROPERTY8,@CBATCHPROPERTY9,@CBATCHPROPERTY10,@ITRACKID,@ITRACKTYPE,@CBMEMO,@TRAYNO,@FLOWNO,@RESERVE1,@RESERVE2,@RESERVE3,@RESERVE4,@RESERVE5,@RESERVE6,@RESERVE7,@RESERVE8,@RESERVE9,@RESERVE10)");
			SqlParameter[] parameters = {
					new SqlParameter("@PKID", SqlDbType.NVarChar,50),
					new SqlParameter("@OPERORDER", SqlDbType.NVarChar,50),
					new SqlParameter("@CVOUCHID", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.NVarChar,4000),
					new SqlParameter("@CCODE", SqlDbType.NVarChar,4000),
					new SqlParameter("@CCUSCODE", SqlDbType.NVarChar,20),
					new SqlParameter("@CVENCODE", SqlDbType.NVarChar,20),
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,500),
					new SqlParameter("@OPERUSER", SqlDbType.NVarChar,50),
					new SqlParameter("@OPERDATE", SqlDbType.DateTime),
					new SqlParameter("@CWHCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@AUTOID", SqlDbType.NVarChar,50),
					new SqlParameter("@CINVCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@COPOSCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CIPOSCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CBATCH", SqlDbType.NVarChar,50),
					new SqlParameter("@IMASSDATE", SqlDbType.Int,4),
					new SqlParameter("@CMASSUNIT", SqlDbType.Int,4),
					new SqlParameter("@DMDATE", SqlDbType.DateTime),
					new SqlParameter("@DVDATE", SqlDbType.DateTime),
					new SqlParameter("@IEXPIRATDATECALCU", SqlDbType.Int,4),
					new SqlParameter("@DEXPIRATIONDATE", SqlDbType.DateTime),
					new SqlParameter("@CEXPIRATIONDATE", SqlDbType.NVarChar,10),
					new SqlParameter("@SNNO", SqlDbType.NVarChar,50),
					new SqlParameter("@QTY", SqlDbType.Int,4),
					new SqlParameter("@IINVEXCHRATE", SqlDbType.Decimal,17),
					new SqlParameter("@INUM", SqlDbType.Decimal,17),
					new SqlParameter("@CASSUNIT", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE1", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE2", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE3", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE4", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE5", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE6", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE7", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE8", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE9", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE10", SqlDbType.NVarChar,50),
					new SqlParameter("@CVMIVENCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CITEM_CLASS", SqlDbType.NVarChar,10),
					new SqlParameter("@CITEMCNAME", SqlDbType.NVarChar,20),
					new SqlParameter("@CITEMCODE", SqlDbType.NVarChar,20),
					new SqlParameter("@CNAME", SqlDbType.NVarChar,60),
					new SqlParameter("@ISOTYPE", SqlDbType.Int,4),
					new SqlParameter("@CSOCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ISODID", SqlDbType.NVarChar,40),
					new SqlParameter("@CDEFINE22", SqlDbType.NVarChar,60),
					new SqlParameter("@CDEFINE23", SqlDbType.NVarChar,60),
					new SqlParameter("@CDEFINE24", SqlDbType.NVarChar,60),
					new SqlParameter("@CDEFINE25", SqlDbType.NVarChar,60),
					new SqlParameter("@CDEFINE26", SqlDbType.Float,8),
					new SqlParameter("@CDEFINE27", SqlDbType.Float,8),
					new SqlParameter("@CDEFINE28", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE29", SqlDbType.NVarChar,2000),
					new SqlParameter("@CDEFINE30", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE31", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE32", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE33", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE34", SqlDbType.Int,4),
					new SqlParameter("@CDEFINE35", SqlDbType.Int,4),
					new SqlParameter("@CDEFINE36", SqlDbType.DateTime),
					new SqlParameter("@CDEFINE37", SqlDbType.DateTime),
					new SqlParameter("@CBATCHPROPERTY1", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY2", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY3", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY4", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY5", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY6", SqlDbType.NVarChar,120),
					new SqlParameter("@CBATCHPROPERTY7", SqlDbType.NVarChar,120),
					new SqlParameter("@CBATCHPROPERTY8", SqlDbType.NVarChar,120),
					new SqlParameter("@CBATCHPROPERTY9", SqlDbType.NVarChar,120),
					new SqlParameter("@CBATCHPROPERTY10", SqlDbType.DateTime),
					new SqlParameter("@ITRACKID", SqlDbType.Int,4),
					new SqlParameter("@ITRACKTYPE", SqlDbType.NVarChar,50),
					new SqlParameter("@CBMEMO", SqlDbType.NVarChar,500),
					new SqlParameter("@TRAYNO", SqlDbType.NVarChar,50),
					new SqlParameter("@FLOWNO", SqlDbType.NVarChar,50),
					new SqlParameter("@RESERVE1", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE2", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE3", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE4", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE5", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE6", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE7", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE8", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE9", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE10", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.PKID;
			parameters[1].Value = model.OPERORDER;
			parameters[2].Value = model.CVOUCHID;
			parameters[3].Value = model.ID;
			parameters[4].Value = model.CCODE;
			parameters[5].Value = model.CCUSCODE;
			parameters[6].Value = model.CVENCODE;
			parameters[7].Value = model.BARCODE;
			parameters[8].Value = model.OPERUSER;
			parameters[9].Value = model.OPERDATE;
			parameters[10].Value = model.CWHCODE;
			parameters[11].Value = model.AUTOID;
			parameters[12].Value = model.CINVCODE;
			parameters[13].Value = model.COPOSCODE;
			parameters[14].Value = model.CIPOSCODE;
			parameters[15].Value = model.CBATCH;
			parameters[16].Value = model.IMASSDATE;
			parameters[17].Value = model.CMASSUNIT;
			parameters[18].Value = model.DMDATE;
			parameters[19].Value = model.DVDATE;
			parameters[20].Value = model.IEXPIRATDATECALCU;
			parameters[21].Value = model.DEXPIRATIONDATE;
			parameters[22].Value = model.CEXPIRATIONDATE;
			parameters[23].Value = model.SNNO;
			parameters[24].Value = model.QTY;
			parameters[25].Value = model.IINVEXCHRATE;
			parameters[26].Value = model.INUM;
			parameters[27].Value = model.CASSUNIT;
			parameters[28].Value = model.CFREE1;
			parameters[29].Value = model.CFREE2;
			parameters[30].Value = model.CFREE3;
			parameters[31].Value = model.CFREE4;
			parameters[32].Value = model.CFREE5;
			parameters[33].Value = model.CFREE6;
			parameters[34].Value = model.CFREE7;
			parameters[35].Value = model.CFREE8;
			parameters[36].Value = model.CFREE9;
			parameters[37].Value = model.CFREE10;
			parameters[38].Value = model.CVMIVENCODE;
			parameters[39].Value = model.CITEM_CLASS;
			parameters[40].Value = model.CITEMCNAME;
			parameters[41].Value = model.CITEMCODE;
			parameters[42].Value = model.CNAME;
			parameters[43].Value = model.ISOTYPE;
			parameters[44].Value = model.CSOCODE;
			parameters[45].Value = model.ISODID;
			parameters[46].Value = model.CDEFINE22;
			parameters[47].Value = model.CDEFINE23;
			parameters[48].Value = model.CDEFINE24;
			parameters[49].Value = model.CDEFINE25;
			parameters[50].Value = model.CDEFINE26;
			parameters[51].Value = model.CDEFINE27;
			parameters[52].Value = model.CDEFINE28;
			parameters[53].Value = model.CDEFINE29;
			parameters[54].Value = model.CDEFINE30;
			parameters[55].Value = model.CDEFINE31;
			parameters[56].Value = model.CDEFINE32;
			parameters[57].Value = model.CDEFINE33;
			parameters[58].Value = model.CDEFINE34;
			parameters[59].Value = model.CDEFINE35;
			parameters[60].Value = model.CDEFINE36;
			parameters[61].Value = model.CDEFINE37;
			parameters[62].Value = model.CBATCHPROPERTY1;
			parameters[63].Value = model.CBATCHPROPERTY2;
			parameters[64].Value = model.CBATCHPROPERTY3;
			parameters[65].Value = model.CBATCHPROPERTY4;
			parameters[66].Value = model.CBATCHPROPERTY5;
			parameters[67].Value = model.CBATCHPROPERTY6;
			parameters[68].Value = model.CBATCHPROPERTY7;
			parameters[69].Value = model.CBATCHPROPERTY8;
			parameters[70].Value = model.CBATCHPROPERTY9;
			parameters[71].Value = model.CBATCHPROPERTY10;
			parameters[72].Value = model.ITRACKID;
			parameters[73].Value = model.ITRACKTYPE;
			parameters[74].Value = model.CBMEMO;
			parameters[75].Value = model.TRAYNO;
			parameters[76].Value = model.FLOWNO;
			parameters[77].Value = model.RESERVE1;
			parameters[78].Value = model.RESERVE2;
			parameters[79].Value = model.RESERVE3;
			parameters[80].Value = model.RESERVE4;
			parameters[81].Value = model.RESERVE5;
			parameters[82].Value = model.RESERVE6;
			parameters[83].Value = model.RESERVE7;
			parameters[84].Value = model.RESERVE8;
			parameters[85].Value = model.RESERVE9;
			parameters[86].Value = model.RESERVE10;

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
		public bool Update(BarcodeTracking.Model.KGM_HISTORYBODY model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update KGM_HISTORYBODY set ");
			strSql.Append("OPERORDER=@OPERORDER,");
			strSql.Append("CVOUCHID=@CVOUCHID,");
			strSql.Append("ID=@ID,");
			strSql.Append("CCODE=@CCODE,");
			strSql.Append("CCUSCODE=@CCUSCODE,");
			strSql.Append("CVENCODE=@CVENCODE,");
			strSql.Append("BARCODE=@BARCODE,");
			strSql.Append("OPERUSER=@OPERUSER,");
			strSql.Append("OPERDATE=@OPERDATE,");
			strSql.Append("CWHCODE=@CWHCODE,");
			strSql.Append("AUTOID=@AUTOID,");
			strSql.Append("CINVCODE=@CINVCODE,");
			strSql.Append("COPOSCODE=@COPOSCODE,");
			strSql.Append("CIPOSCODE=@CIPOSCODE,");
			strSql.Append("CBATCH=@CBATCH,");
			strSql.Append("IMASSDATE=@IMASSDATE,");
			strSql.Append("CMASSUNIT=@CMASSUNIT,");
			strSql.Append("DMDATE=@DMDATE,");
			strSql.Append("DVDATE=@DVDATE,");
			strSql.Append("IEXPIRATDATECALCU=@IEXPIRATDATECALCU,");
			strSql.Append("DEXPIRATIONDATE=@DEXPIRATIONDATE,");
			strSql.Append("CEXPIRATIONDATE=@CEXPIRATIONDATE,");
			strSql.Append("SNNO=@SNNO,");
			strSql.Append("QTY=@QTY,");
			strSql.Append("IINVEXCHRATE=@IINVEXCHRATE,");
			strSql.Append("INUM=@INUM,");
			strSql.Append("CASSUNIT=@CASSUNIT,");
			strSql.Append("CFREE1=@CFREE1,");
			strSql.Append("CFREE2=@CFREE2,");
			strSql.Append("CFREE3=@CFREE3,");
			strSql.Append("CFREE4=@CFREE4,");
			strSql.Append("CFREE5=@CFREE5,");
			strSql.Append("CFREE6=@CFREE6,");
			strSql.Append("CFREE7=@CFREE7,");
			strSql.Append("CFREE8=@CFREE8,");
			strSql.Append("CFREE9=@CFREE9,");
			strSql.Append("CFREE10=@CFREE10,");
			strSql.Append("CVMIVENCODE=@CVMIVENCODE,");
			strSql.Append("CITEM_CLASS=@CITEM_CLASS,");
			strSql.Append("CITEMCNAME=@CITEMCNAME,");
			strSql.Append("CITEMCODE=@CITEMCODE,");
			strSql.Append("CNAME=@CNAME,");
			strSql.Append("ISOTYPE=@ISOTYPE,");
			strSql.Append("CSOCODE=@CSOCODE,");
			strSql.Append("ISODID=@ISODID,");
			strSql.Append("CDEFINE22=@CDEFINE22,");
			strSql.Append("CDEFINE23=@CDEFINE23,");
			strSql.Append("CDEFINE24=@CDEFINE24,");
			strSql.Append("CDEFINE25=@CDEFINE25,");
			strSql.Append("CDEFINE26=@CDEFINE26,");
			strSql.Append("CDEFINE27=@CDEFINE27,");
			strSql.Append("CDEFINE28=@CDEFINE28,");
			strSql.Append("CDEFINE29=@CDEFINE29,");
			strSql.Append("CDEFINE30=@CDEFINE30,");
			strSql.Append("CDEFINE31=@CDEFINE31,");
			strSql.Append("CDEFINE32=@CDEFINE32,");
			strSql.Append("CDEFINE33=@CDEFINE33,");
			strSql.Append("CDEFINE34=@CDEFINE34,");
			strSql.Append("CDEFINE35=@CDEFINE35,");
			strSql.Append("CDEFINE36=@CDEFINE36,");
			strSql.Append("CDEFINE37=@CDEFINE37,");
			strSql.Append("CBATCHPROPERTY1=@CBATCHPROPERTY1,");
			strSql.Append("CBATCHPROPERTY2=@CBATCHPROPERTY2,");
			strSql.Append("CBATCHPROPERTY3=@CBATCHPROPERTY3,");
			strSql.Append("CBATCHPROPERTY4=@CBATCHPROPERTY4,");
			strSql.Append("CBATCHPROPERTY5=@CBATCHPROPERTY5,");
			strSql.Append("CBATCHPROPERTY6=@CBATCHPROPERTY6,");
			strSql.Append("CBATCHPROPERTY7=@CBATCHPROPERTY7,");
			strSql.Append("CBATCHPROPERTY8=@CBATCHPROPERTY8,");
			strSql.Append("CBATCHPROPERTY9=@CBATCHPROPERTY9,");
			strSql.Append("CBATCHPROPERTY10=@CBATCHPROPERTY10,");
			strSql.Append("ITRACKID=@ITRACKID,");
			strSql.Append("ITRACKTYPE=@ITRACKTYPE,");
			strSql.Append("CBMEMO=@CBMEMO,");
			strSql.Append("TRAYNO=@TRAYNO,");
			strSql.Append("FLOWNO=@FLOWNO,");
			strSql.Append("RESERVE1=@RESERVE1,");
			strSql.Append("RESERVE2=@RESERVE2,");
			strSql.Append("RESERVE3=@RESERVE3,");
			strSql.Append("RESERVE4=@RESERVE4,");
			strSql.Append("RESERVE5=@RESERVE5,");
			strSql.Append("RESERVE6=@RESERVE6,");
			strSql.Append("RESERVE7=@RESERVE7,");
			strSql.Append("RESERVE8=@RESERVE8,");
			strSql.Append("RESERVE9=@RESERVE9,");
			strSql.Append("RESERVE10=@RESERVE10");
			strSql.Append(" where PKID=@PKID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OPERORDER", SqlDbType.NVarChar,50),
					new SqlParameter("@CVOUCHID", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.NVarChar,4000),
					new SqlParameter("@CCODE", SqlDbType.NVarChar,4000),
					new SqlParameter("@CCUSCODE", SqlDbType.NVarChar,20),
					new SqlParameter("@CVENCODE", SqlDbType.NVarChar,20),
					new SqlParameter("@BARCODE", SqlDbType.NVarChar,500),
					new SqlParameter("@OPERUSER", SqlDbType.NVarChar,50),
					new SqlParameter("@OPERDATE", SqlDbType.DateTime),
					new SqlParameter("@CWHCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@AUTOID", SqlDbType.NVarChar,50),
					new SqlParameter("@CINVCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@COPOSCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CIPOSCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CBATCH", SqlDbType.NVarChar,50),
					new SqlParameter("@IMASSDATE", SqlDbType.Int,4),
					new SqlParameter("@CMASSUNIT", SqlDbType.Int,4),
					new SqlParameter("@DMDATE", SqlDbType.DateTime),
					new SqlParameter("@DVDATE", SqlDbType.DateTime),
					new SqlParameter("@IEXPIRATDATECALCU", SqlDbType.Int,4),
					new SqlParameter("@DEXPIRATIONDATE", SqlDbType.DateTime),
					new SqlParameter("@CEXPIRATIONDATE", SqlDbType.NVarChar,10),
					new SqlParameter("@SNNO", SqlDbType.NVarChar,50),
					new SqlParameter("@QTY", SqlDbType.Int,4),
					new SqlParameter("@IINVEXCHRATE", SqlDbType.Decimal,17),
					new SqlParameter("@INUM", SqlDbType.Decimal,17),
					new SqlParameter("@CASSUNIT", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE1", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE2", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE3", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE4", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE5", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE6", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE7", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE8", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE9", SqlDbType.NVarChar,50),
					new SqlParameter("@CFREE10", SqlDbType.NVarChar,50),
					new SqlParameter("@CVMIVENCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@CITEM_CLASS", SqlDbType.NVarChar,10),
					new SqlParameter("@CITEMCNAME", SqlDbType.NVarChar,20),
					new SqlParameter("@CITEMCODE", SqlDbType.NVarChar,20),
					new SqlParameter("@CNAME", SqlDbType.NVarChar,60),
					new SqlParameter("@ISOTYPE", SqlDbType.Int,4),
					new SqlParameter("@CSOCODE", SqlDbType.NVarChar,50),
					new SqlParameter("@ISODID", SqlDbType.NVarChar,40),
					new SqlParameter("@CDEFINE22", SqlDbType.NVarChar,60),
					new SqlParameter("@CDEFINE23", SqlDbType.NVarChar,60),
					new SqlParameter("@CDEFINE24", SqlDbType.NVarChar,60),
					new SqlParameter("@CDEFINE25", SqlDbType.NVarChar,60),
					new SqlParameter("@CDEFINE26", SqlDbType.Float,8),
					new SqlParameter("@CDEFINE27", SqlDbType.Float,8),
					new SqlParameter("@CDEFINE28", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE29", SqlDbType.NVarChar,2000),
					new SqlParameter("@CDEFINE30", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE31", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE32", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE33", SqlDbType.NVarChar,120),
					new SqlParameter("@CDEFINE34", SqlDbType.Int,4),
					new SqlParameter("@CDEFINE35", SqlDbType.Int,4),
					new SqlParameter("@CDEFINE36", SqlDbType.DateTime),
					new SqlParameter("@CDEFINE37", SqlDbType.DateTime),
					new SqlParameter("@CBATCHPROPERTY1", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY2", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY3", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY4", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY5", SqlDbType.Decimal,17),
					new SqlParameter("@CBATCHPROPERTY6", SqlDbType.NVarChar,120),
					new SqlParameter("@CBATCHPROPERTY7", SqlDbType.NVarChar,120),
					new SqlParameter("@CBATCHPROPERTY8", SqlDbType.NVarChar,120),
					new SqlParameter("@CBATCHPROPERTY9", SqlDbType.NVarChar,120),
					new SqlParameter("@CBATCHPROPERTY10", SqlDbType.DateTime),
					new SqlParameter("@ITRACKID", SqlDbType.Int,4),
					new SqlParameter("@ITRACKTYPE", SqlDbType.NVarChar,50),
					new SqlParameter("@CBMEMO", SqlDbType.NVarChar,500),
					new SqlParameter("@TRAYNO", SqlDbType.NVarChar,50),
					new SqlParameter("@FLOWNO", SqlDbType.NVarChar,50),
					new SqlParameter("@RESERVE1", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE2", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE3", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE4", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE5", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE6", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE7", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE8", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE9", SqlDbType.NVarChar,200),
					new SqlParameter("@RESERVE10", SqlDbType.NVarChar,200),
					new SqlParameter("@PKID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.OPERORDER;
			parameters[1].Value = model.CVOUCHID;
			parameters[2].Value = model.ID;
			parameters[3].Value = model.CCODE;
			parameters[4].Value = model.CCUSCODE;
			parameters[5].Value = model.CVENCODE;
			parameters[6].Value = model.BARCODE;
			parameters[7].Value = model.OPERUSER;
			parameters[8].Value = model.OPERDATE;
			parameters[9].Value = model.CWHCODE;
			parameters[10].Value = model.AUTOID;
			parameters[11].Value = model.CINVCODE;
			parameters[12].Value = model.COPOSCODE;
			parameters[13].Value = model.CIPOSCODE;
			parameters[14].Value = model.CBATCH;
			parameters[15].Value = model.IMASSDATE;
			parameters[16].Value = model.CMASSUNIT;
			parameters[17].Value = model.DMDATE;
			parameters[18].Value = model.DVDATE;
			parameters[19].Value = model.IEXPIRATDATECALCU;
			parameters[20].Value = model.DEXPIRATIONDATE;
			parameters[21].Value = model.CEXPIRATIONDATE;
			parameters[22].Value = model.SNNO;
			parameters[23].Value = model.QTY;
			parameters[24].Value = model.IINVEXCHRATE;
			parameters[25].Value = model.INUM;
			parameters[26].Value = model.CASSUNIT;
			parameters[27].Value = model.CFREE1;
			parameters[28].Value = model.CFREE2;
			parameters[29].Value = model.CFREE3;
			parameters[30].Value = model.CFREE4;
			parameters[31].Value = model.CFREE5;
			parameters[32].Value = model.CFREE6;
			parameters[33].Value = model.CFREE7;
			parameters[34].Value = model.CFREE8;
			parameters[35].Value = model.CFREE9;
			parameters[36].Value = model.CFREE10;
			parameters[37].Value = model.CVMIVENCODE;
			parameters[38].Value = model.CITEM_CLASS;
			parameters[39].Value = model.CITEMCNAME;
			parameters[40].Value = model.CITEMCODE;
			parameters[41].Value = model.CNAME;
			parameters[42].Value = model.ISOTYPE;
			parameters[43].Value = model.CSOCODE;
			parameters[44].Value = model.ISODID;
			parameters[45].Value = model.CDEFINE22;
			parameters[46].Value = model.CDEFINE23;
			parameters[47].Value = model.CDEFINE24;
			parameters[48].Value = model.CDEFINE25;
			parameters[49].Value = model.CDEFINE26;
			parameters[50].Value = model.CDEFINE27;
			parameters[51].Value = model.CDEFINE28;
			parameters[52].Value = model.CDEFINE29;
			parameters[53].Value = model.CDEFINE30;
			parameters[54].Value = model.CDEFINE31;
			parameters[55].Value = model.CDEFINE32;
			parameters[56].Value = model.CDEFINE33;
			parameters[57].Value = model.CDEFINE34;
			parameters[58].Value = model.CDEFINE35;
			parameters[59].Value = model.CDEFINE36;
			parameters[60].Value = model.CDEFINE37;
			parameters[61].Value = model.CBATCHPROPERTY1;
			parameters[62].Value = model.CBATCHPROPERTY2;
			parameters[63].Value = model.CBATCHPROPERTY3;
			parameters[64].Value = model.CBATCHPROPERTY4;
			parameters[65].Value = model.CBATCHPROPERTY5;
			parameters[66].Value = model.CBATCHPROPERTY6;
			parameters[67].Value = model.CBATCHPROPERTY7;
			parameters[68].Value = model.CBATCHPROPERTY8;
			parameters[69].Value = model.CBATCHPROPERTY9;
			parameters[70].Value = model.CBATCHPROPERTY10;
			parameters[71].Value = model.ITRACKID;
			parameters[72].Value = model.ITRACKTYPE;
			parameters[73].Value = model.CBMEMO;
			parameters[74].Value = model.TRAYNO;
			parameters[75].Value = model.FLOWNO;
			parameters[76].Value = model.RESERVE1;
			parameters[77].Value = model.RESERVE2;
			parameters[78].Value = model.RESERVE3;
			parameters[79].Value = model.RESERVE4;
			parameters[80].Value = model.RESERVE5;
			parameters[81].Value = model.RESERVE6;
			parameters[82].Value = model.RESERVE7;
			parameters[83].Value = model.RESERVE8;
			parameters[84].Value = model.RESERVE9;
			parameters[85].Value = model.RESERVE10;
			parameters[86].Value = model.PKID;

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
		public bool Delete(string PKID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KGM_HISTORYBODY ");
			strSql.Append(" where PKID=@PKID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PKID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = PKID;

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
		public bool DeleteList(string PKIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KGM_HISTORYBODY ");
			strSql.Append(" where PKID in ("+PKIDlist + ")  ");
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
		public BarcodeTracking.Model.KGM_HISTORYBODY GetModel(string PKID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PKID,OPERORDER,CVOUCHID,ID,CCODE,CCUSCODE,CVENCODE,BARCODE,OPERUSER,OPERDATE,CWHCODE,AUTOID,CINVCODE,COPOSCODE,CIPOSCODE,CBATCH,IMASSDATE,CMASSUNIT,DMDATE,DVDATE,IEXPIRATDATECALCU,DEXPIRATIONDATE,CEXPIRATIONDATE,SNNO,QTY,IINVEXCHRATE,INUM,CASSUNIT,CFREE1,CFREE2,CFREE3,CFREE4,CFREE5,CFREE6,CFREE7,CFREE8,CFREE9,CFREE10,CVMIVENCODE,CITEM_CLASS,CITEMCNAME,CITEMCODE,CNAME,ISOTYPE,CSOCODE,ISODID,CDEFINE22,CDEFINE23,CDEFINE24,CDEFINE25,CDEFINE26,CDEFINE27,CDEFINE28,CDEFINE29,CDEFINE30,CDEFINE31,CDEFINE32,CDEFINE33,CDEFINE34,CDEFINE35,CDEFINE36,CDEFINE37,CBATCHPROPERTY1,CBATCHPROPERTY2,CBATCHPROPERTY3,CBATCHPROPERTY4,CBATCHPROPERTY5,CBATCHPROPERTY6,CBATCHPROPERTY7,CBATCHPROPERTY8,CBATCHPROPERTY9,CBATCHPROPERTY10,ITRACKID,ITRACKTYPE,CBMEMO,TRAYNO,FLOWNO,RESERVE1,RESERVE2,RESERVE3,RESERVE4,RESERVE5,RESERVE6,RESERVE7,RESERVE8,RESERVE9,RESERVE10 from KGM_HISTORYBODY ");
			strSql.Append(" where PKID=@PKID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PKID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = PKID;

			BarcodeTracking.Model.KGM_HISTORYBODY model=new BarcodeTracking.Model.KGM_HISTORYBODY();
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
		public BarcodeTracking.Model.KGM_HISTORYBODY DataRowToModel(DataRow row)
		{
			BarcodeTracking.Model.KGM_HISTORYBODY model=new BarcodeTracking.Model.KGM_HISTORYBODY();
			if (row != null)
			{
				if(row["PKID"]!=null)
				{
					model.PKID=row["PKID"].ToString();
				}
				if(row["OPERORDER"]!=null)
				{
					model.OPERORDER=row["OPERORDER"].ToString();
				}
				if(row["CVOUCHID"]!=null)
				{
					model.CVOUCHID=row["CVOUCHID"].ToString();
				}
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["CCODE"]!=null)
				{
					model.CCODE=row["CCODE"].ToString();
				}
				if(row["CCUSCODE"]!=null)
				{
					model.CCUSCODE=row["CCUSCODE"].ToString();
				}
				if(row["CVENCODE"]!=null)
				{
					model.CVENCODE=row["CVENCODE"].ToString();
				}
				if(row["BARCODE"]!=null)
				{
					model.BARCODE=row["BARCODE"].ToString();
				}
				if(row["OPERUSER"]!=null)
				{
					model.OPERUSER=row["OPERUSER"].ToString();
				}
				if(row["OPERDATE"]!=null && row["OPERDATE"].ToString()!="")
				{
					model.OPERDATE=DateTime.Parse(row["OPERDATE"].ToString());
				}
				if(row["CWHCODE"]!=null)
				{
					model.CWHCODE=row["CWHCODE"].ToString();
				}
				if(row["AUTOID"]!=null)
				{
					model.AUTOID=row["AUTOID"].ToString();
				}
				if(row["CINVCODE"]!=null)
				{
					model.CINVCODE=row["CINVCODE"].ToString();
				}
				if(row["COPOSCODE"]!=null)
				{
					model.COPOSCODE=row["COPOSCODE"].ToString();
				}
				if(row["CIPOSCODE"]!=null)
				{
					model.CIPOSCODE=row["CIPOSCODE"].ToString();
				}
				if(row["CBATCH"]!=null)
				{
					model.CBATCH=row["CBATCH"].ToString();
				}
				if(row["IMASSDATE"]!=null && row["IMASSDATE"].ToString()!="")
				{
					model.IMASSDATE=int.Parse(row["IMASSDATE"].ToString());
				}
				if(row["CMASSUNIT"]!=null && row["CMASSUNIT"].ToString()!="")
				{
					model.CMASSUNIT=int.Parse(row["CMASSUNIT"].ToString());
				}
				if(row["DMDATE"]!=null && row["DMDATE"].ToString()!="")
				{
					model.DMDATE=DateTime.Parse(row["DMDATE"].ToString());
				}
				if(row["DVDATE"]!=null && row["DVDATE"].ToString()!="")
				{
					model.DVDATE=DateTime.Parse(row["DVDATE"].ToString());
				}
				if(row["IEXPIRATDATECALCU"]!=null && row["IEXPIRATDATECALCU"].ToString()!="")
				{
					model.IEXPIRATDATECALCU=int.Parse(row["IEXPIRATDATECALCU"].ToString());
				}
				if(row["DEXPIRATIONDATE"]!=null && row["DEXPIRATIONDATE"].ToString()!="")
				{
					model.DEXPIRATIONDATE=DateTime.Parse(row["DEXPIRATIONDATE"].ToString());
				}
				if(row["CEXPIRATIONDATE"]!=null)
				{
					model.CEXPIRATIONDATE=row["CEXPIRATIONDATE"].ToString();
				}
				if(row["SNNO"]!=null)
				{
					model.SNNO=row["SNNO"].ToString();
				}
				if(row["QTY"]!=null && row["QTY"].ToString()!="")
				{
					model.QTY=int.Parse(row["QTY"].ToString());
				}
				if(row["IINVEXCHRATE"]!=null && row["IINVEXCHRATE"].ToString()!="")
				{
					model.IINVEXCHRATE=decimal.Parse(row["IINVEXCHRATE"].ToString());
				}
				if(row["INUM"]!=null && row["INUM"].ToString()!="")
				{
					model.INUM=decimal.Parse(row["INUM"].ToString());
				}
				if(row["CASSUNIT"]!=null)
				{
					model.CASSUNIT=row["CASSUNIT"].ToString();
				}
				if(row["CFREE1"]!=null)
				{
					model.CFREE1=row["CFREE1"].ToString();
				}
				if(row["CFREE2"]!=null)
				{
					model.CFREE2=row["CFREE2"].ToString();
				}
				if(row["CFREE3"]!=null)
				{
					model.CFREE3=row["CFREE3"].ToString();
				}
				if(row["CFREE4"]!=null)
				{
					model.CFREE4=row["CFREE4"].ToString();
				}
				if(row["CFREE5"]!=null)
				{
					model.CFREE5=row["CFREE5"].ToString();
				}
				if(row["CFREE6"]!=null)
				{
					model.CFREE6=row["CFREE6"].ToString();
				}
				if(row["CFREE7"]!=null)
				{
					model.CFREE7=row["CFREE7"].ToString();
				}
				if(row["CFREE8"]!=null)
				{
					model.CFREE8=row["CFREE8"].ToString();
				}
				if(row["CFREE9"]!=null)
				{
					model.CFREE9=row["CFREE9"].ToString();
				}
				if(row["CFREE10"]!=null)
				{
					model.CFREE10=row["CFREE10"].ToString();
				}
				if(row["CVMIVENCODE"]!=null)
				{
					model.CVMIVENCODE=row["CVMIVENCODE"].ToString();
				}
				if(row["CITEM_CLASS"]!=null)
				{
					model.CITEM_CLASS=row["CITEM_CLASS"].ToString();
				}
				if(row["CITEMCNAME"]!=null)
				{
					model.CITEMCNAME=row["CITEMCNAME"].ToString();
				}
				if(row["CITEMCODE"]!=null)
				{
					model.CITEMCODE=row["CITEMCODE"].ToString();
				}
				if(row["CNAME"]!=null)
				{
					model.CNAME=row["CNAME"].ToString();
				}
				if(row["ISOTYPE"]!=null && row["ISOTYPE"].ToString()!="")
				{
					model.ISOTYPE=int.Parse(row["ISOTYPE"].ToString());
				}
				if(row["CSOCODE"]!=null)
				{
					model.CSOCODE=row["CSOCODE"].ToString();
				}
				if(row["ISODID"]!=null)
				{
					model.ISODID=row["ISODID"].ToString();
				}
				if(row["CDEFINE22"]!=null)
				{
					model.CDEFINE22=row["CDEFINE22"].ToString();
				}
				if(row["CDEFINE23"]!=null)
				{
					model.CDEFINE23=row["CDEFINE23"].ToString();
				}
				if(row["CDEFINE24"]!=null)
				{
					model.CDEFINE24=row["CDEFINE24"].ToString();
				}
				if(row["CDEFINE25"]!=null)
				{
					model.CDEFINE25=row["CDEFINE25"].ToString();
				}
				if(row["CDEFINE26"]!=null && row["CDEFINE26"].ToString()!="")
				{
					model.CDEFINE26=decimal.Parse(row["CDEFINE26"].ToString());
				}
				if(row["CDEFINE27"]!=null && row["CDEFINE27"].ToString()!="")
				{
					model.CDEFINE27=decimal.Parse(row["CDEFINE27"].ToString());
				}
				if(row["CDEFINE28"]!=null)
				{
					model.CDEFINE28=row["CDEFINE28"].ToString();
				}
				if(row["CDEFINE29"]!=null)
				{
					model.CDEFINE29=row["CDEFINE29"].ToString();
				}
				if(row["CDEFINE30"]!=null)
				{
					model.CDEFINE30=row["CDEFINE30"].ToString();
				}
				if(row["CDEFINE31"]!=null)
				{
					model.CDEFINE31=row["CDEFINE31"].ToString();
				}
				if(row["CDEFINE32"]!=null)
				{
					model.CDEFINE32=row["CDEFINE32"].ToString();
				}
				if(row["CDEFINE33"]!=null)
				{
					model.CDEFINE33=row["CDEFINE33"].ToString();
				}
				if(row["CDEFINE34"]!=null && row["CDEFINE34"].ToString()!="")
				{
					model.CDEFINE34=int.Parse(row["CDEFINE34"].ToString());
				}
				if(row["CDEFINE35"]!=null && row["CDEFINE35"].ToString()!="")
				{
					model.CDEFINE35=int.Parse(row["CDEFINE35"].ToString());
				}
				if(row["CDEFINE36"]!=null && row["CDEFINE36"].ToString()!="")
				{
					model.CDEFINE36=DateTime.Parse(row["CDEFINE36"].ToString());
				}
				if(row["CDEFINE37"]!=null && row["CDEFINE37"].ToString()!="")
				{
					model.CDEFINE37=DateTime.Parse(row["CDEFINE37"].ToString());
				}
				if(row["CBATCHPROPERTY1"]!=null && row["CBATCHPROPERTY1"].ToString()!="")
				{
					model.CBATCHPROPERTY1=decimal.Parse(row["CBATCHPROPERTY1"].ToString());
				}
				if(row["CBATCHPROPERTY2"]!=null && row["CBATCHPROPERTY2"].ToString()!="")
				{
					model.CBATCHPROPERTY2=decimal.Parse(row["CBATCHPROPERTY2"].ToString());
				}
				if(row["CBATCHPROPERTY3"]!=null && row["CBATCHPROPERTY3"].ToString()!="")
				{
					model.CBATCHPROPERTY3=decimal.Parse(row["CBATCHPROPERTY3"].ToString());
				}
				if(row["CBATCHPROPERTY4"]!=null && row["CBATCHPROPERTY4"].ToString()!="")
				{
					model.CBATCHPROPERTY4=decimal.Parse(row["CBATCHPROPERTY4"].ToString());
				}
				if(row["CBATCHPROPERTY5"]!=null && row["CBATCHPROPERTY5"].ToString()!="")
				{
					model.CBATCHPROPERTY5=decimal.Parse(row["CBATCHPROPERTY5"].ToString());
				}
				if(row["CBATCHPROPERTY6"]!=null)
				{
					model.CBATCHPROPERTY6=row["CBATCHPROPERTY6"].ToString();
				}
				if(row["CBATCHPROPERTY7"]!=null)
				{
					model.CBATCHPROPERTY7=row["CBATCHPROPERTY7"].ToString();
				}
				if(row["CBATCHPROPERTY8"]!=null)
				{
					model.CBATCHPROPERTY8=row["CBATCHPROPERTY8"].ToString();
				}
				if(row["CBATCHPROPERTY9"]!=null)
				{
					model.CBATCHPROPERTY9=row["CBATCHPROPERTY9"].ToString();
				}
				if(row["CBATCHPROPERTY10"]!=null && row["CBATCHPROPERTY10"].ToString()!="")
				{
					model.CBATCHPROPERTY10=DateTime.Parse(row["CBATCHPROPERTY10"].ToString());
				}
				if(row["ITRACKID"]!=null && row["ITRACKID"].ToString()!="")
				{
					model.ITRACKID=int.Parse(row["ITRACKID"].ToString());
				}
				if(row["ITRACKTYPE"]!=null)
				{
					model.ITRACKTYPE=row["ITRACKTYPE"].ToString();
				}
				if(row["CBMEMO"]!=null)
				{
					model.CBMEMO=row["CBMEMO"].ToString();
				}
				if(row["TRAYNO"]!=null)
				{
					model.TRAYNO=row["TRAYNO"].ToString();
				}
				if(row["FLOWNO"]!=null)
				{
					model.FLOWNO=row["FLOWNO"].ToString();
				}
				if(row["RESERVE1"]!=null)
				{
					model.RESERVE1=row["RESERVE1"].ToString();
				}
				if(row["RESERVE2"]!=null)
				{
					model.RESERVE2=row["RESERVE2"].ToString();
				}
				if(row["RESERVE3"]!=null)
				{
					model.RESERVE3=row["RESERVE3"].ToString();
				}
				if(row["RESERVE4"]!=null)
				{
					model.RESERVE4=row["RESERVE4"].ToString();
				}
				if(row["RESERVE5"]!=null)
				{
					model.RESERVE5=row["RESERVE5"].ToString();
				}
				if(row["RESERVE6"]!=null)
				{
					model.RESERVE6=row["RESERVE6"].ToString();
				}
				if(row["RESERVE7"]!=null)
				{
					model.RESERVE7=row["RESERVE7"].ToString();
				}
				if(row["RESERVE8"]!=null)
				{
					model.RESERVE8=row["RESERVE8"].ToString();
				}
				if(row["RESERVE9"]!=null)
				{
					model.RESERVE9=row["RESERVE9"].ToString();
				}
				if(row["RESERVE10"]!=null)
				{
					model.RESERVE10=row["RESERVE10"].ToString();
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
			strSql.Append("select PKID,OPERORDER,CVOUCHID,ID,CCODE,CCUSCODE,CVENCODE,BARCODE,OPERUSER,OPERDATE,CWHCODE,AUTOID,CINVCODE,COPOSCODE,CIPOSCODE,CBATCH,IMASSDATE,CMASSUNIT,DMDATE,DVDATE,IEXPIRATDATECALCU,DEXPIRATIONDATE,CEXPIRATIONDATE,SNNO,QTY,IINVEXCHRATE,INUM,CASSUNIT,CFREE1,CFREE2,CFREE3,CFREE4,CFREE5,CFREE6,CFREE7,CFREE8,CFREE9,CFREE10,CVMIVENCODE,CITEM_CLASS,CITEMCNAME,CITEMCODE,CNAME,ISOTYPE,CSOCODE,ISODID,CDEFINE22,CDEFINE23,CDEFINE24,CDEFINE25,CDEFINE26,CDEFINE27,CDEFINE28,CDEFINE29,CDEFINE30,CDEFINE31,CDEFINE32,CDEFINE33,CDEFINE34,CDEFINE35,CDEFINE36,CDEFINE37,CBATCHPROPERTY1,CBATCHPROPERTY2,CBATCHPROPERTY3,CBATCHPROPERTY4,CBATCHPROPERTY5,CBATCHPROPERTY6,CBATCHPROPERTY7,CBATCHPROPERTY8,CBATCHPROPERTY9,CBATCHPROPERTY10,ITRACKID,ITRACKTYPE,CBMEMO,TRAYNO,FLOWNO,RESERVE1,RESERVE2,RESERVE3,RESERVE4,RESERVE5,RESERVE6,RESERVE7,RESERVE8,RESERVE9,RESERVE10 ");
			strSql.Append(" FROM KGM_HISTORYBODY ");
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
			strSql.Append(" PKID,OPERORDER,CVOUCHID,ID,CCODE,CCUSCODE,CVENCODE,BARCODE,OPERUSER,OPERDATE,CWHCODE,AUTOID,CINVCODE,COPOSCODE,CIPOSCODE,CBATCH,IMASSDATE,CMASSUNIT,DMDATE,DVDATE,IEXPIRATDATECALCU,DEXPIRATIONDATE,CEXPIRATIONDATE,SNNO,QTY,IINVEXCHRATE,INUM,CASSUNIT,CFREE1,CFREE2,CFREE3,CFREE4,CFREE5,CFREE6,CFREE7,CFREE8,CFREE9,CFREE10,CVMIVENCODE,CITEM_CLASS,CITEMCNAME,CITEMCODE,CNAME,ISOTYPE,CSOCODE,ISODID,CDEFINE22,CDEFINE23,CDEFINE24,CDEFINE25,CDEFINE26,CDEFINE27,CDEFINE28,CDEFINE29,CDEFINE30,CDEFINE31,CDEFINE32,CDEFINE33,CDEFINE34,CDEFINE35,CDEFINE36,CDEFINE37,CBATCHPROPERTY1,CBATCHPROPERTY2,CBATCHPROPERTY3,CBATCHPROPERTY4,CBATCHPROPERTY5,CBATCHPROPERTY6,CBATCHPROPERTY7,CBATCHPROPERTY8,CBATCHPROPERTY9,CBATCHPROPERTY10,ITRACKID,ITRACKTYPE,CBMEMO,TRAYNO,FLOWNO,RESERVE1,RESERVE2,RESERVE3,RESERVE4,RESERVE5,RESERVE6,RESERVE7,RESERVE8,RESERVE9,RESERVE10 ");
			strSql.Append(" FROM KGM_HISTORYBODY ");
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
			strSql.Append("select count(1) FROM KGM_HISTORYBODY ");
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
				strSql.Append("order by T.PKID desc");
			}
			strSql.Append(")AS Row, T.*  from KGM_HISTORYBODY T ");
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
			parameters[0].Value = "KGM_HISTORYBODY";
			parameters[1].Value = "PKID";
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

