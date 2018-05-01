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
    public class TPPCGrossProfitsController : Controller
    {
        private OPSAEntities db = new OPSAEntities();

        // GET: TPPCGrossProfits
        public ActionResult Index()
        {
            String connectionString = "Data Source=LAPTOP-VCM6MJ7Q;Initial Catalog=OPSA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            dynamic sql = "dbo.SelectTPPCDetails";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //var model = new List<TPPCGrossProfit>();

            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        //Console.WriteLine(rdr.GetString(1));

                        var tppcGrossProfit = new TPPCGrossProfit();
                        tppcGrossProfit.EmployeeName = rdr.GetString(0);
                        tppcGrossProfit.NewGPRanking = rdr.GetDouble(1);
                        tppcGrossProfit.BiWeekGP = rdr.GetDouble(2);
                        tppcGrossProfit.YTDContractGP = rdr.GetDouble(3);
                        tppcGrossProfit.YTDDirectHireGP = rdr.GetDouble(4);
                        tppcGrossProfit.AdditionDHAllocation = rdr.GetDouble(5);
                        tppcGrossProfit.TotalGP = rdr.GetDouble(6);
                        tppcGrossProfit.QualifyingTotalGP = rdr.GetDouble(7);
                        tppcGrossProfit.TotalGPTarget = rdr.GetDouble(8);
                        tppcGrossProfit.PercentTotalGP = rdr.GetDouble(9);
                        tppcGrossProfit.NewContractGP = rdr.GetDouble(10);
                        tppcGrossProfit.QualifyingNewGP = rdr.GetDouble(11);
                        tppcGrossProfit.NewGPTarget = rdr.GetDouble(12);
                        tppcGrossProfit.PercentNewGP = rdr.GetDouble(13);

                        SaveIfNew(tppcGrossProfit);
                        //model.Add(tppcGrossProfit);
                    }
                    rdr.NextResult();
                }
            }
            return View(db.TPPCGrossProfits.ToList());
            //return View(model);
        }
        public void SaveIfNew(TPPCGrossProfit m)
        {
            using (OPSAEntities db = new OPSAEntities())
            {

                if (m.TPPCId >= 0)
                {
                    var v = db.TPPCGrossProfits.Where(a => a.EmployeeName == m.EmployeeName).FirstOrDefault();
                    if (v != null)
                    {
                        v.EmployeeName = m.EmployeeName;
                        v.NewGPRanking = m.NewGPRanking;
                        v.BiWeekGP = m.BiWeekGP;
                        v.YTDContractGP = m.YTDContractGP;
                        v.YTDDirectHireGP = m.YTDDirectHireGP;
                        v.AdditionDHAllocation = m.AdditionDHAllocation;
                        v.TotalGP = m.TotalGP;
                        v.QualifyingTotalGP = m.QualifyingTotalGP;
                        v.TotalGPTarget = m.TotalGPTarget;
                        v.PercentTotalGP = m.PercentTotalGP;
                        v.NewContractGP = m.NewContractGP;
                        v.QualifyingNewGP = m.QualifyingNewGP;
                        v.NewGPTarget = m.NewGPTarget;
                        v.PercentNewGP = m.PercentNewGP;
                    }
                    else if (v == null)
                    {
                        db.TPPCGrossProfits.Add(m);
                    }

                }
                db.SaveChanges();
            }
        }
        // GET: TPPCGrossProfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPPCGrossProfit tPPCGrossProfit = db.TPPCGrossProfits.Find(id);
            if (tPPCGrossProfit == null)
            {
                return HttpNotFound();
            }
            return View(tPPCGrossProfit);
        }

        // GET: TPPCGrossProfits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TPPCGrossProfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TPPCId,EmployeeId,NewGPRanking,YTDContractGP,YTDDirectHireGP,AdditionDHAllocation,TotalGP,QualifyingTotalGP,NewContractGP,QualifyingNewGP,NewGPTarget,PercentNewGP")] TPPCGrossProfit tPPCGrossProfit)
        {
            if (ModelState.IsValid)
            {
                db.TPPCGrossProfits.Add(tPPCGrossProfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tPPCGrossProfit);
        }

        // GET: TPPCGrossProfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPPCGrossProfit tPPCGrossProfit = db.TPPCGrossProfits.Find(id);
            if (tPPCGrossProfit == null)
            {
                return HttpNotFound();
            }
            return View(tPPCGrossProfit);
        }

        // POST: TPPCGrossProfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TPPCId,EmployeeId,NewGPRanking,YTDContractGP,YTDDirectHireGP,AdditionDHAllocation,TotalGP,QualifyingTotalGP,NewContractGP,QualifyingNewGP,NewGPTarget,PercentNewGP")] TPPCGrossProfit tPPCGrossProfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tPPCGrossProfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tPPCGrossProfit);
        }

        // GET: TPPCGrossProfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TPPCGrossProfit tPPCGrossProfit = db.TPPCGrossProfits.Find(id);
            if (tPPCGrossProfit == null)
            {
                return HttpNotFound();
            }
            return View(tPPCGrossProfit);
        }

        // POST: TPPCGrossProfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TPPCGrossProfit tPPCGrossProfit = db.TPPCGrossProfits.Find(id);
            db.TPPCGrossProfits.Remove(tPPCGrossProfit);
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
