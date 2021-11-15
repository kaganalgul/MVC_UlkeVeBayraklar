using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_UlkeVeBayraklar.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UlkeVeBayraklar.ViewModels
{
    public class HomeViewModel
    {
        public List<Ulke> Ulkeler { get; set; }

        public List<SelectListItem> Renkler { get; set; }

        public int? SelectedRenkId { get; set; }

        public string SearchCriteria { get; set; }
    }
}
