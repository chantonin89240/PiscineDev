using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.VM
{
    public class InitGame
    {
        public Game Game { get; set; }
        public Player Player { get; set; }

        public List<Player> lstPlayers { get; set; }
        public Company Company { get; set; }
    }
}