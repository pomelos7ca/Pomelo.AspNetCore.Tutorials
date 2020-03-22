using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Data;
using Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Models;

namespace Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages
{
    public class DetailsModel : PageModel
    {
        private readonly Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Data.RazorPagesContext _context;

        public DetailsModel(Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Data.RazorPagesContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
