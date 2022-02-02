using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;

namespace Solution
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            MyGrid.DataSource = GetDataTable();
            MyGrid.DataBind();
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NumberID", Type.GetType("System.Int32"));
            for (int i = 0; i < 10; i++)
            {
                dt.Columns.Add("Number" + i, Type.GetType("System.Int32"));
            }
            dt.PrimaryKey = new DataColumn[] { dt.Columns["NumberID"] };
            for (int i = 0; i < 5000; i++)
            {
                dt.Rows.Add(i, i, i, i, i, i, i, i, i, i, i);
            }
            return dt;
        }

        protected void ExportCallback_Callback(object source, CallbackEventArgs e)
        {
            PrintingSystemBase ps = new PrintingSystemBase();
            PrintableComponentLinkBase lnk = new PrintableComponentLinkBase(ps);
            lnk.Component = MyGridExporter;

            CompositeLinkBase compositeLink = new CompositeLinkBase(ps);
            compositeLink.Links.AddRange(new object[] { lnk });
            compositeLink.CreateDocument();

            MemoryStream stream = new MemoryStream();
            string type = e.Parameter.ToString();

            switch (type)
            {
                case "pdf":
                    compositeLink.PrintingSystemBase.ExportToPdf(stream);
                    break;
                case "xls":
                    compositeLink.PrintingSystemBase.ExportToXls(stream);
                    break;
                case "rtf":
                    compositeLink.PrintingSystemBase.ExportToRtf(stream);
                    break;
            }

            Session["ExportStream"] = stream;
            Session["type"] = type;
        }


        protected void response_btn_Click(object sender, EventArgs e)
        {
            MemoryStream stream = Session["ExportStream"] as MemoryStream;
            string type = Session["type"].ToString();
            WriteToResponse(MyGrid.ID, true, type, stream);
        }
        protected void WriteToResponse(string fileName, bool saveAsFile, string fileFormat, MemoryStream stream)
        {
            if (Page == null || Page.Response == null) return;
            string disposition = saveAsFile ? "attachment" : "inline";
            Page.Response.Clear();
            Page.Response.Buffer = false;
            Page.Response.AppendHeader("Content-Type", string.Format("application/{0}", fileFormat));
            Page.Response.AppendHeader("Content-Transfer-Encoding", "binary");
            Page.Response.AppendHeader("Content-Disposition", string.Format("{0}; filename={1}.{2}", disposition, HttpUtility.UrlEncode(fileName).Replace("+", "%20"), fileFormat));
            Page.Response.BinaryWrite(stream.ToArray());
            Page.Response.End();
        }
    }
}