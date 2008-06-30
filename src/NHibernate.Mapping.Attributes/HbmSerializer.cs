//
// NHibernate.Mapping.Attributes
// This product is under the terms of the GNU Lesser General Public License.
//
namespace NHibernate.Mapping.Attributes
{
	/// <summary>
	/// Build hbm.xml files from entities (Class, Subclass or JoinedSubclass).
	/// </summary>
	public class HbmSerializer
	{
		#region static HbmSerializer Default
		private static HbmSerializer _default = new HbmSerializer();

		/// <summary> Gets a static instance of HbmSerializer (if you don't want/need to create an instance). </summary>
		public static HbmSerializer Default
		{
			get { return _default; }
		}
		#endregion


		#region HbmWriter, Validate, WriteDateComment and Error properties
		private HbmWriter _hbmWriter = new HbmWriterEx();
		private bool _validate = false;
		private bool _stop; // used to stop the validation
		private bool _writeDateComment = true;
		private System.Text.StringBuilder _error = new System.Text.StringBuilder();

		/// <summary> Gets or sets the HbmWriter to use. </summary>
		public virtual HbmWriter HbmWriter
		{
			get { return _hbmWriter; }
			set { _hbmWriter = value; }
		}

		/// <summary> Gets or sets whether generated xml files must be validated against NHibernate mapping schema. </summary>
		public virtual bool Validate
		{
			get { return _validate; }
			set { _validate = value; }
		}

		/// <summary> Gets or sets whether generated xml files will contain a comment with the date/time of the generation. </summary>
		public virtual bool WriteDateComment
		{
			get { return _writeDateComment; }
			set { _writeDateComment = value; }
		}

		/// <summary> Gets errors that occur while serializing. </summary>
		public virtual System.Text.StringBuilder Error
		{
			get { return _error; }
		}
		#endregion


		#region HibernateMapping-related properties (attributes and their IsSpecifieds)
		private bool _defaultlazy = true;
		private bool _autoimport = true;
		private string _schema = null;
		private string _defaultaccess = null;
		private string _assembly = null;
		private string _namespace = null;
		private string _defaultcascade = null;

		private bool _defaultlazyIsSpecified = false;
		private bool _autoimportIsSpecified = false;
		private bool _schemaIsSpecified = false;
		private bool _defaultaccessIsSpecified = false;
		private bool _assemblyIsSpecified = false;
		private bool _namespaceIsSpecified = false;
		private bool _defaultcascadeIsSpecified = false;


		/// <summary> Gets or sets this "hibernate-mapping" attribute </summary>
		public bool HbmDefaultLazy
		{
			get
			{
				return _defaultlazy;
			}
			set
			{
				_defaultlazy = value;
				HbmDefaultLazyIsSpecified = true;
			}
		}

		/// <summary> Gets or sets this "hibernate-mapping" attribute </summary>
		public virtual string HbmSchema
		{
			get
			{
				return _schema;
			}
			set
			{
				_schema = value;
				HbmSchemaIsSpecified = true;
			}
		}

		/// <summary> Gets or sets this "hibernate-mapping" attribute </summary>
		public virtual string HbmDefaultCascade
		{
			get
			{
				return _defaultcascade;
			}
			set
			{
				_defaultcascade = value;
				HbmDefaultCascadeIsSpecified = true;
			}
		}

		/// <summary> Gets or sets this "hibernate-mapping" attribute </summary>
		public virtual string HbmDefaultAccess
		{
			get
			{
				return _defaultaccess;
			}
			set
			{
				_defaultaccess = value;
				HbmDefaultAccessIsSpecified = true;
			}
		}

		/// <summary> Gets or sets this "hibernate-mapping" attribute </summary>
		public virtual System.Type HbmDefaultAccessType
		{
			get
			{
				return System.Type.GetType( HbmDefaultAccess );
			}
			set
			{
				if(value.Assembly == typeof(int).Assembly)
					HbmDefaultAccess = value.FullName.Substring(7);
				else
					HbmDefaultAccess = value.FullName + ", " + value.Assembly.GetName().Name;
			}
		}

		/// <summary> Gets or sets this "hibernate-mapping" attribute </summary>
		public virtual bool HbmAutoImport
		{
			get
			{
				return _autoimport;
			}
			set
			{
				_autoimport = value;
				HbmAutoImportIsSpecified = true;
			}
		}

		/// <summary> Gets or sets this "hibernate-mapping" attribute </summary>
		public virtual string HbmNamespace
		{
			get
			{
				return _namespace;
			}
			set
			{
				_namespace = value;
				HbmNamespaceIsSpecified = true;
			}
		}

		/// <summary> Gets or sets this "hibernate-mapping" attribute </summary>
		public virtual string HbmAssembly
		{
			get
			{
				return _assembly;
			}
			set
			{
				_assembly = value;
				HbmAssemblyIsSpecified = true;
			}
		}


		/// <summary> Gets or sets if this "hibernate-mapping" attribute is specified </summary>
		public virtual bool HbmDefaultLazyIsSpecified
		{
			get { return _defaultlazyIsSpecified; }
			set { _defaultlazyIsSpecified = value; }
		}

		/// <summary> Gets or sets if this "hibernate-mapping" attribute is specified </summary>
		public virtual bool HbmAutoImportIsSpecified
		{
			get { return _autoimportIsSpecified; }
			set { _autoimportIsSpecified = value; }
		}

		/// <summary> Gets or sets if this "hibernate-mapping" attribute is specified </summary>
		public virtual bool HbmSchemaIsSpecified
		{
			get { return _schemaIsSpecified; }
			set { _schemaIsSpecified = value; }
		}

		/// <summary> Gets or sets if this "hibernate-mapping" attribute is specified </summary>
		public virtual bool HbmDefaultAccessIsSpecified
		{
			get { return _defaultaccessIsSpecified; }
			set { _defaultaccessIsSpecified = value; }
		}

		/// <summary> Gets or sets if this "hibernate-mapping" attribute is specified </summary>
		public virtual bool HbmAssemblyIsSpecified
		{
			get { return _assemblyIsSpecified; }
			set { _assemblyIsSpecified = value; }
		}

		/// <summary> Gets or sets if this "hibernate-mapping" attribute is specified </summary>
		public virtual bool HbmNamespaceIsSpecified
		{
			get { return _namespaceIsSpecified; }
			set { _namespaceIsSpecified = value; }
		}

		/// <summary> Gets or sets if this "hibernate-mapping" attribute is specified </summary>
		public virtual bool HbmDefaultCascadeIsSpecified
		{
			get { return _defaultcascadeIsSpecified; }
			set { _defaultcascadeIsSpecified = value; }
		}
		#endregion


		#region Serialize() for Assemblies
		/// <summary> Writes a hbm.xml file in the specified directory for each mapped class in the specified assembly. </summary>
		/// <param name="directory">Directory where each serialized hbm.xml file will be written.</param>
		/// <param name="assembly">Assembly used to extract user-defined types containing a valid attribute (can be [Class] or [xSubclass]).</param>
		public virtual void Serialize(string directory, System.Reflection.Assembly assembly)
		{
			if(assembly == null)
				throw new System.ArgumentNullException("assembly");

			foreach(System.Type type in assembly.GetTypes())
			{
				if( type.IsNestedFamORAssem || type.IsNestedPrivate || type.IsNestedPublic )
					continue; // will be include in its container mapping file
				if( IsClass(type) || IsSubclass(type) )
					Serialize( System.IO.Path.Combine(directory, type.Name+".hbm.xml"), type );
			}
		}


		/// <summary> Writes the mapping of all mapped classes of the specified assembly in the specified hbm.xml file. </summary>
		/// <param name="assembly">Assembly used to extract user-defined types containing a valid attribute (can be [Class] or [xSubclass]).</param>
		/// <param name="filePath">Where the xml is written.</param>
		public virtual void Serialize(System.Reflection.Assembly assembly, string filePath)
		{
			using( System.IO.Stream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create) )
				Serialize(stream, assembly);
		}


		/// <summary> Writes the mapping of all mapped classes of the specified assembly in the specified stream. </summary>
		/// <param name="stream">Where the xml is written.</param>
		/// <param name="assembly">Assembly used to extract user-defined types containing a valid attribute (can be [Class] or [xSubclass]).</param>
		public virtual void Serialize(System.IO.Stream stream, System.Reflection.Assembly assembly)
		{
			if(stream == null)
				throw new System.ArgumentNullException("stream");
			if(assembly == null)
				throw new System.ArgumentNullException("assembly");

			System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter( stream, System.Text.Encoding.UTF8 );
			writer.Formatting = System.Xml.Formatting.Indented;
			writer.WriteStartDocument();
			if(WriteDateComment)
				writer.WriteComment( string.Format( "Generated from NHibernate.Mapping.Attributes on {0}.", System.DateTime.Now.ToString("u") ) );
			WriteHibernateMapping(writer, null);

			// Write imports (classes decorated with the [ImportAttribute])
			foreach(System.Type type in assembly.GetTypes())
			{
				object[] imports = type.GetCustomAttributes(typeof(ImportAttribute), false);
				foreach(ImportAttribute import in imports)
				{
					writer.WriteStartElement("import");
					if(import.Class != null && import.Class != string.Empty)
						writer.WriteAttributeString("class", import.Class);
					else // Assume that it is the current type that must be imported
						writer.WriteAttributeString("class", type.FullName + ", " + type.Assembly.GetName().Name);
					if(import.Rename != null && import.Rename != string.Empty)
						writer.WriteAttributeString("rename", import.Rename);
					writer.WriteEndElement();
				}
			}

			// Write classes and x-subclasses (classes must come first if inherited by "external" subclasses)
			System.Collections.ArrayList mappedClassesNames = new System.Collections.ArrayList();
			foreach(System.Type type in assembly.GetTypes())
			{
				if( ! IsClass(type) )
					continue;
				HbmWriter.WriteClass(writer, type);
				mappedClassesNames.Add(type.FullName + ", " + type.Assembly.GetName().Name);
			}

			System.Collections.ArrayList subclasses = new System.Collections.ArrayList();
			System.Collections.Specialized.StringCollection extendedClassesNames = new System.Collections.Specialized.StringCollection();
			foreach(System.Type type in assembly.GetTypes())
			{
				if( ! IsSubclass(type) )
					continue;
				bool map = true;
				System.Type t = type;
				while( (t=t.DeclaringType) != null )
					if (IsClass(t) || AreSameSubclass(type, t)) // If a base class is also mapped... (Note: A x-subclass can only contain x-subclasses of the same family)
					{
						map = false; // This class's mapping is already included in the mapping of the base class
						break;
					}
				if(map)
				{
					subclasses.Add(type);
					if( IsSubclass(type, typeof(SubclassAttribute)) )
						extendedClassesNames.Add((type.GetCustomAttributes(typeof(SubclassAttribute), false)[0] as SubclassAttribute).Extends);
					else if( IsSubclass(type, typeof(JoinedSubclassAttribute)) )
						extendedClassesNames.Add((type.GetCustomAttributes(typeof(JoinedSubclassAttribute), false)[0] as JoinedSubclassAttribute).Extends);
					else if( IsSubclass(type, typeof(UnionSubclassAttribute)) )
						extendedClassesNames.Add((type.GetCustomAttributes(typeof(UnionSubclassAttribute), false)[0] as UnionSubclassAttribute).Extends);
				}
			}
			MapSubclasses(subclasses, extendedClassesNames, mappedClassesNames, writer);

			writer.WriteEndElement(); // </hibernate-mapping>
			writer.WriteEndDocument();
			writer.Flush();

			if( ! Validate )
				return;

			// Validate the generated XML stream
			try
			{
				writer.BaseStream.Position = 0;
				System.Xml.XmlTextReader tr = new System.Xml.XmlTextReader(writer.BaseStream);
				System.Xml.XmlValidatingReader vr = new System.Xml.XmlValidatingReader(tr);

				// Open the Schema
				System.IO.Stream schema = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("NHibernate.Mapping.Attributes.nhibernate-mapping.xsd");
				vr.Schemas.Add("urn:nhibernate-mapping-2.2", new System.Xml.XmlTextReader(schema));
				vr.ValidationType = System.Xml.ValidationType.Schema;
				vr.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(XmlValidationHandler);

				_stop = false;
				while(vr.Read() && !_stop) // Read to validate (stop at the first error)
					;
			}
			catch(System.Exception ex)
			{
				Error.Append(ex.ToString()).Append(System.Environment.NewLine + System.Environment.NewLine);
			}
		}


		/// <summary> Writes the mapping of all mapped classes of the specified assembly in a MemoryStream and returns it. </summary>
		/// <param name="assembly">Assembly used to extract user-defined types containing a valid attribute (can be [Class] or [xSubclass]).</param>
		/// <returns>Stream containing the XML mapping.</returns>
		public virtual System.IO.MemoryStream Serialize(System.Reflection.Assembly assembly)
		{
			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			try
			{
				Serialize(stream, assembly);
				stream.Position = 0;
			}
			catch
			{
				stream.Close();
				throw;
			}
			return stream;
		}
		#endregion


		#region Serialize() for Classes
		/// <summary> Writes the mapping of the specified class in a MemoryStream and returns it. </summary>
		/// <param name="type">User-defined type containing a valid attribute (can be [Class] or [xSubclass]).</param>
		/// <returns>Stream containing the XML mapping.</returns>
		public virtual System.IO.MemoryStream Serialize(System.Type type)
		{
			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			try
			{
				Serialize(stream, type);
				stream.Position = 0;
			}
			catch
			{
				stream.Close();
				throw;
			}
			return stream;
		}


		/// <summary> Writes the mapping of the specified class in the specified hbm.xml file. </summary>
		/// <param name="filePath">Where the xml is written.</param>
		/// <param name="type">User-defined type containing a valid attribute (can be [Class] or [xSubclass]).</param>
		public virtual void Serialize(string filePath, System.Type type)
		{
			using( System.IO.Stream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create) )
				Serialize(stream, type);
		}


		/// <summary> Writes the mapping of the specified class in the specified stream. </summary>
		/// <param name="stream">Where the xml is written.</param>
		/// <param name="type">User-defined type containing a valid attribute (can be [Class] or [xSubclass]).</param>
		public virtual void Serialize(System.IO.Stream stream, System.Type type)
		{
			Serialize(stream, type, null, true);
		}


		/// <summary> Writes the mapping of the specified class in the specified stream. </summary>
		/// <param name="stream">Where the xml is written; can be null if you send the writer.</param>
		/// <param name="type">User-defined type containing a valid attribute (can be [Class] or [xSubclass]).</param>
		/// <param name="writer">The XmlTextWriter used to write the xml; can be null if you send the stream. You can also create it yourself, but don't forget to write the StartElement ("hibernate-mapping") before.</param>
		/// <param name="writeEndDocument">Tells if the EndElement of "hibernate-mapping" must be written; send false to append many classes in the same stream.</param>
		/// <returns>The parameter writer if it was not null; else it is a new writer (created using the stream). Send it back to append many classes in this stream.</returns>
		public virtual System.Xml.XmlTextWriter Serialize(System.IO.Stream stream, System.Type type, System.Xml.XmlTextWriter writer, bool writeEndDocument)
		{
			if(stream == null && writer == null)
				throw new System.ArgumentNullException("stream");
			if(type == null)
				throw new System.ArgumentNullException("type");

			if( writer == null )
			{
				writer = new System.Xml.XmlTextWriter( stream, System.Text.Encoding.UTF8 );
				writer.Formatting = System.Xml.Formatting.Indented;
				writer.WriteStartDocument();
				if(WriteDateComment)
					writer.WriteComment( string.Format( "Generated by NHibernate.Mapping.Attributes on {0}.", System.DateTime.Now.ToString("u") ) );
				WriteHibernateMapping(writer, type);
			}

			if( IsClass(type) )
				HbmWriter.WriteClass(writer, type);
			else if( IsSubclass(type, typeof(SubclassAttribute)) )
				HbmWriter.WriteSubclass(writer, type);
			else if( IsSubclass(type, typeof(JoinedSubclassAttribute)) )
				HbmWriter.WriteJoinedSubclass(writer, type);
			else if( IsSubclass(type, typeof(UnionSubclassAttribute)) )
				HbmWriter.WriteUnionSubclass(writer, type);
			else
				throw new System.ArgumentException("No valid attribute; looking for [Class] or [xSubclass].", "type");

			if(writeEndDocument)
			{
				writer.WriteEndElement(); // </hibernate-mapping>
				writer.WriteEndDocument();
				writer.Flush();

				if( ! Validate )
					return writer;

				// Validate the generated XML stream
				try
				{
					writer.BaseStream.Position = 0;
					System.Xml.XmlTextReader tr = new System.Xml.XmlTextReader(writer.BaseStream);
					System.Xml.XmlValidatingReader vr = new System.Xml.XmlValidatingReader(tr);

					// Open the Schema
					System.IO.Stream schema = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("NHibernate.Mapping.Attributes.nhibernate-mapping.xsd");
					vr.Schemas.Add("urn:nhibernate-mapping-2.2", new System.Xml.XmlTextReader(schema));
					vr.ValidationType = System.Xml.ValidationType.Schema;
					vr.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(XmlValidationHandler);

					_stop = false;
					while(vr.Read() && !_stop) // Read to validate (stop at the first error)
						;
				}
				catch(System.Exception ex)
				{
					Error.Append(ex.ToString()).Append(System.Environment.NewLine + System.Environment.NewLine);
				}
			}
			else
				writer.Flush();

			return writer;
		}
		#endregion


		#region XmlValidationHandler(), WriteHibernateMapping(), IsSubclass() and MapSubclasses()
		private void XmlValidationHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
		{
			Error.Append( "Validation error: Severity=" + e.Severity ).Append(System.Environment.NewLine)
				.Append( "Message: " + e.Message )
				.Append(System.Environment.NewLine + System.Environment.NewLine);
			_stop = true;
		}


		private void WriteHibernateMapping(System.Xml.XmlTextWriter writer, System.Type type)
		{
			writer.WriteStartElement( "hibernate-mapping", "urn:nhibernate-mapping-2.2" );

			if(type != null)
			{
				HibernateMappingAttribute attribute = null;
				object[] attributes = type.GetCustomAttributes(typeof(HibernateMappingAttribute), true);
				if(attributes.Length > 0)
				{
					// If the Type has a HibernateMappingAttribute, then we use it
					attribute = attributes[0] as HibernateMappingAttribute;

					// Attribute: <schema>
					if(attribute.Schema != null)
						writer.WriteAttributeString("schema", attribute.Schema);
					// Attribute: <default-cascade>
					if(attribute.DefaultCascade != null)
						writer.WriteAttributeString("default-cascade", attribute.DefaultCascade);
					// Attribute: <default-access>
					if(attribute.DefaultAccess != null)
						writer.WriteAttributeString("default-access", attribute.DefaultAccess);
					// Attribute: <auto-import>
					if(attribute.AutoImportSpecified)
						writer.WriteAttributeString("auto-import", attribute.AutoImport ? "true" : "false");
					// Attribute: <namespace>
					if(attribute.Namespace != null)
						writer.WriteAttributeString("namespace", attribute.Namespace);
					// Attribute: <assembly>
					if(attribute.Assembly != null)
						writer.WriteAttributeString("assembly", attribute.Assembly);
					// Attribute: <default-lazy>
					if(attribute.DefaultLazySpecified)
						writer.WriteAttributeString("default-lazy", attribute.DefaultLazy ? "true" : "false");

					return;
				}
			}

			// Set <hibernate-mapping> attributes using specified properties
			// Attribute: <schema>
			if(_schemaIsSpecified)
				writer.WriteAttributeString("schema", _schema);
			// Attribute: <default-cascade>
			if(_defaultcascadeIsSpecified)
				writer.WriteAttributeString("default-cascade", _defaultcascade);
			// Attribute: <default-access>
			if(_defaultaccessIsSpecified)
				writer.WriteAttributeString("default-access", _defaultaccess);
			// Attribute: <auto-import>
			if(_autoimportIsSpecified)
				writer.WriteAttributeString("auto-import", _autoimport ? "true" : "false");
			// Attribute: <namespace>
			if(_namespaceIsSpecified)
				writer.WriteAttributeString("namespace", _namespace);
			// Attribute: <assembly>
			if(_assemblyIsSpecified)
				writer.WriteAttributeString("assembly", _assembly);
			// Attribute: <default-lazy>
			if(_defaultlazyIsSpecified)
				writer.WriteAttributeString("default-lazy", _defaultlazy ? "true" : "false");
		}




		private bool IsClass(System.Type type)
		{
			return type.IsDefined(typeof(ClassAttribute), false);
		}

		private bool IsSubclass(System.Type type, System.Type attribute)
		{
			return type.IsDefined(attribute, false);
		}

		private bool IsSubclass(System.Type type)
		{
			return IsSubclass(type, typeof(SubclassAttribute))
				|| IsSubclass(type, typeof(JoinedSubclassAttribute))
				|| IsSubclass(type, typeof(UnionSubclassAttribute));
		}

		private bool AreSameSubclass(System.Type type1, System.Type type2)
		{
			return (IsSubclass(type1, typeof(SubclassAttribute)) && IsSubclass(type2, typeof(SubclassAttribute)))
				|| (IsSubclass(type1, typeof(JoinedSubclassAttribute)) && IsSubclass(type2, typeof(JoinedSubclassAttribute)))
				|| (IsSubclass(type1, typeof(UnionSubclassAttribute)) && IsSubclass(type2, typeof(UnionSubclassAttribute)));
		}



		private void MapSubclasses(System.Collections.ArrayList subclasses, System.Collections.Specialized.StringCollection extendedClassesNames, System.Collections.ArrayList mappedClassesNames, System.Xml.XmlTextWriter writer)
		{
			System.Collections.ArrayList mappedSubclassesNames = new System.Collections.ArrayList();
			// Map each subclass after the class it extends
			while(subclasses.Count > 0)
				for(int i=subclasses.Count-1; i>=0; i--)
				{
					System.Type type = subclasses[i] as System.Type;
					string extendedClassName = extendedClassesNames[i];
					if(extendedClassName==null)
						throw new MappingException("You must specify the Extends attribute of the Subclass: " + type.FullName);

					if( ! mappedClassesNames.Contains(extendedClassName)
						&& ! mappedSubclassesNames.Contains(extendedClassName) )
					{
						bool extendedClassFoundButNotMappedYet = false;
						// Make sure that the extended class is mapped (in this assembly)
						foreach(System.Type subclass in subclasses)
						{
							if( subclass.FullName + ", " + subclass.Assembly.GetName().Name
								== extendedClassName )
							{
								if(subclass==type)
									throw new MappingException("The Subclass " + type.FullName + " extends itself.");
								else
								{
									extendedClassFoundButNotMappedYet = true;
									break;
								}
							}
						}
						if (extendedClassFoundButNotMappedYet)
							continue; // Map this one later
						// Else unknown extended class:
						//   Assume it is mapped somewhere else and map this subclass
					}

					if( IsSubclass(type, typeof(SubclassAttribute)) )
						HbmWriter.WriteSubclass(writer, type);
					else if( IsSubclass(type, typeof(JoinedSubclassAttribute)) )
						HbmWriter.WriteJoinedSubclass(writer, type);
					else if( IsSubclass(type, typeof(UnionSubclassAttribute)) )
						HbmWriter.WriteUnionSubclass(writer, type);

					// Note: Do not add to mappedClassesNames because it is for x-subclasses (and a x-subclasses shouldn't extend another x-subclasses)
					mappedSubclassesNames.Add(type.FullName + ", " + type.Assembly.GetName().Name);
					subclasses.RemoveAt(i);
					extendedClassesNames.RemoveAt(i);
				}
		}
		#endregion
	}
}
