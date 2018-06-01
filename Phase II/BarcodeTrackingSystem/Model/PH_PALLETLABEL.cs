using System;
namespace BarcodeTracking.Model
{
	/// <summary>
	/// 卡板标签记录
	/// </summary>
	[Serializable]
	public partial class PH_PALLETLABEL
	{
		public PH_PALLETLABEL()
		{}
		#region Model
		private string _id;
		private string _barcode;
		private string _code;
		private string _name;
		private string _apn;
		private string _jdeno;
		private int? _boxqty;
		private int? _qty;
		private int? _boxstate;
		private string _remarks;
		private string _factorycode;
		private string _createby;
		private string _createuserid;
		private DateTime? _createon;
		private string _modifiedby;
		private string _modifieduserid;
		private DateTime? _modifiedon;
		private string _deletemark;
		private int? _sortcode;
		/// <summary>
		/// 主键
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 卡板二维码
		/// </summary>
		public string BARCODE
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 卡板ID
		/// </summary>
		public string CODE
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// AP/N
		/// </summary>
		public string APN
		{
			set{ _apn=value;}
			get{return _apn;}
		}
		/// <summary>
		/// JDE料号
		/// </summary>
		public string JDENO
		{
			set{ _jdeno=value;}
			get{return _jdeno;}
		}
		/// <summary>
		/// 箱数
		/// </summary>
		public int? BOXQTY
		{
			set{ _boxqty=value;}
			get{return _boxqty;}
		}
		/// <summary>
		/// 此版数量
		/// </summary>
		public int? QTY
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 卡板状态
		/// </summary>
		public int? BOXSTATE
		{
			set{ _boxstate=value;}
			get{return _boxstate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARKS
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// 制造工厂编码
		/// </summary>
		public string FACTORYCODE
		{
			set{ _factorycode=value;}
			get{return _factorycode;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string CREATEBY
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 创建人编码
		/// </summary>
		public string CREATEUSERID
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CREATEON
		{
			set{ _createon=value;}
			get{return _createon;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public string MODIFIEDBY
		{
			set{ _modifiedby=value;}
			get{return _modifiedby;}
		}
		/// <summary>
		/// 修改人编码
		/// </summary>
		public string MODIFIEDUSERID
		{
			set{ _modifieduserid=value;}
			get{return _modifieduserid;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? MODIFIEDON
		{
			set{ _modifiedon=value;}
			get{return _modifiedon;}
		}
		/// <summary>
		/// 删除标记
		/// </summary>
		public string DELETEMARK
		{
			set{ _deletemark=value;}
			get{return _deletemark;}
		}
		/// <summary>
		/// 排序码
		/// </summary>
		public int? SORTCODE
		{
			set{ _sortcode=value;}
			get{return _sortcode;}
		}
		#endregion Model

	}
}

