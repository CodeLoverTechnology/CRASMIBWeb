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
using RamRajyaCrasmibWeb.App_Code;

namespace RamRajyaCrasmibWeb.Controllers
{
    public class MembersMasterController : Controller
    {
        private CRASMIB_RAMRAJYADBEntities db = new CRASMIB_RAMRAJYADBEntities();

        // GET: MembersMaster
        public async Task<ActionResult> Index()
        {
            var m_MembersMaster = db.M_MembersMaster.Include(m => m.M_MasterInfo).Include(m => m.M_MasterInfo1);
            return View(await m_MembersMaster.ToListAsync());
        }

        // GET: MembersMaster/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MembersMaster m_MembersMaster = await db.M_MembersMaster.FindAsync(id);
            if (m_MembersMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_MembersMaster);
        }

        // GET: MembersMaster/Create
        public ActionResult Create()
        {
            ViewBag.Qualification = new SelectList(db.M_MasterInfo.Where(x=>x.MasterTable== "Qualification"), "MasterID", "MasterText");
            ViewBag.MembershipCategory = new SelectList(db.M_MasterInfo.Where(x => x.MasterTable == "MembershipCategory"), "MasterID", "MasterText");
            ViewBag.Gender = new SelectList(db.M_MasterInfo.Where(x => x.MasterTable == "Gender"), "MasterID", "MasterText");
            return View();
        }

        // POST: MembersMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,ParantName,DOB,Qualification,Occupation,ContactNo,Email,P_Address,Permanent_Address,Interest_Achievement,PurposeOfJoining,OtherNGO_Member,OtherNGOMembersDetails,MembershipCategory,Fax,Website,Organization,Position,OrganizationPhone,OrganizationFax,OrganizationEmail,OrganizationWebsite")] M_MembersMaster m_MembersMaster)
        {
            if (ModelState.IsValid)
            {
                m_MembersMaster.MemberID = CommonFunction.GenerateMemberCode();
                m_MembersMaster.CreatedBy = Resources.RamRajyaResources.DefaultLoginUser;
                m_MembersMaster.CreatedDate = DateTime.Now;
                m_MembersMaster.ModifiedBy = Resources.RamRajyaResources.DefaultLoginUser;
                m_MembersMaster.ModifiedDate = DateTime.Now;
                m_MembersMaster.Active = true;
                db.M_MembersMaster.Add(m_MembersMaster);
                await db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thank you for Apply Membership for CRASMIB Ram Rajya. Your Member ID : "+ m_MembersMaster.MemberID + ". Further you will use for More Details. also we will Shortly Connect you. ";
                return RedirectToAction("Index","Home",null);
            }

            ViewBag.Qualification = new SelectList(db.M_MasterInfo, "MasterID", "MasterText", m_MembersMaster.Qualification);
            ViewBag.MembershipCategory = new SelectList(db.M_MasterInfo, "MasterID", "MasterText", m_MembersMaster.MembershipCategory);
            return View(m_MembersMaster);
        }

        // GET: MembersMaster/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MembersMaster m_MembersMaster = await db.M_MembersMaster.FindAsync(id);
            if (m_MembersMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.Qualification = new SelectList(db.M_MasterInfo, "MasterID", "MasterText", m_MembersMaster.Qualification);
            ViewBag.MembershipCategory = new SelectList(db.M_MasterInfo, "MasterID", "MasterText", m_MembersMaster.MembershipCategory);
            return View(m_MembersMaster);
        }

        // POST: MembersMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MemberID,Name,ParantName,DOB,Qualification,Occupation,ContactNo,Email,P_Address,Permanent_Address,Interest_Achievement,PurposeOfJoining,OtherNGO_Member,OtherNGOMembersDetails,MembershipCategory,Fax,Website,Organization,Position,OrganizationPhone,OrganizationFax,OrganizationEmail,OrganizationWebsite,Remarks,IsApproved,ValidityFrom,ValidtyTo,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_MembersMaster m_MembersMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_MembersMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Qualification = new SelectList(db.M_MasterInfo, "MasterID", "MasterText", m_MembersMaster.Qualification);
            ViewBag.MembershipCategory = new SelectList(db.M_MasterInfo, "MasterID", "MasterText", m_MembersMaster.MembershipCategory);
            return View(m_MembersMaster);
        }

        // GET: MembersMaster/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MembersMaster m_MembersMaster = await db.M_MembersMaster.FindAsync(id);
            if (m_MembersMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_MembersMaster);
        }

        // POST: MembersMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            M_MembersMaster m_MembersMaster = await db.M_MembersMaster.FindAsync(id);
            db.M_MembersMaster.Remove(m_MembersMaster);
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
