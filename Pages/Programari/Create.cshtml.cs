using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii.Data;
using Proiect_Medii.Models;

namespace Proiect_Medii.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public CreateModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programare Programare { get; set; } = new Programare();

        // Lista de ore disponibile
        public List<string> OreDisponibile { get; set; } = new List<string> { "10:00", "13:00", "16:00" };

        // Verifică dacă ora este disponibilă pentru data specificată
        public bool IsOraDisponibila(DateTime data, string ora)
        {
            return OreDisponibile.Contains(ora) && !_context.Programare.Any(p => p.Data == data && p.Ora == ora);
        }

        // Verifică dacă data este în weekend
        public bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "Id", "Id");
            ViewData["ServiciuID"] = new SelectList(_context.Serviciu, "ID", "Denumire");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Verificați disponibilitatea orei și dacă este weekend
            if (!IsOraDisponibila(Programare.Data, Programare.Ora) || IsWeekend(Programare.Data))
            {
                ModelState.AddModelError("Programare.Ora", "Ora selectată nu este disponibilă sau este în weekend.");
                ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "Id", "Id");
                ViewData["ServiciuID"] = new SelectList(_context.Serviciu, "ID", "Denumire");
                return Page();
            }

            if (!ModelState.IsValid || _context.Programare == null || Programare == null)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
