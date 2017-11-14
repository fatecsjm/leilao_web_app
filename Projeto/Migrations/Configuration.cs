namespace Projeto.Migrations
{
    using Projeto.Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto.Models.ApplicationDbContext>
    {
        private Assembly _assembly = null;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Projeto.Models.ApplicationDbContext context)
        {
            _assembly = Assembly.GetExecutingAssembly();
            context.Roles.AddOrUpdate(x=> x.Name ,LoadRoles().ToArray());
            context.State.AddOrUpdate(x=> x.Name, LoadStates().ToArray());
        }

        private ICollection<Role> LoadRoles()
        {
            var resourceName = "Projeto.Models.SeedData.Roles.xml";
            var stream = _assembly.GetManifestResourceStream(resourceName);
            var xml = XDocument.Load(stream);

            var roles = xml.Element("Roles")
                            .Elements("Role")
                            .Select(x => new Role((string)x.Element("Name")))
                            .ToList();
            return roles;
        }

        private ICollection<State> LoadStates()
        {
            var resourceName = "Projeto.Models.SeedData.States.xml";
            var stream = _assembly.GetManifestResourceStream(resourceName);
            var xml = XDocument.Load(stream);

            var states = xml.Element("States")
                            .Elements("State")
                            .Select(x => new State() { Name = (string)x.Element("Name") })
                            .ToList();
            return states;
        }


    }
}
