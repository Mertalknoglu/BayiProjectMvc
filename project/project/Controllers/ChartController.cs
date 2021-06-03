using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;


using System.Web.Mvc;


namespace project.Controllers
{
    public class ChartController : Controller
    {
        prEntities db = new prEntities();
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualProductResult() 
        {

            return Json(Prolist());
        }
        public List<MusteriChart> Prolist()
        {
            List<MusteriChart> cs = new List<MusteriChart>();
            cs = db.Siparis.GroupBy(s => s.Musteri.Adi)
                .Select(b=> new MusteriChart
                {
                    MusteriAdi = b.Key,
                    SiparisTutari = b.Sum(s=> s.SiparisTutar),
                }).ToList();
            return cs;
        }
    }

   
}