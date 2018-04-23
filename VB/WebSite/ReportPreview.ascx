<%@ Control Language="vb" AutoEventWireup="true" CodeFile="ReportPreview.ascx.vb" Inherits="ReportPreview" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web, Version=11.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>

	<div style="width:670px; height:35px">
	<dxxr:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewer="<%#ReportViewer1%>" ShowDefaultButtons="False">
	 <Items>
	   <dxxr:ReportToolbarButton ItemKind="Search" Enabled="false"/>
	 <dxxr:ReportToolbarSeparator />
		<dxxr:ReportToolbarButton ItemKind="PrintReport" ToolTip="Print the report" />
		<dxxr:ReportToolbarButton ItemKind="PrintPage" ToolTip="Print the current page" />
		<dxxr:ReportToolbarSeparator />
		<dxxr:ReportToolbarButton ItemKind="FirstPage" ToolTip="First Page" />
		<dxxr:ReportToolbarButton ItemKind="PreviousPage" ToolTip="Previous Page" />
		<dxxr:ReportToolbarLabel Text="Page" />
		<dxxr:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
		</dxxr:ReportToolbarComboBox>
		<dxxr:ReportToolbarLabel Text="of" />
		<dxxr:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
		<dxxr:ReportToolbarButton ItemKind="NextPage" ToolTip="Next Page" />
		<dxxr:ReportToolbarButton ItemKind="LastPage" ToolTip="Last Page" />
		<dxxr:ReportToolbarSeparator />
		<dxxr:ReportToolbarButton ItemKind="SaveToDisk" ToolTip="Export a report and save it to the disk" />
		<dxxr:ReportToolbarButton ItemKind="SaveToWindow" ToolTip="Export a report and show it in a new window" />
		<dxxr:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
			<Elements>
				<dxxr:ListElement Text="Pdf" Value="pdf" />
				<dxxr:ListElement Text="Mht" Value="mht" />
				<dxxr:ListElement Text="Image" Value="png" />
			</Elements>
		</dxxr:ReportToolbarComboBox>
	</Items>
	<Styles>
		<LabelStyle>
			<Margins MarginLeft="3px" MarginRight="3px" />
		</LabelStyle>
	</Styles>
</dxxr:ReportToolbar>
</div>
<div style="width:670px; height:500px; overflow:auto;">
<dxxr:ReportViewer ID="ReportViewer1" runat="server" ClientInstanceName="ClientReportViewer">
<ClientSideEvents PageLoad= "function(s, e) {
   scheduler.HideLoadingPanel();
   ASPxPopupControl1.Show();
}" /> 
</dxxr:ReportViewer>
</div>