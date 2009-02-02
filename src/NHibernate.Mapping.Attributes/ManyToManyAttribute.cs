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
	public class ManyToManyAttribute : BaseAttribute
	{
		
		private bool _uniquespecified;
		
		private string _foreignkey = null;
		
		private string _where = null;
		
		private bool _embedxml = true;
		
		private string _node = null;
		
		private string _class = null;
		
		private string _propertyref = null;
		
		private string _orderby = null;
		
		private string _column = null;
		
		private bool _unique = false;
		
		private NotFoundMode _notfound = NotFoundMode.Unspecified;
		
		private RestrictedLaziness _lazy = RestrictedLaziness.Unspecified;
		
		private bool _embedxmlspecified;
		
		private string _formula = null;
		
		private OuterJoinStrategy _outerjoin = OuterJoinStrategy.Unspecified;
		
		private string _entityname = null;
		
		private FetchMode _fetch = FetchMode.Unspecified;
		
		/// <summary> Default constructor (position=0) </summary>
		public ManyToManyAttribute() : 
				base(0)
		{
		}
		
		/// <summary> Constructor taking the position of the attribute. </summary>
		public ManyToManyAttribute(int position) : 
				base(position)
		{
		}
		
		/// <summary> </summary>
		public virtual string Class
		{
			get
			{
				return this._class;
			}
			set
			{
				this._class = value;
			}
		}
		
		/// <summary> </summary>
		public virtual System.Type ClassType
		{
			get
			{
				return System.Type.GetType( this.Class );
			}
			set
			{
				if(value.Assembly == typeof(int).Assembly)
					this.Class = value.FullName.Substring(7);
				else
					this.Class = value.FullName + ", " + value.Assembly.GetName().Name;
			}
		}
		
		/// <summary> </summary>
		public virtual string Node
		{
			get
			{
				return this._node;
			}
			set
			{
				this._node = value;
			}
		}
		
		/// <summary> </summary>
		public virtual bool EmbedXml
		{
			get
			{
				return this._embedxml;
			}
			set
			{
				this._embedxml = value;
				_embedxmlspecified = true;
			}
		}
		
		/// <summary> Tells if EmbedXml has been specified. </summary>
		public virtual bool EmbedXmlSpecified
		{
			get
			{
				return this._embedxmlspecified;
			}
		}
		
		/// <summary> </summary>
		public virtual string EntityName
		{
			get
			{
				return this._entityname;
			}
			set
			{
				this._entityname = value;
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
		
		/// <summary> </summary>
		public virtual string Formula
		{
			get
			{
				return this._formula;
			}
			set
			{
				this._formula = value;
			}
		}
		
		/// <summary> </summary>
		public virtual NotFoundMode NotFound
		{
			get
			{
				return this._notfound;
			}
			set
			{
				this._notfound = value;
			}
		}
		
		/// <summary> </summary>
		public virtual OuterJoinStrategy OuterJoin
		{
			get
			{
				return this._outerjoin;
			}
			set
			{
				this._outerjoin = value;
			}
		}
		
		/// <summary> </summary>
		public virtual FetchMode Fetch
		{
			get
			{
				return this._fetch;
			}
			set
			{
				this._fetch = value;
			}
		}
		
		/// <summary> </summary>
		public virtual RestrictedLaziness Lazy
		{
			get
			{
				return this._lazy;
			}
			set
			{
				this._lazy = value;
			}
		}
		
		/// <summary> </summary>
		public virtual string ForeignKey
		{
			get
			{
				return this._foreignkey;
			}
			set
			{
				this._foreignkey = value;
			}
		}
		
		/// <summary> </summary>
		public virtual bool Unique
		{
			get
			{
				return this._unique;
			}
			set
			{
				this._unique = value;
				_uniquespecified = true;
			}
		}
		
		/// <summary> Tells if Unique has been specified. </summary>
		public virtual bool UniqueSpecified
		{
			get
			{
				return this._uniquespecified;
			}
		}
		
		/// <summary> </summary>
		public virtual string Where
		{
			get
			{
				return this._where;
			}
			set
			{
				this._where = value;
			}
		}
		
		/// <summary> </summary>
		public virtual string OrderBy
		{
			get
			{
				return this._orderby;
			}
			set
			{
				this._orderby = value;
			}
		}
		
		/// <summary> </summary>
		public virtual string PropertyRef
		{
			get
			{
				return this._propertyref;
			}
			set
			{
				this._propertyref = value;
			}
		}
	}
}
