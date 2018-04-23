Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraScheduler.Reporting
Imports DevExpress.Web.ASPxScheduler.Reporting

Partial Public Class ReportPreview
	Inherits System.Web.UI.UserControl
	Private reportTemplateFileName_Renamed As String
	Private controlAdapter_Renamed As ASPxSchedulerControlPrintAdapter

	Public Property ReportTemplateFileName() As String
		Get
			Return reportTemplateFileName_Renamed
		End Get
		Set(ByVal value As String)
			reportTemplateFileName_Renamed = value
		End Set
	End Property

	Public Property ControlAdapter() As ASPxSchedulerControlPrintAdapter
		Get
			Return controlAdapter_Renamed
		End Get
		Set(ByVal value As ASPxSchedulerControlPrintAdapter)
			controlAdapter_Renamed = value
		End Set
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim rpt As New XtraSchedulerReport()
		rpt.LoadLayout(Page.MapPath("~/App_Data/" & ReportTemplateFileName))
		rpt.SchedulerAdapter = ControlAdapter.SchedulerAdapter
		ReportViewer1.Report = rpt
	End Sub
End Class