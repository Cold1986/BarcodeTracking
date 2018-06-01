using System;
namespace BarcodeTracking.Model
{
	/// <summary>
	/// ref_version:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ref_version
	{
		public ref_version()
		{}
		#region Model
		private int _id;
		private string _factorycode="0";
		private string _version;
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
		public string factoryCode
		{
			set{ _factorycode=value;}
			get{return _factorycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string version
		{
			set{ _version=value;}
			get{return _version;}
		}
		#endregion Model

	}
}

