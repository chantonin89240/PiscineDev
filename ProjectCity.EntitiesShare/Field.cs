using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public partial class Field
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Field()
        {

        }

        public Field(int id, string title)
        {
            Id = Id;
            Title = Title;
        }
    }
}
