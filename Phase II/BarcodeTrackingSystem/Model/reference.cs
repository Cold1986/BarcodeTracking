using System;
namespace BarcodeTracking.Model
{
	/// <summary>
	/// reference:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class reference
	{
		public reference()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _project;
		private string _color;
		private string _boxtype;
		private string _productversion;
		private string _apn;
		private string _label;
		private string _jdeno;
		private string _outjdeno;
		private string _oemcustno;
		private string _outcustno;
		private string _packingqty="0";
		private string _description;
		private int _version;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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
		public string productVersion
		{
			set{ _productversion=value;}
			get{return _productversion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string apn
		{
			set{ _apn=value;}
			get{return _apn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string label
		{
			set{ _label=value;}
			get{return _label;}
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
		public string outJDENo
		{
			set{ _outjdeno=value;}
			get{return _outjdeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string oemCustNo
		{
			set{ _oemcustno=value;}
			get{return _oemcustno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string outCustNo
		{
			set{ _outcustno=value;}
			get{return _outcustno;}
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
		public int version
		{
			set{ _version=value;}
			get{return _version;}
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

