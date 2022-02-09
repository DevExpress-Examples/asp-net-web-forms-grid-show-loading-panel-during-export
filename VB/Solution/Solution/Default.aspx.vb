Imports DevExpress.Web
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports System
Imports System.Data
Imports System.IO
Imports System.Web
Imports System.Web.UI
Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        MyGrid.DataSource = GetDataTable()
        MyGrid.DataBind()
    End Sub

    Private Function GetDataTable() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("NumberID", Type.[GetType]("System.Int32"))

        For i As Integer = 0 To 10 - 1
            dt.Columns.Add("Number" & i, Type.[GetType]("System.Int32"))
        Next

        dt.PrimaryKey = New DataColumn() {dt.Columns("NumberID")}

        For i As Integer = 0 To 5000 - 1
            dt.Rows.Add(i, i, i, i, i, i, i, i, i, i, i)
        Next

        Return dt
    End Function
    Protected Sub ExportCallback_Callback(ByVal source As Object, ByVal e As CallbackEventArgs)
        Dim ps As PrintingSystemBase = New PrintingSystemBase()
        Dim lnk As PrintableComponentLinkBase = New PrintableComponentLinkBase(ps)
        lnk.Component = MyGridExporter
        Dim compositeLink As CompositeLinkBase = New CompositeLinkBase(ps)
        compositeLink.Links.AddRange(New Object() {lnk})
        compositeLink.CreateDocument()
        Dim stream As MemoryStream = New MemoryStream()
        Dim type As String = e.Parameter.ToString()

        Select Case type
            Case "pdf"
                compositeLink.PrintingSystemBase.ExportToPdf(stream)
            Case "xls"
                compositeLink.PrintingSystemBase.ExportToXls(stream)
            Case "rtf"
                compositeLink.PrintingSystemBase.ExportToRtf(stream)
        End Select

        Session("ExportStream") = stream
        Session("type") = type
    End Sub
    Protected Sub response_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim stream As MemoryStream = TryCast(Session("ExportStream"), MemoryStream)
        Dim type As String = Session("type").ToString()
        WriteToResponse(MyGrid.ID, True, type, stream)
    End Sub

    Protected Sub WriteToResponse(ByVal fileName As String, ByVal saveAsFile As Boolean, ByVal fileFormat As String, ByVal stream As MemoryStream)
        If Page Is Nothing OrElse Page.Response Is Nothing Then Return
        Dim disposition As String = If(saveAsFile, "attachment", "inline")
        Page.Response.Clear()
        Page.Response.Buffer = False
        Page.Response.AppendHeader("Content-Type", String.Format("application/{0}", fileFormat))
        Page.Response.AppendHeader("Content-Transfer-Encoding", "binary")
        Page.Response.AppendHeader("Content-Disposition", String.Format("{0}; filename={1}.{2}", disposition, HttpUtility.UrlEncode(fileName).Replace("+", "%20"), fileFormat))
        Page.Response.BinaryWrite(stream.ToArray())
        Page.Response.[End]()
    End Sub
End Class