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
    public class M_MasterInfoController : Controller
    {
        private CRASMIB_RAMRAJYADBEntities db = new CRASMIB_RAMRAJYADBEntities();

        // GET: M_MasterInfo
        public async Task<ActionResult> Index()
        {
            return View(await db.M_MasterInfo.ToListAsync());
        }

        // GET: M_MasterInfo/Details/5
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

        // GET: M_MasterInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_MasterInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MasterText,MasterTable")] M_MasterInfo m_MasterInfo)
        {
            if (ModelState.IsValid)
            {
                m_MasterInfo.CreatedBy = Resources.RamRajyaResources.DefaultLoginUser;
                m_MasterInfo.ModifiedBy = Resources.RamRajyaResources.DefaultLoginUser;
                m_MasterInfo.CreatedDate = DateTime.Now;
                m_MasterInfo.ModifiedDate = DateTime.Now;
                m_MasterInfo.Active = true;
                db.M_MasterInfo.Add(m_MasterInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_MasterInfo);
        }

        // GET: M_MasterInfo/Edit/5
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

        // POST: M_MasterInfo/Edit/5
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

        // GET: M_MasterInfo/Delete/5
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

        // POST: M_MasterInfo/Delete/5
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
