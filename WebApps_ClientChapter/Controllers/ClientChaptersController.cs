using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebApps_ClientChapter.Models;

namespace WebApps_ClientChapter.Controllers
{
    public class ClientChaptersController : Controller
    {
        private TSMAppsEntities db = new TSMAppsEntities();

        // GET: ClientChapters
        public ActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "Client ID")
            {
                return View(db.ClientChapters.Where(x => x.ClientID.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 50));
            }
            else
            {
                return View(db.ClientChapters.Where(x => x.ChapterCode.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 50));
            }
        }

        // GET: ClientChapters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientChapter clientChapter = db.ClientChapters.Find(id);
            if (clientChapter == null)
            {
                return HttpNotFound();
            }
            return View(clientChapter);
        }

        // GET: ClientChapters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientChapters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientChapterSKey,ClientID,ChapterCode,ChapterName,ClientLevel1,ClientLevel2,ClientLevel3,ClientLevel4,EnvelopeLine1,EnvelopeLine2,EnvelopeLine3,EnvelopeLine4,EnvelopeLine5,EnvelopeClientName,ClientAddressLine1,ClientAddressLine2,ClientAddressLine3,ClientCity,ClientState,ClientZip,Uw,Commander,CommanderTitle,BillingChapter,AreaName,CommanderLastName,ClientPhone,ClientFax,ClientEmailAddress,OldChapterCode,CustomerBillingNumber,WebAddress,Region,Lockbox,UwBlackoutFromDate,UwBlackoutToDate,MD_COORD,Commander2,CommanderTitle2,CommanderLastName2,BillingChapter2,ClientEmailAddress2,MspThank,LastThankYouDate,SeedNames,OriginalName,ClientName,ChapterDesignation,Division,Active,Vertical,ClientActiveDate,FiscalYearBegins,Flex1,Flex2,Flex3,Flex4,Flex5,CreateDate,ModifiedDate,CreatedBy,ModifiedBy")] ClientChapter clientChapter)
        {
            if (ModelState.IsValid)
            {
                db.ClientChapters.Add(clientChapter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientChapter);
        }

        // GET: ClientChapters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientChapter clientChapter = db.ClientChapters.Find(id);
            if (clientChapter == null)
            {
                return HttpNotFound();
            }
            return View(clientChapter);
        }

        // POST: ClientChapters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientChapterSKey,ClientID,ChapterCode,ChapterName,ClientLevel1,ClientLevel2,ClientLevel3,ClientLevel4,EnvelopeLine1,EnvelopeLine2,EnvelopeLine3,EnvelopeLine4,EnvelopeLine5,EnvelopeClientName,ClientAddressLine1,ClientAddressLine2,ClientAddressLine3,ClientCity,ClientState,ClientZip,Uw,Commander,CommanderTitle,BillingChapter,AreaName,CommanderLastName,ClientPhone,ClientFax,ClientEmailAddress,OldChapterCode,CustomerBillingNumber,WebAddress,Region,Lockbox,UwBlackoutFromDate,UwBlackoutToDate,MD_COORD,Commander2,CommanderTitle2,CommanderLastName2,BillingChapter2,ClientEmailAddress2,MspThank,LastThankYouDate,SeedNames,OriginalName,ClientName,ChapterDesignation,Division,Active,Vertical,ClientActiveDate,FiscalYearBegins,Flex1,Flex2,Flex3,Flex4,Flex5,CreateDate,ModifiedDate,CreatedBy,ModifiedBy")] ClientChapter clientChapter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientChapter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientChapter);
        }

        // GET: ClientChapters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientChapter clientChapter = db.ClientChapters.Find(id);
            if (clientChapter == null)
            {
                return HttpNotFound();
            }
            return View(clientChapter);
        }

        // POST: ClientChapters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientChapter clientChapter = db.ClientChapters.Find(id);
            db.ClientChapters.Remove(clientChapter);
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
