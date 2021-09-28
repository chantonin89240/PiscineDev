using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SuccessRate { get; set; }
        public double Budget { get; set; }
        public List<StaffMember> StaffMembers { get; set; }
        public CompanyType CompanyType { get; set; }
        public Player Player { get; set; }
        public bool TurnPass { get; set; }

        public Company()
        {
            this.StaffMembers = new List<StaffMember>();
        }
    }
}
