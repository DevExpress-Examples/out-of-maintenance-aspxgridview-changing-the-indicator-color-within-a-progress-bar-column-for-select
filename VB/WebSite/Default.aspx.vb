Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		'Create the grid's data source on the first load
		If (Not IsPostBack) AndAlso (Not IsCallback) Then
			Session("GridDataSource") = CreateDataSource()
		End If

		'Populate the grid with data on each page load
		If Session("GridDataSource") IsNot Nothing Then
			ASPxGridView1.DataSource = TryCast(Session("GridDataSource"), DataTable)
			ASPxGridView1.DataBind()
		End If

	End Sub

	Private Function CreateDataSource() As DataTable
		Dim dataTable As New DataTable("Tasks")
		dataTable.Columns.Add("ID", GetType(Integer))
		dataTable.Columns.Add("Name", GetType(String))
		dataTable.Columns.Add("Complete", GetType(Integer))
		dataTable.PrimaryKey = New DataColumn() { dataTable.Columns("ID") }
		Dim r As New Random()
		For i As Integer = 0 To 14
			dataTable.Rows.Add(New Object() { i, "Task " & i.ToString(), r.Next(0, 100) })
		Next i
		Return dataTable
	End Function

	Protected Sub ASPxProgressBar1_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim progressBar As ASPxProgressBar = CType(sender, ASPxProgressBar)
		Dim container As GridViewDataItemTemplateContainer = CType(progressBar.Parent, GridViewDataItemTemplateContainer)
		If ASPxGridView1.Selection.IsRowSelectedByKey(container.KeyValue) Then
			progressBar.IndicatorStyle.BackColor = System.Drawing.Color.Red
		End If
	End Sub
End Class
