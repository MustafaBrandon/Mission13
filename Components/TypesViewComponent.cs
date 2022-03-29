using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission13.Models;

namespace Mission13.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private BowlersDbContext _context { get; set; }

        public TypesViewComponent(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedType = RouteData?.Values["team"];
            var types = _context.Teams
                .Select(x => x.TeamName)
                .Distinct();
            return View(types);
        }
    }
}
