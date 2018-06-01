using System;
namespace BarcodeTracking.Model
{
	/// <summary>
	/// sys_ddlData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_ddlData
	{
		public sys_ddlData()
		{}
		#region Model
		private int _id;
		private string _showkey;
		private string _showvalue;
		private string _type;
		private int? _sort;
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
		public string showKey
		{
			set{ _showkey=value;}
			get{return _showkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string showValue
		{
			set{ _showvalue=value;}
			get{return _showvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

