using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPSA.Models;

namespace OPSA.Controllers
{
    public class NADGrossProfitsController : Controller
    {
        private OPSAEntities db = new OPSAEntities();

        // GET: NADGrossProfits
        public ActionResult Index()
        {
            String connectionString = "Data Source=LAPTOP-VCM6MJ7Q;Initial Catalog=OPSA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            dynamic sql = "dbo.SelectNADDetails";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            var model = new List<NADGrossProfit>();
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        //Console.WriteLine(rdr.GetString(1));

                        var nadGrossProfit = new NADGrossProfit();
                        //nadGrossProfit.NADId = rdr.GetInt32(0);
                        //nadGrossProfit.EmployeeId = rdr.GetInt32(1);
                        nadGrossProfit.EmployeeName = rdr.GetString(0);
                        nadGrossProfit.BiWeeklyGP = rdr.GetDouble(1);
                        nadGrossProfit.YTDDirectHireGP = rdr.GetDouble(2);
                        nadGrossProfit.YTDGPCombined = rdr.GetDouble(3);
                        nadGrossProfit.GPTarget = rdr.GetDouble(4);
                        nadGrossProfit.PercentGP = rdr.GetDouble(5);

                        model.Add(nadGrossProfit);
                    }
                    rdr.NextResult();
                }

            }
            return View(model);
        }
        //db.NADGrossProfits.ToList()

        // GET: NADGrossProfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NADGrossProfit nADGrossProfit = db.NADGrossProfits.Find(id);
            if (nADGrossProfit == null)
            {
                return HttpNotFound();
            }
            return View(nADGrossProfit);
        }

        // GET: NADGrossProfits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NADGrossProfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NADId,EmloyeeId,BiWeeklyGP,YTDDirectHireGP,YTDGPCombined,GPTarget,PercentGP")] NADGrossProfit nADGrossProfit)
        {
            if (ModelState.IsValid)
            {
                db.NADGrossProfits.Add(nADGrossProfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nADGrossProfit);
        }

        // GET: NADGrossProfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NADGrossProfit nADGrossProfit = db.NADGrossProfits.Find(id);
            if (nADGrossProfit == null)
            {
                return HttpNotFound();
            }
            return View(nADGrossProfit);
        }

        // POST: NADGrossProfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NADId,EmloyeeId,BiWeeklyGP,YTDDirectHireGP,YTDGPCombined,GPTarget,PercentGP")] NADGrossProfit nADGrossProfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nADGrossProfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nADGrossProfit);
        }

        // GET: NADGrossProfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NADGrossProfit nADGrossProfit = db.NADGrossProfits.Find(id);
            if (nADGrossProfit == null)
            {
                return HttpNotFound();
            }
            return View(nADGrossProfit);
        }

        // POST: NADGrossProfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NADGrossProfit nADGrossProfit = db.NADGrossProfits.Find(id);
            db.NADGrossProfits.Remove(nADGrossProfit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
