using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectCity.Server.Services
{
    public static partial class Service
    {
        public static string GetPathRootProject()
        {
            string filePath = Directory.GetCurrentDirectory();
            string directoryName = "";
            int i = 0;

            while (filePath != @"C:\\Users\\antonin\\OneDrive - CUCDB\\Documents\\DIIAGE\\PiscineDev\\ProjectCity.Client.UWP\\bin\\x86\\Debug")
            {
                directoryName = Path.GetDirectoryName(filePath);
                filePath = directoryName;
                if (i == 1)
                {
                    filePath = directoryName + @"\";  // this will preserve the previous path

                }
                i++;
            }

            return directoryName+@"\";
        }

        public static List<Level> GetLevels()
        {
            return Serializer.FromJson<List<Level>>( "Json/Level.json"); 
        }

        public static List<Field> GetFields()
        {
            return Serializer.FromJson<List<Field>>("Json/Field.json");
        }

        public static List<School> GetSchools()
        {
            return Serializer.FromJson<List<School>>( "Json/School.json");
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

        public static List<T> RandomSelect<T>(List<T> list, int nbWanted)
        {
            List<T> listSelect = new List<T>();

            Random rnd = new Random();
            for (int i = 0; i < nbWanted; i++)
            {
                T selection = list.ElementAt(rnd.Next(0, list.Count));
                listSelect.Add(selection);
                list.Remove(selection);
            }

            return listSelect;
        }


    }
}
