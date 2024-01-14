using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii.Data;
using Proiect_Medii.Models;

namespace Proiect_Medii.Pages.Programari
{
    [Authorize(Roles = "Admin,User")]

    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii.Data.Proiect_MediiContext _context;

        public IndexModel(Proiect_Medii.Data.Proiect_MediiContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Programare != null)
            {
                Programare = await _context.Programare
                .Include(p => p.Client)
                .Include(p => p.Serviciu)
                .ToListAsync();
            }
        }
    }
}
