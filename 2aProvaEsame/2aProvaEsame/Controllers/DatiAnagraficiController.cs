using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2aProvaEsame.Data;
using _2aProvaEsame.Models;

namespace _2aProvaEsame.Controllers
{
    public class DatiAnagraficiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatiAnagraficiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DatiAnagrafici
        public async Task<IActionResult> Index()
        {
            return View(await _context.DatiAnagrafici.ToListAsync());
        }

        // GET: DatiAnagrafici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datiAnagrafici = await _context.DatiAnagrafici
                .FirstOrDefaultAsync(m => m.DatiAnagraficiId == id);
            if (datiAnagrafici == null)
            {
                return NotFound();
            }

            return View(datiAnagrafici);
        }

        // GET: DatiAnagrafici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatiAnagrafici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatiAnagraficiId,Nome,Cognome,Email,RecapitoTelefonico,IndirizzoCompleto,FlagCliente,FlagInterno,FlagFornitore,CodiceAnagrafica,Username,Password")] DatiAnagrafici datiAnagrafici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datiAnagrafici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datiAnagrafici);
        }

        // GET: DatiAnagrafici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datiAnagrafici = await _context.DatiAnagrafici.FindAsync(id);
            if (datiAnagrafici == null)
            {
                return NotFound();
            }
            return View(datiAnagrafici);
        }

        // POST: DatiAnagrafici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatiAnagraficiId,Nome,Cognome,Email,RecapitoTelefonico,IndirizzoCompleto,FlagCliente,FlagInterno,FlagFornitore,CodiceAnagrafica,Username,Password")] DatiAnagrafici datiAnagrafici)
        {
            if (id != datiAnagrafici.DatiAnagraficiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datiAnagrafici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatiAnagraficiExists(datiAnagrafici.DatiAnagraficiId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(datiAnagrafici);
        }

        // GET: DatiAnagrafici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datiAnagrafici = await _context.DatiAnagrafici
                .FirstOrDefaultAsync(m => m.DatiAnagraficiId == id);
            if (datiAnagrafici == null)
            {
                return NotFound();
            }

            return View(datiAnagrafici);
        }

        // POST: DatiAnagrafici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datiAnagrafici = await _context.DatiAnagrafici.FindAsync(id);
            _context.DatiAnagrafici.Remove(datiAnagrafici);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatiAnagraficiExists(int id)
        {
            return _context.DatiAnagrafici.Any(e => e.DatiAnagraficiId == id);
        }
    }
}
