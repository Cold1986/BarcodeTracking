using System;
namespace BarcodeTracking.Model
{
	/// <summary>
	/// RepositoryInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RepositoryInfo
	{
		public RepositoryInfo()
		{}
		#region Model
		private int _id;
		private string _repositoryno;
		private string _description;
		private DateTime? _lastupdatedtime;
		private string _lastupdatedby;
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
		public string repositoryNo
		{
			set{ _repositoryno=value;}
			get{return _repositoryno;}
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
		public DateTime? lastUpdatedTime
		{
			set{ _lastupdatedtime=value;}
			get{return _lastupdatedtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lastUpdatedBy
		{
			set{ _lastupdatedby=value;}
			get{return _lastupdatedby;}
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

