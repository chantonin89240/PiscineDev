using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ModifMoney { get; set; }

        public Event() { }

        public Event(int pId, string pTitle, string pDescription, int pModifMoney)
        {
            Id = pId;
            Title = pTitle;
            Description = pDescription;
            ModifMoney = pModifMoney;
        }
    }
}
