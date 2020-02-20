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
    public class DatiRichiesteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatiRichiesteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DatiRichieste
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DatiRichieste.Include(d => d.Assegnato).Include(d => d.Richiedente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DatiRichieste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datiRichiesta = await _context.DatiRichieste
                .Include(d => d.Assegnato)
                .Include(d => d.Richiedente)
                .FirstOrDefaultAsync(m => m.DatiRichiestaId == id);
            if (datiRichiesta == null)
            {
                return NotFound();
            }

            return View(datiRichiesta);
        }

        // GET: DatiRichieste/Create
        public IActionResult Create()
        {
            ViewData["AssegnatoeId"] = new SelectList(_context.DatiAnagrafici, "DatiAnagraficiId", "CodiceAnagrafica");
            ViewData["RichiedenteId"] = new SelectList(_context.DatiAnagrafici, "DatiAnagraficiId", "CodiceAnagrafica");
            return View();
        }

        // POST: DatiRichieste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatiRichiestaId,RichiedenteId,AssegnatoeId,DataRichiesta,DataChiusura,StatoRichiesta,TitoloRichiesta,DescrizioneRichiesta,DescrizioneRisposta")] DatiRichiesta datiRichiesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datiRichiesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssegnatoeId"] = new SelectList(_context.DatiAnagrafici, "DatiAnagraficiId", "CodiceAnagrafica", datiRichiesta.AssegnatoeId);
            ViewData["RichiedenteId"] = new SelectList(_context.DatiAnagrafici, "DatiAnagraficiId", "CodiceAnagrafica", datiRichiesta.RichiedenteId);
            return View(datiRichiesta);
        }

        // GET: DatiRichieste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datiRichiesta = await _context.DatiRichieste.FindAsync(id);
            if (datiRichiesta == null)
            {
                return NotFound();
            }
            ViewData["AssegnatoeId"] = new SelectList(_context.DatiAnagrafici, "DatiAnagraficiId", "CodiceAnagrafica", datiRichiesta.AssegnatoeId);
            ViewData["RichiedenteId"] = new SelectList(_context.DatiAnagrafici, "DatiAnagraficiId", "CodiceAnagrafica", datiRichiesta.RichiedenteId);
            return View(datiRichiesta);
        }

        // POST: DatiRichieste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatiRichiestaId,RichiedenteId,AssegnatoeId,DataRichiesta,DataChiusura,StatoRichiesta,TitoloRichiesta,DescrizioneRichiesta,DescrizioneRisposta")] DatiRichiesta datiRichiesta)
        {
            if (id != datiRichiesta.DatiRichiestaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datiRichiesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatiRichiestaExists(datiRichiesta.DatiRichiestaId))
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
            ViewData["AssegnatoeId"] = new SelectList(_context.DatiAnagrafici, "DatiAnagraficiId", "CodiceAnagrafica", datiRichiesta.AssegnatoeId);
            ViewData["RichiedenteId"] = new SelectList(_context.DatiAnagrafici, "DatiAnagraficiId", "CodiceAnagrafica", datiRichiesta.RichiedenteId);
            return View(datiRichiesta);
        }

        // GET: DatiRichieste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datiRichiesta = await _context.DatiRichieste
                .Include(d => d.Assegnato)
                .Include(d => d.Richiedente)
                .FirstOrDefaultAsync(m => m.DatiRichiestaId == id);
            if (datiRichiesta == null)
            {
                return NotFound();
            }

            return View(datiRichiesta);
        }

        // POST: DatiRichieste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datiRichiesta = await _context.DatiRichieste.FindAsync(id);
            _context.DatiRichieste.Remove(datiRichiesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatiRichiestaExists(int id)
        {
            return _context.DatiRichieste.Any(e => e.DatiRichiestaId == id);
        }
    }
}
