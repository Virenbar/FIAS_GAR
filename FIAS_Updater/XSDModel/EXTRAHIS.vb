﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Этот код создан программой.
'     Исполняемая версия:4.0.30319.42000
'
'     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
'     повторной генерации кода.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

'
'Этот исходный код был создан с помощью xsd, версия=4.7.3081.0.
'

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.v8.1c.ru/ssl/AddressSystem"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.v8.1c.ru/ssl/AddressSystem", IsNullable:=False)>
Partial Public Class AdditionalAddressInfo

	Private additionalAddressInfo1Field() As AdditionalAddressInfo

	Private rEGIONCODEField As String

	Private eXTRAGUIDField As String

	Private oKATOField As String

	Private oKTMOField As String

	Private iFNSFLField As String

	Private iFNSULField As String

	Private tERRIFNSFLField As String

	Private tERRIFNSULField As String

	Private pOSTALCODEField As String

	Private versionField As String

	Private updateDateField As String

	Private regionField As String

	'''<remarks/>
	<System.Xml.Serialization.XmlElementAttribute("AdditionalAddressInfo")>
	Public Property AdditionalAddressInfo1() As AdditionalAddressInfo()
		Get
			Return Me.additionalAddressInfo1Field
		End Get
		Set
			Me.additionalAddressInfo1Field = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property REGIONCODE() As String
		Get
			Return Me.rEGIONCODEField
		End Get
		Set
			Me.rEGIONCODEField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property EXTRAGUID() As String
		Get
			Return Me.eXTRAGUIDField
		End Get
		Set
			Me.eXTRAGUIDField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property OKATO() As String
		Get
			Return Me.oKATOField
		End Get
		Set
			Me.oKATOField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property OKTMO() As String
		Get
			Return Me.oKTMOField
		End Get
		Set
			Me.oKTMOField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property IFNSFL() As String
		Get
			Return Me.iFNSFLField
		End Get
		Set
			Me.iFNSFLField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property IFNSUL() As String
		Get
			Return Me.iFNSULField
		End Get
		Set
			Me.iFNSULField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property TERRIFNSFL() As String
		Get
			Return Me.tERRIFNSFLField
		End Get
		Set
			Me.tERRIFNSFLField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property TERRIFNSUL() As String
		Get
			Return Me.tERRIFNSULField
		End Get
		Set
			Me.tERRIFNSULField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property POSTALCODE() As String
		Get
			Return Me.pOSTALCODEField
		End Get
		Set
			Me.pOSTALCODEField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property Version() As String
		Get
			Return Me.versionField
		End Get
		Set
			Me.versionField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property UpdateDate() As String
		Get
			Return Me.updateDateField
		End Get
		Set
			Me.updateDateField = value
		End Set
	End Property

	'''<remarks/>
	<System.Xml.Serialization.XmlAttributeAttribute()>
	Public Property Region() As String
		Get
			Return Me.regionField
		End Get
		Set
			Me.regionField = value
		End Set
	End Property
End Class
