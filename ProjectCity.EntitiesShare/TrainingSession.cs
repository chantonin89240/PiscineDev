using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class TrainingSession
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Duration { get; set; } //turn  =month
        public double Price { get; set; }
        public int Capacity { get; set; }
        public List<Certification> Certifications { get; set; }

        public TrainingSession()
        {
            this.Certifications = new List<Certification>();
        }
    }
}
