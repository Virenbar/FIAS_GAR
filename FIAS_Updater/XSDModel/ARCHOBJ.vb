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
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.v8.1c.ru/ssl/AddressSystem"),  _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.v8.1c.ru/ssl/AddressSystem", IsNullable:=false)>  _
Partial Public Class ArchiveObjects
    
    Private archiveObjectField() As ArchiveObjectsArchiveObject
    
    Private versionField As String
    
    Private updateDateField As String
    
    Private regionField As String
    
    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("ArchiveObject")>  _
    Public Property ArchiveObject() As ArchiveObjectsArchiveObject()
        Get
            Return Me.archiveObjectField
        End Get
        Set
            Me.archiveObjectField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property Version() As String
        Get
            Return Me.versionField
        End Get
        Set
            Me.versionField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property UpdateDate() As String
        Get
            Return Me.updateDateField
        End Get
        Set
            Me.updateDateField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property Region() As String
        Get
            Return Me.regionField
        End Get
        Set
            Me.regionField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www.v8.1c.ru/ssl/AddressSystem")>  _
Partial Public Class ArchiveObjectsArchiveObject
    
    Private aOIDField As String
    
    Private aOGUIDField As String
    
    Private pARENTGUIDField As String
    
    Private pARENTGUIDMUNField As String
    
    Private eXTRAGUIDField As String
    
    Private aOLEVELField As String
    
    Private cODEField As String
    
    Private fORMALNAMEField As String
    
    Private sHORTNAMEField As String
    
    Private sTARTDATEField As String
    
    Private eNDDATEField As String
    
    Private oPERSTATUSField As String
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property AOID() As String
        Get
            Return Me.aOIDField
        End Get
        Set
            Me.aOIDField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property AOGUID() As String
        Get
            Return Me.aOGUIDField
        End Get
        Set
            Me.aOGUIDField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property PARENTGUID() As String
        Get
            Return Me.pARENTGUIDField
        End Get
        Set
            Me.pARENTGUIDField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property PARENTGUIDMUN() As String
        Get
            Return Me.pARENTGUIDMUNField
        End Get
        Set
            Me.pARENTGUIDMUNField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property EXTRAGUID() As String
        Get
            Return Me.eXTRAGUIDField
        End Get
        Set
            Me.eXTRAGUIDField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property AOLEVEL() As String
        Get
            Return Me.aOLEVELField
        End Get
        Set
            Me.aOLEVELField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property CODE() As String
        Get
            Return Me.cODEField
        End Get
        Set
            Me.cODEField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property FORMALNAME() As String
        Get
            Return Me.fORMALNAMEField
        End Get
        Set
            Me.fORMALNAMEField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property SHORTNAME() As String
        Get
            Return Me.sHORTNAMEField
        End Get
        Set
            Me.sHORTNAMEField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property STARTDATE() As String
        Get
            Return Me.sTARTDATEField
        End Get
        Set
            Me.sTARTDATEField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property ENDDATE() As String
        Get
            Return Me.eNDDATEField
        End Get
        Set
            Me.eNDDATEField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>  _
    Public Property OPERSTATUS() As String
        Get
            Return Me.oPERSTATUSField
        End Get
        Set
            Me.oPERSTATUSField = value
        End Set
    End Property
End Class

