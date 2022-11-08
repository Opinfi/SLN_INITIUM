using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Web.Managers;

namespace Portal.Web.Controllers
{
    public class TicketController : Controller
    {
        private  TicketManager _ticketManager=> new();
        // GET: TicketController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            var view = _ticketManager.SincronizandoDatosTickets();
            return View(view);
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {


                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
