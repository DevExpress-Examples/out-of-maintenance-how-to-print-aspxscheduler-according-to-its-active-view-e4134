<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxScheduler.Reporting" TagPrefix="dxwschsc" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v13.1.Core, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>

<%@ Register Src="~/DefaultObjectDataSources.ascx" TagName="DefaultObjectDataSources" TagPrefix="dds" %>
<%@ Register Src ="~/ReportPreview.ascx" TagName="ReportPreview" TagPrefix="rp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <form id="form1" runat="server">
    <div>
    
        <dds:DefaultObjectDataSources runat="server" ID="DataSource1" />

        <dxwschsc:ASPxSchedulerControlPrintAdapter ID="ASPxSchedulerControlPrintAdapter1" runat="server" SchedulerControlID="ASPxScheduler1" />
        
        <dxe:ASPxButton ID="btnPreview" runat="server" Text="Show Preview" AutoPostBack="False" UseSubmitBehavior="False" ClientInstanceName="btnShowPreview" EnableClientSideAPI="True">
             <clientsideevents click="function(s, e) {
	        if (_aspxIsExists(window.ClientReportViewer)) {
	            scheduler.ShowLoadingPanel();
	            window.ClientReportViewer.Refresh();
	        }
	        else {
	            ASPxPopupControl1.Show();
	            ASPxCallbackPanel1.PerformCallback();
	        }
        }" />
        </dxe:ASPxButton>
        
        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" ClientInstanceName="scheduler" Width="600px" />
        
        <dxpc:ASPxPopupControl ID="ASPxPopupControl1" runat="server" Modal="True" ClientInstanceName="ASPxPopupControl1" 
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="680px" Height="600px"
            HeaderText="Print Preview" AllowDragging="true" BackColor="LightGray">
            <ContentCollection>
                <dxpc:PopupControlContentControl runat="server">
                    <dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="ASPxCallbackPanel1" ID="ASPxCallbackPanel1" OnCallback="ASPxCallbackPanel1_Callback">
                        <PanelCollection>
                            <dxp:PanelContent runat="server">
                                <asp:Panel runat="server" ID="PreviewPanel" Visible="False"/>
                            </dxp:PanelContent>
                        </PanelCollection>
                    </dxcp:ASPxCallbackPanel>
                </dxpc:PopupControlContentControl>
            </ContentCollection>
        </dxpc:ASPxPopupControl>
        
    </div>
    </form>
</body>
</html>
