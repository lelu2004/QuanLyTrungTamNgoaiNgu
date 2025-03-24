using System.Linq;
using System.Web.Mvc;
using QuanLyTrungTamNN.Models;

namespace QuanLyTrungTamNN.Controllers
{
    public class DashboardController : Controller
    {
        private TrungTamNgoaiNguEntities db = new TrungTamNgoaiNguEntities();

        public ActionResult Index()
        {
            var totalStudents = db.STUDENTs.Count();
            var totalTeachers = db.TEACHERs.Count();
            var totalClasses = db.CLASSes.Count();

            ViewBag.TotalStudents = totalStudents;
            ViewBag.TotalTeachers = totalTeachers;
            ViewBag.TotalClasses = totalClasses;

            return View();
        }
    }
}
