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
    public class EmployeeController : Controller
    {
        private OPSAEntities db = new OPSAEntities();

        // GET: Employee
        //This index uses the connection string provided in web.config to do SQL on the DB the solution is connected to
        //It then defines a List of Employees, uses a stored procedure and SQLDataReader to populate the list of Employees
        //This list of employees is then returned into the view

        public ActionResult Index()
        {
            //String connectionString = "Data Source=LAPTOP-VCM6MJ7Q;Initial Catalog=OPSA;Integrated Security=True";
            //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-VCM6MJ7Q;Initial Catalog=OPSA;Integrated Security=True");
            String connectionString = @"Data Source=LAPTOP-VCM6MJ7Q;Initial Catalog=OPSA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            dynamic sql = "dbo.SelectEmployee";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //var model = new List<Employee>();
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        //Console.WriteLine(rdr.GetString(1));
                        var employee = new Employee();
                        //employee.EmployeeId = rdr.GetInt32(0);
                        employee.EmployeeName = rdr.GetString(0);
                        employee.Tenure = rdr.GetInt32(1);
                        employee.StartDate = rdr.GetDateTime(2);
                        employee.Position = rdr.GetString(3);
                        employee.Branch = rdr.GetString(4);

                        SaveIfNew(employee);
                        //model.Add(employee);
                    }
                    rdr.NextResult();
                }
            }
            return View(db.Employees.ToList());
        }
        //TODO:Comment this.
        public void SaveIfNew(Employee m)
        {
            using (OPSAEntities db = new OPSAEntities())
            {

                if (m.EmployeeId >= 0)
                {
                    var v = db.Employees.Where(a => a.EmployeeName == m.EmployeeName).FirstOrDefault();
                    if (v != null)
                    {
                        v.EmployeeName = m.EmployeeName;
                        v.Tenure = m.Tenure;
                        v.StartDate = m.StartDate;
                        v.Position = m.Position;
                        v.Branch = m.Branch;
                    }
                    else if (v == null)
                    {
                        db.Employees.Add(m);
                    }
                }
                db.SaveChanges();
            }
        }
        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,Tenure,StartDate,Position,Branch")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeName,Tenure,StartDate,Position,Branch")] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
