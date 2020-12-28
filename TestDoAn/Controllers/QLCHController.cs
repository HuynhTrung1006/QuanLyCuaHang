using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDoAn.Models;

namespace TestDoAn.Controllers
{
    public class QLCHController : Controller
    {

	//QUAN LI HOA DON
        private Models.QuanLyCuaHangEntites db = new Models.QuanLyCuaHangEntites();
        // GET: Qlch
        public ActionResult Index()
        {
            return View();
        }
		

        public ActionResult IndexHD()
        {
			ViewBag.dscthd = db.ChiTietHoaDons.ToList();
            return View(db.HoaDons.ToList());
        }
        public ActionResult FormCTHD(int id)
        {
			double tong = 0;
				List<Models.ChiTietHoaDon> ds = new List<ChiTietHoaDon>();
				foreach (var a in db.ChiTietHoaDons.Where(x => x.mahd.Equals(id)))
				{
					tong += (double)(a.soluong * a.dongia);
					ds.Add(a);
				}
			ViewBag.thanhtien = tong;

				return View(ds);

        }

		public ActionResult Search(string id)
		{
			int a = int.Parse(id);
			HoaDon hd = db.HoaDons.Find(a);
			if (hd != null)
				return PartialView(hd);
			return Content("Không Tìm Thấy");
		}
		
		
		
	}
}