using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RamRajyaCrasmibWeb.Models;

namespace RamRajyaCrasmibWeb.Controllers
{
    public class MasterInfoController : Controller
    {
        private CRASMIB_RAMRAJYADBEntities db = new CRASMIB_RAMRAJYADBEntities();

        // GET: MasterInfo
        public async Task<ActionResult> Index()
        {
            return View(await db.M_MasterInfo.ToListAsync());
        }

        // GET: MasterInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterInfo m_MasterInfo = await db.M_MasterInfo.FindAsync(id);
            if (m_MasterInfo == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterInfo);
        }

        // GET: MasterInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MasterID,MasterText,MasterTable,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_MasterInfo m_MasterInfo)
        {
            if (ModelState.IsValid)
            {
                db.M_MasterInfo.Add(m_MasterInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_MasterInfo);
        }

        // GET: MasterInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterInfo m_MasterInfo = await db.M_MasterInfo.FindAsync(id);
            if (m_MasterInfo == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterInfo);
        }

        // POST: MasterInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MasterID,MasterText,MasterTable,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_MasterInfo m_MasterInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_MasterInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_MasterInfo);
        }

        // GET: MasterInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterInfo m_MasterInfo = await db.M_MasterInfo.FindAsync(id);
            if (m_MasterInfo == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterInfo);
        }

        // POST: MasterInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_MasterInfo m_MasterInfo = await db.M_MasterInfo.FindAsync(id);
            db.M_MasterInfo.Remove(m_MasterInfo);
            await db.SaveChangesAsync();
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
