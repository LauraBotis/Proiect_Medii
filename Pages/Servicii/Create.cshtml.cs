﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Medii.Data;
using Proiect_Medii.Models;

namespace Proiect_Medii.Pages.Servicii
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public CreateModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID","Nume");
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Serviciu == null || Serviciu == null)
            {
                return Page();
            }

            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
