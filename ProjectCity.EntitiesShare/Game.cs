using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Game
    {
        public int Id { get; set; }
        public List<Turn> Turns { get; set; }
        public List<Company> Companies { get; set; }
        public List<Player> Players { get; set; }
        public int PlayerMax { get; set; }
        public int TurnMax { get; set; }
        public int StartBudget { get; set; }
        public Player Winner { get; set; }
        public Player Admin { get; set; }
        public List<Training> Trainings { get; set; }
        /// <summary>
        /// 3 etat :
        /// - creation
        /// - cours
        /// - finish
        /// </summary>
        public string Etat { get; set; }

        public Game()
        {
            this.Turns = new List<Turn>();
            this.Companies = new List<Company>();
            this.Players = new List<Player>();
            this.Trainings = new List<Training>();
        }
    }
}
