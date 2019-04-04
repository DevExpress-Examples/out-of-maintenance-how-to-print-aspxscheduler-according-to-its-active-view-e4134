<!-- default file list -->
*Files to look at*:

* [CustomEvents.cs](./CS/WebSite/App_Code/CustomEvents.cs) (VB: [CustomEvents.vb](./VB/WebSite/App_Code/CustomEvents.vb))
* [CustomResources.cs](./CS/WebSite/App_Code/CustomResources.cs) (VB: [CustomResources.vb](./VB/WebSite/App_Code/CustomResources.vb))
* [DataHelper.cs](./CS/WebSite/App_Code/DataHelper.cs) (VB: [DataHelper.vb](./VB/WebSite/App_Code/DataHelper.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [DefaultObjectDataSources.ascx](./CS/WebSite/DefaultObjectDataSources.ascx) (VB: [DefaultObjectDataSources.ascx](./VB/WebSite/DefaultObjectDataSources.ascx))
* [DefaultObjectDataSources.ascx.cs](./CS/WebSite/DefaultObjectDataSources.ascx.cs) (VB: [DefaultObjectDataSources.ascx.vb](./VB/WebSite/DefaultObjectDataSources.ascx.vb))
* [ReportPreview.ascx](./CS/WebSite/ReportPreview.ascx) (VB: [ReportPreview.ascx](./VB/WebSite/ReportPreview.ascx))
* [ReportPreview.ascx.cs](./CS/WebSite/ReportPreview.ascx.cs) (VB: [ReportPreview.ascx.vb](./VB/WebSite/ReportPreview.ascx.vb))
<!-- default file list end -->
# How to print ASPxScheduler according to its active view


<p>This example illustrates how to print the ASPxScheduler according to its active view based on the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument6458"><u>Printing via Reports</u></a> technique. For each view, a predefined reporting template is used. Similar templates are shipped along with the ASPxScheduler demo project. These templates are located in the ...\DevExpress 2011.1 Demos\Components\Data\SchedulerReportTemplates folder by default. The active template for printing is selected in the <strong>GetReportNameBySelectedViewType()</strong> method (see Default.aspx.cs code-behind file) based on the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerASPxScheduler_ActiveViewTypetopic"><u>ASPxScheduler.ActiveViewType Property</u></a> value.</p>

<br/>


