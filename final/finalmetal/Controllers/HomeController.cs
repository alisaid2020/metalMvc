using finalmetal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using PagedList;

namespace finalmetal.Controllers
{
    [OutputCache(Duration = 1)]
    public class HomeController : Controller
    {

        #region DB


       

        finalcontext DB;
        public HomeController()
        {
            DB = new finalcontext();
        }

        #endregion


        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion


        #region register
        [HttpGet]
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(user userlog)
        {
            if (ModelState.IsValid)
            {
                userlog.Role = "user";
                DB.Users.Add(userlog);
                DB.SaveChanges();
                return RedirectToAction("login");
            }
            else
                return View(userlog);
        }

        #endregion


        #region login
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(user userlog)
        {
            var obj = DB.Users.Where(ww => ww.Email.Equals(userlog.Email) && ww.Password.Equals(userlog.Password)).FirstOrDefault();
            if (obj != null && obj.Role == "Admin")
            {
                int id = obj.Id;
                Session["type"] = "Admin";
                Session["userid"] = obj.Id;
                return RedirectToAction("products");
            }
            else if
               (obj != null && obj.Role == "user")
            {
                int _id = obj.Id;

                Session["type"] = "user";
                Session["userid"] = _id;
                return RedirectToAction("products");
            }
            else
                return View(userlog);
        }


        public ActionResult logout()
        {
            Session["userid"] = null;
            Session["type"] = null;
            return RedirectToAction("Index");
        }
        #endregion


        #region About
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        #endregion


        #region addproduct
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(product prod, HttpPostedFileBase Imag1, HttpPostedFileBase Imag2, HttpPostedFileBase Imag3)
        {
            Imag1.SaveAs(Server.MapPath($"~/images/{Imag1.FileName}"));
            Imag2.SaveAs(Server.MapPath($"~/images/{Imag1.FileName}"));
            Imag3.SaveAs(Server.MapPath($"~/images/{Imag1.FileName}"));




            prod.Image1 = Imag1.FileName;
            prod.Image2 = Imag2.FileName;
            prod.Image3 = Imag3.FileName;



            prod.Image1.Equals(Imag1.FileName.ToString());
            prod.Image2.Equals(Imag2.FileName.ToString());
            prod.Image3.Equals(Imag3.FileName.ToString());


            //if (ModelState.IsValid)
            //{
            DB.Products.Add(prod);
            DB.SaveChanges();
            return RedirectToAction("products");
            //}
            //else
            //    return View(prod);

        }
        #endregion


        #region products
        [HttpGet]
        public ActionResult products(int? page)
        {
            var prods = DB.Products.ToList().OrderByDescending(w => w.Id).ToPagedList(page ?? 1, 6);
            return View(prods);
        }
        #endregion


        #region details
        public ActionResult Details(int id)
        {
            var prod = DB.Products.Find(id);
            return View(prod);
        }
        #endregion


        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var prod = DB.Products.Find(id);
            return View(prod);

        }
        [HttpPost]
        public ActionResult Edit(product prod, HttpPostedFileBase imag1, HttpPostedFileBase imag2, HttpPostedFileBase imag3)
        {
            prod.Image1 = imag1.FileName;
            prod.Image2 = imag2.FileName;
            prod.Image3 = imag3.FileName;

            imag1.SaveAs(Server.MapPath($"~/images/{imag1.FileName}"));
            imag2.SaveAs(Server.MapPath($"~/images/{imag2.FileName}"));
            imag3.SaveAs(Server.MapPath($"~/images/{imag3.FileName}"));



            DB.Entry(prod).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("ProductAdmin");

        }
        #endregion


        #region delet
        [HttpGet]
        public ActionResult delet(int id)
        {
            var prod = DB.Products.Find(id);
            DB.Products.Remove(prod);
            DB.SaveChanges();
            return RedirectToAction("Products");
        }

        #endregion


        #region contact
        [HttpGet]
        public ActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult contact(finalmetal.Models.gmail model)
        {

            try
            {

                MailMessage ms = new MailMessage("ali.harhera93@gmail.com", model.To);
                ms.Subject = model.Subject;
                ms.Body = model.Body;
                ms.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential("ali.harhera93@gmail.com", "ali123456789ali123456789");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(ms);
                ViewBag.message = "email has been sent";
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
            }
            return View();




        }
    }


    #endregion
}


