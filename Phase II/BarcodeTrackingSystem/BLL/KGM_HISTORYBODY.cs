using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BarcodeTracking.Model;
namespace BarcodeTracking.BLL
{
	/// <summary>
	/// KGM_HISTORYBODY
	/// </summary>
	public partial class KGM_HISTORYBODY
	{
		private readonly BarcodeTracking.DAL.KGM_HISTORYBODY dal=new BarcodeTracking.DAL.KGM_HISTORYBODY();
		public KGM_HISTORYBODY()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PKID)
		{
			return dal.Exists(PKID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BarcodeTracking.Model.KGM_HISTORYBODY model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BarcodeTracking.Model.KGM_HISTORYBODY model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PKID)
		{
			
			return dal.Delete(PKID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PKIDlist )
		{
			return dal.DeleteList(PKIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BarcodeTracking.Model.KGM_HISTORYBODY GetModel(string PKID)
		{
			
			return dal.GetModel(PKID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BarcodeTracking.Model.KGM_HISTORYBODY GetModelByCache(string PKID)
		{
			
			string CacheKey = "KGM_HISTORYBODYModel-" + PKID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PKID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BarcodeTracking.Model.KGM_HISTORYBODY)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BarcodeTracking.Model.KGM_HISTORYBODY> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BarcodeTracking.Model.KGM_HISTORYBODY> DataTableToList(DataTable dt)
		{
			List<BarcodeTracking.Model.KGM_HISTORYBODY> modelList = new List<BarcodeTracking.Model.KGM_HISTORYBODY>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BarcodeTracking.Model.KGM_HISTORYBODY model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

