﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.VM
{
    public class NameDeveloper
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public NameDeveloper()
        {

        }
        public NameDeveloper(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
