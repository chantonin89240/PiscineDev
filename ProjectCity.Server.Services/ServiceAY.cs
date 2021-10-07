using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.Server.Services
{
    public partial class Service
    {
        public List<Project> GenerateProjects()
        {
            List<Project> projects = Serializer.FromJson<List<Project>>("../../../../ProjectCity.VM/JSon/Project.json");

            return projects;
        }
    }
}
