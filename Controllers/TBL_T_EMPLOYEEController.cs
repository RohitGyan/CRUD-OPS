using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCrudOperations.Models;

namespace MVCCrudOperations.Controllers
{
    public class TBL_T_EMPLOYEEController : Controller
    {
        private TestDbEntities db = new TestDbEntities();

        // GET: TBL_T_EMPLOYEE
        public ActionResult Index()
        {
            return View(db.TBL_T_EMPLOYEE.ToList());
        }

        // GET: TBL_T_EMPLOYEE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_T_EMPLOYEE tBL_T_EMPLOYEE = db.TBL_T_EMPLOYEE.Find(id);
            if (tBL_T_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_T_EMPLOYEE);
        }

        // GET: TBL_T_EMPLOYEE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_T_EMPLOYEE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmpName,Age,Salary,ManagerName,EmpStatus,CreatedDate,CreatedBy,ModifiedDate,ModifideBy")] TBL_T_EMPLOYEE tBL_T_EMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.TBL_T_EMPLOYEE.Add(tBL_T_EMPLOYEE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_T_EMPLOYEE);
        }

        // GET: TBL_T_EMPLOYEE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_T_EMPLOYEE tBL_T_EMPLOYEE = db.TBL_T_EMPLOYEE.Find(id);
            if (tBL_T_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_T_EMPLOYEE);
        }

        // POST: TBL_T_EMPLOYEE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,Age,Salary,ManagerName,EmpStatus,CreatedDate,CreatedBy,ModifiedDate,ModifideBy")] TBL_T_EMPLOYEE tBL_T_EMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_T_EMPLOYEE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_T_EMPLOYEE);
        }

        // GET: TBL_T_EMPLOYEE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_T_EMPLOYEE tBL_T_EMPLOYEE = db.TBL_T_EMPLOYEE.Find(id);
            if (tBL_T_EMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(tBL_T_EMPLOYEE);
        }

        // POST: TBL_T_EMPLOYEE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_T_EMPLOYEE tBL_T_EMPLOYEE = db.TBL_T_EMPLOYEE.Find(id);
            db.TBL_T_EMPLOYEE.Remove(tBL_T_EMPLOYEE);
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
