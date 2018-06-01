using System;
namespace BarcodeTracking.Model
{
	/// <summary>
	/// PH_RELATIONHISTORY:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PH_RELATIONHISTORY
	{
		public PH_RELATIONHISTORY()
		{}
		#region Model
		private string _id;
		private string _boxcode;
		private string _palletnocode;
		private int? _cstatus;
		private string _jdeno;
		private DateTime? _inserttime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BOXCODE
		{
			set{ _boxcode=value;}
			get{return _boxcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PALLETNOCODE
		{
			set{ _palletnocode=value;}
			get{return _palletnocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CSTATUS
		{
			set{ _cstatus=value;}
			get{return _cstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JDENO
		{
			set{ _jdeno=value;}
			get{return _jdeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? INSERTTIME
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		#endregion Model

	}
}

