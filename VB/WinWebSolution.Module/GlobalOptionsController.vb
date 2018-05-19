Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Actions

Namespace WinWebSolution.Module
	Public Class GlobalOptionsController
		Inherits Controller
		Private changeOptions As SimpleAction = Nothing
		Public Sub New()
			MyBase.New()
			changeOptions = New SimpleAction(Me, "ChangeOptions", PredefinedCategory.Tools)
			AddHandler changeOptions.Execute, AddressOf changeOptions_Execute
			changeOptions.ImageName = "Attention"
		End Sub
		Private Sub changeOptions_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
			OnChangeOptionsExecute(e)
		End Sub
		Protected Overridable Sub OnChangeOptionsExecute(ByVal e As SimpleActionExecuteEventArgs)
			Dim dv As DetailView = Application.CreateDetailView(ObjectSpaceInMemory.CreateNew(), GlobalOptions.Instance)
			dv.ViewEditMode = ViewEditMode.Edit
			e.ShowViewParameters.CreatedView = dv
			e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow
		End Sub
	End Class
	<NonPersistent> _
	Public Class GlobalOptions
		Private Sub New()
			myIntVar = 100
			myStringVar = "A string option"
		End Sub
		Private Shared instanceManager As IValueManager(Of GlobalOptions)
		Public Shared ReadOnly Property Instance() As GlobalOptions
			Get
				If instanceManager Is Nothing Then
					instanceManager = ValueManager.GetValueManager(Of GlobalOptions)("GlobalOptions_GlobalOptions")
				End If
				If instanceManager.Value Is Nothing Then
					instanceManager.Value = New GlobalOptions()
				End If
				Return instanceManager.Value
			End Get
		End Property
		Private myIntVar As Integer
		Public Property MyIntProperty() As Integer
			Get
				Return myIntVar
			End Get
			Set(ByVal value As Integer)
				myIntVar = value
			End Set
		End Property
		Private myStringVar As String
		Public Property MyStringProperty() As String
			Get
				Return myStringVar
			End Get
			Set(ByVal value As String)
				myStringVar = value
			End Set
		End Property
	End Class
End Namespace