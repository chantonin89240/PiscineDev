using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; } //months = turns
        public double Cost { get; set; }
        public int Start { get; set; }  // turn
        public List<StaffMember> Members { get; set; }
        public List<Certification> Requirements { get; set; }
        public bool IsSuccessFul { get; set; }

        public Project()
        {
            this.Members = new List<StaffMember>();
            this.Requirements = new List<Certification>();
        }
    }
}
