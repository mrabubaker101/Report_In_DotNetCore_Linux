using Microsoft.AspNetCore.Mvc; 
using Microsoft.Reporting.NETCore; 
namespace ReportViewerCore
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    { 
         
        [HttpGet] 
        [Route("{name}")]
        public IActionResult Get(string name)
        { 
            decimal WidgetPrice = 0;
            decimal GizmoPrice = 0;
            using LocalReport report = new LocalReport();
            Report.Load(report, WidgetPrice, GizmoPrice);
            //var BYTE = report.Render("PDF");
            //return File(BYTE,"application/pdf", name+"_.pdf");


            //var BYTE = report.Render("HTML5");
            //return File(BYTE, "text/html", name + "_.html");

            //var BYTE = report.Render("WORDOPENXML");
            //return File(BYTE, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", name + "_.docx");


            var BYTE = report.Render("EXCELOPENXML");
            return File(BYTE, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name + "_.xlsx");

        }
    }
}
