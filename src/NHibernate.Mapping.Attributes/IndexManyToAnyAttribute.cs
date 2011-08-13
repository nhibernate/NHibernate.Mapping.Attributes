// 
// NHibernate.Mapping.Attributes
// This product is under the terms of the GNU Lesser General Public License.
//
//
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 2.0.50727.x
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
//
//
// This source code was auto-generated by Refly, Version=2.21.1.0 (modified).
//
namespace NHibernate.Mapping.Attributes
{
	
	
	/// <summary> </summary>
	[System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, AllowMultiple=true)]
	[System.Serializable()]
	public class IndexManyToAnyAttribute : BaseAttribute
	{
		
		private string _idtype = null;
		
		private string _metatype = null;
		
		private string _column = null;
		
		/// <summary> Default constructor (position=0) </summary>
		public IndexManyToAnyAttribute() : 
				base(0)
		{
		}
		
		/// <summary> Constructor taking the position of the attribute. </summary>
		public IndexManyToAnyAttribute(int position) : 
				base(position)
		{
		}
		
		/// <summary> </summary>
		public virtual string IdType
		{
			get
			{
				return this._idtype;
			}
			set
			{
				this._idtype = value;
			}
		}
		
		/// <summary> </summary>
		public virtual System.Type IdTypeType
		{
			get
			{
				return System.Type.GetType( this.IdType );
			}
			set
			{
				if(value.Assembly == typeof(int).Assembly)
					this.IdType = value.FullName.Substring(7);
				else
					this.IdType = HbmWriterHelper.GetNameWithAssembly(value);
			}
		}
		
		/// <summary> </summary>
		public virtual string MetaType
		{
			get
			{
				return this._metatype;
			}
			set
			{
				this._metatype = value;
			}
		}
		
		/// <summary> </summary>
		public virtual System.Type MetaTypeType
		{
			get
			{
				return System.Type.GetType( this.MetaType );
			}
			set
			{
				if(value.Assembly == typeof(int).Assembly)
					this.MetaType = value.FullName.Substring(7);
				else
					this.MetaType = HbmWriterHelper.GetNameWithAssembly(value);
			}
		}
		
		/// <summary> </summary>
		public virtual string Column
		{
			get
			{
				return this._column;
			}
			set
			{
				this._column = value;
			}
		}
	}
}
