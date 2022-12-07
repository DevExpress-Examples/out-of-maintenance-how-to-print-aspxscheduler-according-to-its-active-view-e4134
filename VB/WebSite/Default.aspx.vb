Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web
Imports DevExpress.XtraScheduler

Partial Public Class [Default]
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		DataHelper.SetupMappings(ASPxScheduler1)
		DataHelper.ProvideRowInsertion(ASPxScheduler1, DataSource1.AppointmentDataSource)
		DataSource1.AttachTo(ASPxScheduler1)

		PrepareReportPreview(PreviewPanel)

		If (Not IsPostBack) Then
			ASPxScheduler1.Start = DateTime.Today
		End If
	End Sub

	Private Sub PrepareReportPreview(ByVal cp As Control)
		Dim reportPreview As ReportPreview = CType(Page.LoadControl("ReportPreview.ascx"), ReportPreview)
		reportPreview.ControlAdapter = ASPxSchedulerControlPrintAdapter1

		reportPreview.ReportTemplateFileName = "SchedulerReportTemplates\" & GetReportNameBySelectedViewType()

		cp.Controls.Clear()
		cp.Controls.Add(reportPreview)
	End Sub

	Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As DevExpress.Web.CallbackEventArgsBase)
		PreviewPanel.Visible = True
	End Sub

	Private Function GetReportNameBySelectedViewType() As String
		Select Case ASPxScheduler1.ActiveViewType
			Case SchedulerViewType.Day
				Return "DailyStyleFitToPage.schrepx"
			Case SchedulerViewType.WorkWeek
				Return "WorkWeekStyleFitToPage.schrepx"
			Case SchedulerViewType.Week
				Return "WeeklyStyle.schrepx"
			Case SchedulerViewType.Month
				Return "MonthlyStyle.schrepx"
			Case SchedulerViewType.Timeline
				Return "TimelineStyle.schrepx"
			Case Else
				Return "DailyStyleFitToPage.schrepx"
		End Select
	End Function
End Class