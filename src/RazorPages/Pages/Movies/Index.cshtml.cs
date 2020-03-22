using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Data;
using Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Models;

namespace Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesContext _context;

        public IndexModel(RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Name属性匹配传递过来的查询字符串的Key</remarks>
        [BindProperty(SupportsGet =true,Name ="q")]
        public string SearchString { get; set; }

        /// <summary>
        /// 流派集合 用于下拉框展示
        /// </summary>
        public SelectList Genres { get; set; }

        /// <summary>
        /// 搜索的流派
        /// </summary>
        [BindProperty(SupportsGet =true,Name ="g")]
        public string SearchGenre { get; set; }

        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie select m;

            var genresList = from g in movies orderby g.Genre select g.Genre;

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                movies = movies.Where(x => x.Title.Contains(SearchString));
            }

            if (!string.IsNullOrWhiteSpace(SearchGenre))
            {
                movies = movies.Where(x => x.Genre.Contains(SearchGenre));
            }

            Genres = new SelectList(await genresList.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();
        }
    }
}
