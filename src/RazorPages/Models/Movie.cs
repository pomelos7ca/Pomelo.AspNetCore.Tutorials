using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pomelo.AspNetCore.Tutorials.RazorPages.RazorPages.Models
{
    public class Movie
    {
        public int ID { get; set; }

        public string Title { get; set; }

        [Display(Name ="发布日期")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Genre { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Describe { get; set; }
    }
}
