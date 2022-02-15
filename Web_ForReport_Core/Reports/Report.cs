
using Microsoft.Reporting.NETCore;
using System.Reflection; 
namespace ReportViewerCore
{
	class Report
	{
        public static void Load(LocalReport report, decimal widgetPrice, decimal gizmoPrice)
        {
            var items = new[] { new ReportItem { Description = "Widget 6000", Price = widgetPrice, Qty = 1 }, new ReportItem { Description = "Gizmo MAX", Price = gizmoPrice, Qty = 25 } };

            
            //or from the entry point to the application - there is a difference!
            var test = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            var parameters = new[] { new ReportParameter("Title", "Invoice 4/2020") };
              //var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("ReportViewerCore.Sample.AspNetCore.Reports.Report.rdlc");
              var rs = Assembly.
                GetExecutingAssembly().
                GetManifestResourceStream("ReportViewerCore.Sample.AspNetCore.Reports.Report.rdlc");
            report.LoadReportDefinition(rs);
            report.DataSources.Add(new ReportDataSource("Items", items));
            report.SetParameters(parameters);
            //Web_ForReport_Core\Web_ForReport_Core\Reports\Report.rdlc
        }
    }
}
