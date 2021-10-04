using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjectCity.VM;

namespace ProjectCity.Server.Services
{
    public partial class Service
    {
        public void GenerateDeveloper(int numberDev)
        {

            List<Developer> developers = new List<Developer>();

            var rdn = new Random();
            var number = GetFields().Count +1;
            var allName = GetName();

            for (int i = 0; i < numberDev; i++)
            {
                var numberOfName = GetName().Count + 1;
                var random = rdn.Next(0, numberOfName);


                var a = new Developer()
                {
                    FirstName = allName.ElementAt(random).FirstName,
                    LastName = allName.ElementAt(random).LastName,
                    Certifications = GenerateCertifications(rdn.Next(1, number)),
                };

                a.Salary = a.Certifications.Sum(b => b.Level.Niveau)*1000;

                developers.Add(a);

                allName.RemoveAt(random);
            };
        }

        public List<NameDeveloper> GetName()
        {
            var allNameJson =  Serializer.FromJson<dynamic>("../../../../ProjectCity.VM/JSon/NameDeveloper.json");

            List<NameDeveloper> allName = new List<NameDeveloper>();

            foreach (var name in allNameJson.nameDeveloper)
            {
                allName.Add(new NameDeveloper()
                {
                    FirstName = name.firstName,
                    LastName = name.lastName
                });
            }

            return allName;
        }

        public List<Certification> GenerateCertifications(int numberCertif)
        {
            List<Certification> certifications = new List<Certification>();

            List<Certification> allCertif = GetCertifications();

            var rdn = new Random();

            for (int i = 0; i < numberCertif; i++)
            {
                //var rednLevel = rdn.Next(1, GetLevels().Count);
                //var rdnField = rdn.Next(1, GetCertifications().Count);
                //certifications.Add(newCertification.First(certif => certif.Level.Niveau == rednLevel && certif.Field.Id == rdnField));

                var newCertif = allCertif.ElementAt(rdn.Next(0, allCertif.Count));
                allCertif.RemoveAll(certif => certif.Field.Id == newCertif.Field.Id);

                certifications.Add(newCertif);

            }

            return certifications;
        }
        public List<CompanyType> GetCompagnyType()
        {
            List<CompanyType> companyTypes = new List<CompanyType>() {
                new CompanyType(1,"Société à responsabilité limitée (SARL)",10),
                new CompanyType(2,"Société par actions simplifiée (SAS)",25),
                new CompanyType(3,"Société anonyme (SA)",50)
            };
            companyTypes.First();

            return companyTypes;
        }

        public List<Certification> GetCertifications()
        {

            Level level1 = GetLevels().First(lvl => lvl.Id == 1);
            Level level2 = GetLevels().First(lvl => lvl.Id == 2);
            Level level3 = GetLevels().First(lvl => lvl.Id == 3);

            Field field1 = GetFields().First(lvl => lvl.Id == 1);
            Field field2 = GetFields().First(lvl => lvl.Id == 2);
            Field field3 = GetFields().First(lvl => lvl.Id == 3);
            Field field4 = GetFields().First(lvl => lvl.Id == 4);
            Field field5 = GetFields().First(lvl => lvl.Id == 5);
            Field field6 = GetFields().First(lvl => lvl.Id == 6);

            List<Certification> certifications = new List<Certification>()
            {
                new Certification(1, level1, field1),
                new Certification(2, level1, field2),
                new Certification(3, level1, field3),
                new Certification(4, level1, field4),
                new Certification(5, level1, field5),
                new Certification(6, level1, field6),
                new Certification(7, level2, field1),
                new Certification(8, level2, field2),
                new Certification(9, level2, field3),
                new Certification(10, level2, field4),
                new Certification(11, level2, field5),
                new Certification(12, level2, field6),
                new Certification(13, level3, field1),
                new Certification(14, level3, field2),
                new Certification(15, level3, field3),
                new Certification(16, level3, field4),
                new Certification(17, level3, field5),
                new Certification(18, level3, field6),

            };

            return certifications;
        }

        
    }
}
