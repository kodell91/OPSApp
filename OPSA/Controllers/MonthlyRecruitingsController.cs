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
    public class MonthlyRecruitingsController : Controller
    {
        private OPSAEntities db = new OPSAEntities();

        // GET: MonthlyRecruitings
        [Authorize]
        public ActionResult Index()
        {
            //String connectionString = "Data Source=LAPTOP-VCM6MJ7Q;Initial Catalog=OPSA;Integrated Security=True";
            //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-VCM6MJ7Q;Initial Catalog=OPSA;Integrated Security=True");
            String connectionString = @"Data Source = SQL7001.site4now.net; Initial Catalog = DB_A33255_OPSA; User Id = DB_A33255_OPSA_admin; Password = KennethGetsA5!; ";
            SqlConnection conn = new SqlConnection(connectionString);
            dynamic sql = "dbo.SelectMonthDetails";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //var model = new List<MonthlyRecruiting>();

            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        //Console.WriteLine(rdr.GetString(1));

                        var monthlyRecruiting = new MonthlyRecruiting();
                        monthlyRecruiting.EmployeeName = rdr.GetString(0);
                        monthlyRecruiting.RankDifference = rdr.GetInt32(1);
                        monthlyRecruiting.PreviousRank = rdr.GetInt32(2);
                        monthlyRecruiting.CompanyRank = rdr.GetInt32(3);
                        monthlyRecruiting.PositionRank = rdr.GetInt32(4);
                        monthlyRecruiting.Score = rdr.GetDouble(5);
                        monthlyRecruiting.Total4WKStarts = rdr.GetDouble(6);
                        monthlyRecruiting.CurrentHeadCount = rdr.GetDouble(7);
                        monthlyRecruiting.MonthHCGoal = rdr.GetDouble(8);
                        monthlyRecruiting.Prescreens = rdr.GetDouble(9);
                        monthlyRecruiting.Sendouts = rdr.GetDouble(10);
                        monthlyRecruiting.ClientVisits = rdr.GetDouble(11);
                        monthlyRecruiting.NewPositions = rdr.GetDouble(12);
                        monthlyRecruiting.PercentExpectations = rdr.GetDouble(13);

                        SaveIfNew(monthlyRecruiting);
                    }
                    rdr.NextResult();
                }
            }
            return View(db.MonthlyRecruitings.ToList());
        }
        public void SaveIfNew(MonthlyRecruiting m)
        {
            using (OPSAEntities db = new OPSAEntities())
            {

                if (m.EmployeeId >= 0)
                {
                    var v = db.MonthlyRecruitings.Where(a => a.EmployeeName == m.EmployeeName).FirstOrDefault();
                    if (v != null)
                    {
                        v.EmployeeName = m.EmployeeName;
                        v.RankDifference = m.RankDifference;
                        v.PreviousRank = m.PreviousRank;
                        v.CompanyRank = m.CompanyRank;
                        v.PositionRank = m.PositionRank;
                        v.Score = m.Score;
                        v.Total4WKStarts = m.Total4WKStarts;
                        v.CurrentHeadCount = m.CurrentHeadCount;
                        v.MonthHCGoal = m.MonthHCGoal;
                        v.Prescreens = m.PreviousRank;
                        v.Sendouts = m.Sendouts;
                        v.ClientVisits = m.ClientVisits;
                        v.NewPositions = m.NewPositions;
                        v.PercentExpectations = m.PercentExpectations;
                    } 
                    else if(v == null)
                    {
                        db.MonthlyRecruitings.Add(m);
                    }
                    
                }
                db.SaveChanges();
            }
        }

        // GET: MonthlyRecruitings/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyRecruiting monthlyRecruiting = db.MonthlyRecruitings.Find(id);
            if (monthlyRecruiting == null)
            {
                return HttpNotFound();
            }
            return View(monthlyRecruiting);
        }

        // GET: MonthlyRecruitings/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonthlyRecruitings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,RankDifference,PreviousRank,CompanyRank,PositionRank,Score,Total4WKStarts,CurrentHeadCount,MonthHCGoal,Prescreens,Sendouts,ClientVisits,NewPositions,PercentExpectations")] MonthlyRecruiting monthlyRecruiting)
        {
            if (ModelState.IsValid)
            {
                db.MonthlyRecruitings.Add(monthlyRecruiting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monthlyRecruiting);
        }

        // GET: MonthlyRecruitings/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyRecruiting monthlyRecruiting = db.MonthlyRecruitings.Find(id);
            if (monthlyRecruiting == null)
            {
                return HttpNotFound();
            }
            return View(monthlyRecruiting);
        }

        // POST: MonthlyRecruitings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeName,RankDifference,PreviousRank,CompanyRank,PositionRank,Score,Total4WKStarts,CurrentHeadCount,MonthHCGoal,Prescreens,Sendouts,ClientVisits,NewPositions,PercentExpectations")] MonthlyRecruiting monthlyRecruiting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monthlyRecruiting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlyRecruiting);
        }

        // GET: MonthlyRecruitings/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyRecruiting monthlyRecruiting = db.MonthlyRecruitings.Find(id);
            if (monthlyRecruiting == null)
            {
                return HttpNotFound();
            }
            return View(monthlyRecruiting);
        }

        // POST: MonthlyRecruitings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlyRecruiting monthlyRecruiting = db.MonthlyRecruitings.Find(id);
            db.MonthlyRecruitings.Remove(monthlyRecruiting);
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
