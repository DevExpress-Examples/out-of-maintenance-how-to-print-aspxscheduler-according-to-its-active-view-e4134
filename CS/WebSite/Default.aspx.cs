using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxMenu;
using DevExpress.XtraScheduler;

public partial class Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        DataHelper.SetupMappings(ASPxScheduler1);
        DataHelper.ProvideRowInsertion(ASPxScheduler1, DataSource1.AppointmentDataSource);
        DataSource1.AttachTo(ASPxScheduler1);

        PrepareReportPreview(PreviewPanel);

        if (!IsPostBack) {
            ASPxScheduler1.Start = DateTime.Today;
        }
    }

    void PrepareReportPreview(Control cp) {
        ReportPreview reportPreview = (ReportPreview)Page.LoadControl("ReportPreview.ascx");
        reportPreview.ControlAdapter = ASPxSchedulerControlPrintAdapter1;

        reportPreview.ReportTemplateFileName = "SchedulerReportTemplates\\" + GetReportNameBySelectedViewType();

        cp.Controls.Clear();
        cp.Controls.Add(reportPreview);
    }

    protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e) {
        PreviewPanel.Visible = true;
    }

    private string GetReportNameBySelectedViewType() {
        switch (ASPxScheduler1.ActiveViewType) {
            case SchedulerViewType.Day:
                return "DailyStyleFitToPage.schrepx";
            case SchedulerViewType.WorkWeek:
                return "WorkWeekStyleFitToPage.schrepx";
            case SchedulerViewType.Week:
                return "WeeklyStyle.schrepx";
            case SchedulerViewType.Month:
                return "MonthlyStyle.schrepx";
            case SchedulerViewType.Timeline:
                return "TimelineStyle.schrepx";
            default:
                return "DailyStyleFitToPage.schrepx";
        }
    }
}