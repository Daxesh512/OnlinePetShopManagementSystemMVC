using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlinePetShopManagementSystemMVC.Models;
using System.Data;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace OnlinePetShopManagementSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Features()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Registartion()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registartion(TblRegister tblRegister)
        {
            using (PetShopDataEntities da = new PetShopDataEntities())
            {
                if (ModelState.IsValid)
                {
                    da.TblRegisters.Add(tblRegister);
                    da.SaveChanges();
                    ViewBag.message = "Registartion Successfully";
                    ModelState.Clear();
                }
            }
            return View(tblRegister);
        }

        [HttpPost]
        public ActionResult Login(TblRegister tblRegister)
        {
            using(PetShopDataEntities da=new PetShopDataEntities())
            {
                if(ModelState.IsValid)
                {
                    var obj = da.TblRegisters.Where(a => a.userName.Equals(tblRegister.userName) && a.pass.Equals(tblRegister.pass)).FirstOrDefault();
                    if (obj != null)
                    {
                        //Session["UserID"] = obj.UserId.ToString();
                        //Session["UserName"] = obj.email.ToString();
                        return RedirectToAction("Booking");
                    }
                    ViewBag.message = "Login Successfully";
                    ModelState.Clear();
                }
            }
            return View(tblRegister);
        }
        [HttpPost]
        public ActionResult Booking(BookingTbl bookingTbl)
        {
            using (PetShopDataEntities da = new PetShopDataEntities())
            {
                if (ModelState.IsValid)
                {
                    da.BookingTbls.Add(bookingTbl);
                    da.SaveChanges();
                    ViewBag.message = "Booking Successfully";
                    ModelState.Clear();
                }
            }
            return View(bookingTbl);
        }
    }
}