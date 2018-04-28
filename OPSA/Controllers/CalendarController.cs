using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPSA.Models;

namespace OPSA.Controllers
{
    public class CalendarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public CalendarController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (db)
            {
                var events = db.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            using (db)
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = db.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    db.Events.Add(e);
                };
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (db)
            {
                var v = db.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    db.Events.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}
//using OPSA.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace OPSA.Controllers
//{
//    public class CalendarController : Controller
//    {
//        // GET: Calendar
//        public ActionResult Calendar()
//        {
//            return View();
//        }

//        public JsonResult GetEvents()
//        {
//            using (ApplicationDbContext dc = new ApplicationDbContext())
//            {
//                var events = dc.Events.ToList();
//                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
//            }
//        }
//        [HttpPost]
//        public JsonResult SaveEvent(Event e)
//        {
//            var status = false;
//            using (ApplicationDbContext dc = new ApplicationDbContext())
//            {
//                if (e.EventID > 0)
//                {
//                    //Update the event
//                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
//                    if (v != null)
//                    {
//                        v.Subject = e.Subject;
//                        v.Start = e.Start;
//                        v.End = e.End;
//                        v.Description = e.Description;
//                        v.IsFullDay = e.IsFullDay;
//                        v.ThemeColor = e.ThemeColor;
//                    }
//                }
//                else
//                {
//                    dc.Events.Add(e);
//                }
//            }
//            return new JsonResult { Data = new { status = status } };
//        }

//        [HttpPost]
//        public JsonResult DeleteEvent(int eventID)
//        {
//            var status = false;
//            using (ApplicationDbContext dc = new ApplicationDbContext())
//            {
//                var v = dc.Events.Where(a => a.EventID == eventID).FirstOrDefault();
//                if (v != null)
//                {
//                    dc.Events.Remove(v);
//                    dc.SaveChanges();
//                    status = true;
//                }
//            }

//            return new JsonResult { Data = new { status = status } };
//        }
//    }
//}