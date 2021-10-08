using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.Server.Services
{
    public static partial class Service
    {
        static List<Event> events = new List<Event>();

        public static List<Project> GenerateProjects()
        {
            projects = Serializer.FromJson<List<Project>>("../../../../ProjectCity.VM/JSon/Project.json");

            return projects;
        }

        public static List<Event> GenerateEvents()
        {
            events = Serializer.FromJson<List<Event>>("../../../../ProjectCity.VM/JSon/Event.json");

            return events;
        }
    }
}
