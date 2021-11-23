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
            var BYTE = report.Render("PDF");
            return File(BYTE,"application/pdf", name+"_.pdf");
        }
    }
}
