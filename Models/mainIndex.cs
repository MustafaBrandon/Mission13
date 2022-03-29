using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class mainIndex
    {
        public string? currentTeam { get; set; }
        public IQueryable<string> teams { get; set; }
        public List<Bowler> bowlers { get; set; }
    }
}
