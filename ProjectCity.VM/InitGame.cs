using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.VM
{
    public class InitGame
    {
        public Game Game { get; set; }

        public Dictionary<Company, Developer> LstChoiceDev { get; set; }

        public Dictionary<Company, Project> LstChoiceProject { get; set; }

        public Dictionary<Company, TrainingSession> LstChoiceSession { get; set; }

        public List<Developer> Developers { get; set; }

        public List<Project> Projects { get; set; }

        public List<TrainingSession> Sessions { get; set; }

        public Event TurnEvent { get; set; } 
    }


}