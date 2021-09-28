using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class School
    {
        public String Name { get; set; }
        public List<TrainingSession> TrainingSessions { get; set; }

        public School()
        {
            this.TrainingSessions = new List<TrainingSession>();
        }
    }
}
