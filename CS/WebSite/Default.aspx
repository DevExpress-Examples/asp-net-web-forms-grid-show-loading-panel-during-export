﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to show ASPxLoadingPanel during export</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridViewExporter ID="gridExporter" runat="server">
            </dx:ASPxGridViewExporter>
            <dx:ASPxGridView ID="grid" runat="server" EnableCallbackAnimation="true">
            </dx:ASPxGridView>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <script type="text/javascript">
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_initializeRequest(prm_InitializeRequest);
                prm.add_endRequest(prm_EndRequest);
                function prm_InitializeRequest(sender, args) {
                    panel.Show();
                }
                function prm_EndRequest(sender, args) {
                    panel.Hide();
                    btn.DoClick();
                }
            </script>
            <dx:ASPxButton ID="btn" runat="server" ClientInstanceName="btn" ClientVisible="false"
                OnClick="btn_Click" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <dx:ASPxButton ID="bnExportPDF" runat="server" Text="export to PDF" OnClick="bnExport_Click">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="bnExportXLS" runat="server" Text="export to XLS" OnClick="bnExport_Click">
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="bnExportRRF" runat="server" Text="export to RTF" OnClick="bnExport_Click">
                    </dx:ASPxButton>
                </ContentTemplate>
            </asp:UpdatePanel>
            <dx:ASPxLoadingPanel ID="panel" ClientInstanceName="panel" runat="server" Modal="true">
            </dx:ASPxLoadingPanel>
        </div>
    </form>
</body>
</html>
