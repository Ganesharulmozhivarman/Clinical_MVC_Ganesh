using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinical_MVC_Ganesh.Models;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using System.Text;
using System.Drawing;

namespace Clinical_MVC_Ganesh.Controllers
{
    public class DoctorRevenueController : Controller
    {
        ClinicMVCDbEntities db = new ClinicMVCDbEntities();
        // GET: DoctorRevenue
        public ActionResult DoctorRevenue()
        {
            var data = db.Revenue_from_Doctor().ToList();
            var chart = new Chart();
            var area = new ChartArea();
            chart.ChartAreas.Add(area);
            var series = new Series();
            foreach (var item in data)
            {
                series.Points.AddXY(item.Date, item.Cost);
            }
            //series.Label = "#PERCENT{P0}";
            series.Font = new Font("Arial", 8.0f, FontStyle.Bold);
            series.ChartType = SeriesChartType.Column;
            series["PieLabelStyle"] = "Outside";
            chart.Series.Add(series);
            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return new FileStreamResult(returnStream, "image/png");

            
        }
    }
}