using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BarcodeTracking.Model;
namespace BarcodeTracking.BLL
{
	/// <summary>
	/// 卡板标签记录
	/// </summary>
	public partial class PH_PALLETLABEL
	{
		private readonly BarcodeTracking.DAL.PH_PALLETLABEL dal=new BarcodeTracking.DAL.PH_PALLETLABEL();
		public PH_PALLETLABEL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID,string BARCODE,string CODE)
		{
			return dal.Exists(ID,BARCODE,CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BarcodeTracking.Model.PH_PALLETLABEL model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BarcodeTracking.Model.PH_PALLETLABEL model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID,string BARCODE,string CODE)
		{
			
			return dal.Delete(ID,BARCODE,CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BarcodeTracking.Model.PH_PALLETLABEL GetModel(string ID,string BARCODE,string CODE)
		{
			
			return dal.GetModel(ID,BARCODE,CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BarcodeTracking.Model.PH_PALLETLABEL GetModelByCache(string ID,string BARCODE,string CODE)
		{
			
			string CacheKey = "PH_PALLETLABELModel-" + ID+BARCODE+CODE;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID,BARCODE,CODE);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BarcodeTracking.Model.PH_PALLETLABEL)objModel;
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
		public List<BarcodeTracking.Model.PH_PALLETLABEL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BarcodeTracking.Model.PH_PALLETLABEL> DataTableToList(DataTable dt)
		{
			List<BarcodeTracking.Model.PH_PALLETLABEL> modelList = new List<BarcodeTracking.Model.PH_PALLETLABEL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BarcodeTracking.Model.PH_PALLETLABEL model;
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

