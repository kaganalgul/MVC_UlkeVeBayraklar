using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UlkeVeBayraklar.Models.Entity
{
    public class Ulke
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string UlkeAd { get; set; }

        public string UlkeBayrak { get; set; }

        public ICollection<Renk> BayrakRenkleri { get; set; }
    }
}
