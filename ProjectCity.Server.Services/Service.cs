using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.Server.Services
{
    public partial class Service
    {
        List<Level> levels = new List<Level>();
        List<Field> fields = new List<Field>();
        List<School> schools = new List<School>();
        List<Project> projects = new List<Project>();

        public List<Level> GetLevels()
        {
            levels.AddRange(new List<Level>{
                new Level(1,1,"Novice"),
                new Level(2,3,"Intermediate"),
                new Level(3,3,"Confirmed")
                });

            return levels;
        }

        public List<Field> GetFields()
        {
            fields.AddRange(new List<Field>{
                new Field(1,"C#"),
                new Field(2,"SqlServer"),
                new Field(3,"PHP"),
                new Field(4,"Cybersécurité"),
                new Field(5,"PowerShell"),
                new Field(6,"JavaScript"),
                });

            return fields;
        }

        public List<School> GetSchools()
        {
            schools.AddRange(new List<School>{
                new School("DIIAGE"),
                new School("Université"),
                new School("WebForce2048")
                });

            return schools;
        }

        public List<Project> GenerateProjects()
        {
            List<string> projectTitles = new List<string>();
            List<int> projectCosts = new List<int>() { 
                20000,
                50000,
                75000,
                100000,
                150000,
                200000,
                500000,
                };

            var duration = new Random();
            duration.Next(1, 4);

            projects.Add(
                new Project()
            );


            return projects;
        }
    }
}
