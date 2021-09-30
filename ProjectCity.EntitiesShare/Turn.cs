using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Turn
    {
        public int Id { get; set; }
        public List<Project> NewProjects { get; set; }
        public List<Project> FailedProjects { get; set; }
        public List<Project> NewDevelopers { get; set; }
        public List<School> Schools { get; set; }
        public List<TrainingSession> StartingTrainingSessions { get; set; }

        public Turn()
        {
            this.NewProjects = new List<Project>();
            this.FailedProjects = new List<Project>();
            this.NewDevelopers = new List<Project>();
            this.Schools = new List<School>();
            this.StartingTrainingSessions = new List<TrainingSession>();
        }
    }
}
