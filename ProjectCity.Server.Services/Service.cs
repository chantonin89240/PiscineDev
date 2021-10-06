using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.Server.Services
{
    public static partial class Service
    {
        static List<Level> levels = new List<Level>();
        static List<Field> fields = new List<Field>();
        static List<School> schools = new List<School>();
        static List<Project> projects = new List<Project>();

        public static List<Level> GetLevels()
        {
            return Serializer.FromJson<List<Level>>(@"../../../../ProjectCity.VM/JSon/Level.json"); 
        }

        public static List<Field> GetFields()
        {
            return Serializer.FromJson<List<Field>>(@"../../../../ProjectCity.VM/JSon/Field.json");
        }

        public static List<School> GetSchools()
        {
            return Serializer.FromJson<List<School>>(@"../../../../ProjectCity.VM/JSon/School.json");
        }

        //public List<Project> GenerateProjects()
        //{
        //    List<string> projectTitles = new List<string>();
        //    List<int> projectCosts = new List<int>() { 
        //        20000,
        //        50000,
        //        75000,
        //        100000,
        //        150000,
        //        200000,
        //        500000,
        //        };

        //    var duration = new Random();
        //    duration.Next(1, 4);

        //    projects.Add(
        //        new Project()
        //    );


        //    return projects;
        //}


    }
}
