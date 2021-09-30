using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjectCity.Server.Services
{
    public static partial class Service
    {
        public static void GenerateDeveloper()
        {

            List<Developer> developers = new List<Developer>();

            var rdn = new Random();

            for (int i = 0; i < 5; i++)
            {
                developers.Add(new Developer()
                {
                    FirstName = "",
                    LastName = "",
                    Salary = 1,
                    Certifications = GenerateCertifications(rdn.Next(1,7))
                });

            };
            



        }

        public static List<Certification> GenerateCertifications(int number)
        {
            List<Certification> certifications = new List<Certification>();
            var rdn = new Random();

            rdn.Next(1, 19);

            return certifications;
        }

        private static List<Level> GetLevel()
        {
            throw new NotImplementedException();
        }

        private static List<Field> GetField()
        {
            throw new NotImplementedException();
        }

        public static List<CompanyType> GetCompagnyType()
        {
            List<CompanyType> companyTypes = new List<CompanyType>() {
                new CompanyType(1,"Société à responsabilité limitée (SARL)",10),
                new CompanyType(2,"Société par actions simplifiée (SAS)",25),
                new CompanyType(3,"Société anonyme (SA)",50)
            };
            companyTypes.First();

            return companyTypes;
        }

        public static List<Certification> GetCertifications()
        {

            Level level1 = GetLevel().First(lvl => lvl.Id == 1);
            Level level2 = GetLevel().First(lvl => lvl.Id == 2);
            Level level3 = GetLevel().First(lvl => lvl.Id == 3);

            Field field1 = GetField().First(lvl => lvl.Id == 1);
            Field field2 = GetField().First(lvl => lvl.Id == 2);
            Field field3 = GetField().First(lvl => lvl.Id == 3);
            Field field4 = GetField().First(lvl => lvl.Id == 4);
            Field field5 = GetField().First(lvl => lvl.Id == 5);
            Field field6 = GetField().First(lvl => lvl.Id == 6);

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
