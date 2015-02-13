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
You can turn off this behavior by doing:
((HbmWriterEx) HbmSerializer.Default.HbmWriter).DoNotAutoDetectClassName = true;

==================
Online information
==================

Website
-------
* http://nhibernate.info/
* https://github.com/nhibernate/NHibernate.Mapping.Attributes/

Documentation
-------------
* http://nhibernate.info/doc/nh/en/index.html#mapping-attributes

Community Group (to ask questions)
----------------------------------
* https://groups.google.com/group/nhusers

Up-to-date source code available at GitHub
------------------------------------------

* https://github.com/nhibernate/NHibernate.Mapping.Attributes/
