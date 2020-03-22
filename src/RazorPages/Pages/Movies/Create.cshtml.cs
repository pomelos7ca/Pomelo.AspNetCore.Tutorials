using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Data;
using Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Models;

namespace Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages
{
    public class CreateModel : PageModel
    {
        private readonly Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Data.RazorPagesContext _context;

        public CreateModel(Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Data.RazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
