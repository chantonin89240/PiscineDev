using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.VM
{
    public class DataGame
    {
        public Game game { get; set; }

        public Dictionary<Company, Developer> lstChoiceDev { get; set; }

        public Dictionary<Company, Project> lstChoiceProject { get; set; }

        public Dictionary<Company, TrainingSession> lstChoiceSession { get; set; }

        public List<Developer> developers { get; set; }

        public List<Project> projects { get; set; }

        public List<TrainingSession> sessions { get; set; }

    }
}
