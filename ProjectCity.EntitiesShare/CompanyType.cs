using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class CompanyType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SalariesLimite { get; set; }

        public CompanyType()
        {

        }
        public CompanyType(int id, string title, int salariesLimite)
        {
            Id = id;
            Title = title;
            SalariesLimite = salariesLimite;
        }
    }
}
