using System;
namespace BarcodeTracking.Model
{
	/// <summary>
	/// KS_Condiments_Reference:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KS_Condiments_Reference
	{
		public KS_Condiments_Reference()
		{}
		#region Model
		private int _id;
		private string _project;
		private string _color;
		private string _boxtype;
		private string _jdeno;
		private string _packingqty="0";
		private string _description;
		private string _factorycode;
		private string _operatedby;
		private DateTime _operatedtime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string project
		{
			set{ _project=value;}
			get{return _project;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string color
		{
			set{ _color=value;}
			get{return _color;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string boxType
		{
			set{ _boxtype=value;}
			get{return _boxtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jdeNo
		{
			set{ _jdeno=value;}
			get{return _jdeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string packingQty
		{
			set{ _packingqty=value;}
			get{return _packingqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string factoryCode
		{
			set{ _factorycode=value;}
			get{return _factorycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string operatedBy
		{
			set{ _operatedby=value;}
			get{return _operatedby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime operatedTime
		{
			set{ _operatedtime=value;}
			get{return _operatedtime;}
		}
		#endregion Model

	}
}

