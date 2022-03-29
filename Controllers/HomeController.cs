using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        
        private BowlersDbContext _context { get; set; }


        public HomeController(BowlersDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string team)
        {
            ViewBag.SelectedType = RouteData?.Values["team"];
            var x = new mainIndex
            {

                currentTeam = RouteData?.Values["team"] == null? "": RouteData.Values["team"].ToString(),
                teams = _context.Teams
                .Select(x => x.TeamName)
                .Distinct(),
                bowlers = _context.Bowlers.Where(b => b.team.TeamName == team || team == null).ToList()

            };

            //var teams = _context.Teams.ToList();
            //var someData = _context.Bowlers.Include(x => Teams).ToList();
            //var items = ;
            return View(x);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _context.Add(b);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int bowler)
        {
            var b = _context.Bowlers.SingleOrDefault(x => x.BowlerID == bowler);
            return View(b);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int b)
        {
            Bowler bowler = _context.Bowlers.FirstOrDefault(x => x.BowlerID == b);
            //_context.Entry(b).State = EntityState.Deleted;
            _context.Remove(bowler);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
