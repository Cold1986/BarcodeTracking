using System;
namespace BarcodeTracking.Model
{
	/// <summary>
	/// jurisdiction:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class jurisdiction
	{
		public jurisdiction()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _adaccount;
		private DateTime? _createdtime;
		private string _createdby;
		private string _status;
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
		public string adAccount
		{
			set{ _adaccount=value;}
			get{return _adaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createdTime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string createdBy
		{
			set{ _createdby=value;}
			get{return _createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

