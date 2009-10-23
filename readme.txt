======================================
What is NHibernate.Mapping.Attributes?
======================================

NHibernate requires mapping information to bind your domain model to your database. Usually, it is written (and maintained) in separated hbm.xml files.

With NHibernate.Mapping.Attributes, you can use .NET attributes to decorate your entities and these attributes will be used to generate the mapping information. So you will no longer have to bother with these nasty XML files ;).

Licensed under the terms of the GNU Lesser General Public License.



========================
Build for NHibernate 3.0
========================

Important breaking change: When using the [*Class] attributes, the property Name is automatically deduced only if Name and EntityName are both null.
This is due to the fact that this property is optional since you can use EntityName instead.
You can turn of this behavior by doing:
((HbmWriterEx) HbmSerializer.Default.HbmWriter).DoNotAutoDetectClassName = true;



==================
Online information
==================

Website:
http://nhforge.org/
http://sourceforge.net/projects/nhcontrib/

Documentation:
http://www.hibernate.org/hib_docs/nhibernate/html/mapping-attributes.html

Community Group (to ask questions):
http://groups.google.com/group/nhcdevs

Up-to-date source code available in the SVN:
http://nhcontrib.svn.sourceforge.net/svnroot/nhcontrib/trunk/src/NHibernate.Mapping.Attributes/
