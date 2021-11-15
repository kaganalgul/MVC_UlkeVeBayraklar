using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UlkeVeBayraklar.Models.Entity
{
    public class Renk
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string RenkAdi { get; set; }

        public ICollection<Ulke> Ulkeler { get; set; }
    }
}
