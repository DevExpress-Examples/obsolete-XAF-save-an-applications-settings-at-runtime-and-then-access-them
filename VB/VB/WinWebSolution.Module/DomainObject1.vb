Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinWebSolution.Module
	<DefaultClassOptions> _
	Public Class DomainObject1
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public ReadOnly Property StringProperty() As String
			Get
				Return GlobalOptions.Instance.MyStringProperty
			End Get
		End Property
		Public ReadOnly Property IntProperty() As Integer
			Get
				Return GlobalOptions.Instance.MyIntProperty
			End Get
		End Property
	End Class
End Namespace
