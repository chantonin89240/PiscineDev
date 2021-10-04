using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Project
    {
        private bool isSuccessFull;
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; } //months = turns
        public double Cost { get; set; }
        public int Start { get; set; }  // turn
        public List<StaffMember> Members { get; set; }
        public List<Certification> Requirements { get; set; }
        public bool IsSuccessFul { get => isSuccessFull; set => isSuccessFull = value; }

        public Project()
        {
            this.Members = new List<StaffMember>();
            this.Requirements = new List<Certification>();
        }

        public Project(int id, string title, int duration, double cost, int start):this()
        {
            Id = id;
            Title = title;
            Duration = duration;
            Cost = cost;
            Start = start;
            IsSuccessFul = false; 
        }

    }
}
