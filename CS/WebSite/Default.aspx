<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to show ASPxLoadingPanel during export</title>
    <script type="text/javascript">
        function onExportWithCallbackClick(exportType) {
            loadingPanel.Show();
            ExportCallback.PerformCallback(exportType);
        }
        function ExportCallbackComplete(s, e) {
            loadingPanel.Hide();
            response_btn.DoClick();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <dx:ASPxCallback ID="ExportCallback" ClientInstanceName="ExportCallback" runat="server" OnCallback="ExportCallback_Callback">
                <ClientSideEvents CallbackComplete="ExportCallbackComplete" />
            </dx:ASPxCallback>

            <dx:ASPxGridViewExporter ID="MyGridExporter" runat="server">
            </dx:ASPxGridViewExporter>
            <dx:ASPxGridView ID="MyGrid" runat="server" EnableCallbackAnimation="true" AutoGenerateColumns="true">
                <SettingsExport EnableClientSideExportAPI="true"/>
            </dx:ASPxGridView>
            <div style="display: flex; flex-direction: row; justify-content: flex-start">
                <dx:ASPxButton ID="btnExportPDF" runat="server" AutoPostBack="false" Text="Export to PDF">
                    <ClientSideEvents Click="function(s,e){onExportWithCallbackClick('pdf')}" />
                </dx:ASPxButton>
                <dx:ASPxButton ID="btnExportXLS" runat="server" AutoPostBack="false" Text="Export to XLS">
                    <ClientSideEvents Click="function(s,e){onExportWithCallbackClick('xls')}" />
                </dx:ASPxButton>
                <dx:ASPxButton ID="btnExportRTF" runat="server" AutoPostBack="false" Text="Export to RTF">
                    <ClientSideEvents Click="function(s,e){onExportWithCallbackClick('rtf')}" />
                </dx:ASPxButton>
            </div>
            

            <dx:ASPxButton ID="response_btn" runat="server" ClientInstanceName="response_btn" ClientVisible="false"
                OnClick="response_btn_Click" />
            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="loadingPanel"></dx:ASPxLoadingPanel>
        </div>
    </form>
</body>
</html>
