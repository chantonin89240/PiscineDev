using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjectCity.VM;

namespace ProjectCity.Server.Services
{
    public static partial class Service
    {
        #region GetData

        /// <summary>
        /// Récupère une liste de nom de developer à partir d'un fichier json
        /// </summary>
        /// <returns>Une liste qui contient des noms pour la génération des dévelopers</returns>
        public static List<NameDeveloper> GetName()
        {
            return Serializer.FromJson<List<NameDeveloper>>("JSon/NameDeveloper.json");
        }

        /// <summary>
        /// Génération de toutes les certifications possibles dans la game
        /// </summary>
        /// <returns>Une liste qui contient toutes les certifications possibles</returns>
        public static List<Certification> GetCertifications()
        {
            //return Serializer.FromJson<List<Certification>>("../../../../ProjectCity.VM/JSon/Certification.json");

            List<Level> levels = GetLevels();

            List<Field> fields = GetFields();

            List<Certification> certifications = new List<Certification>();

            fields.ForEach(field =>
            {
                levels.ForEach(level =>
                {
                    certifications.Add(new Certification(certifications.Count + 1, level, field));
                });
            });

            return certifications;
        }

        #endregion

        /// <summary>
        /// Génère des dévelopers aléatoirement
        /// </summary>
        /// <param name="numberDev">Nombre de developers à générer</param>
        /// <returns></returns>
        public static List<Developer> GenerateDeveloper(int numberDev)
        {

            List<Developer> developers = new List<Developer>();

            var rdn = new Random();

            var number = GetFields().Count +1;

            List<NameDeveloper> allName = GetName();

            int numberOfName = allName.Count + 1;

            for (int i = 0; i < numberDev; i++)
            {
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
            return developers;
        }

        /// <summary>
        /// Obtient des certfications aléatoire en fonction du field /un level max par certifications
        /// </summary>
        /// <param name="numberCertif">Nombre de certifications </param>
        /// <returns>Une liste de certifications</returns>
        public static List<Certification> GenerateCertifications(int numberCertif)
        {
            List<Certification> certifications = new List<Certification>();

            List<Certification> allCertif = GetCertifications();

            var rdn = new Random();

            for (int i = 0; i < numberCertif; i++)
            {
                var newCertif = allCertif.ElementAt(rdn.Next(0, allCertif.Count));
                allCertif.RemoveAll(certif => certif.Field.Id == newCertif.Field.Id);

                certifications.Add(newCertif);

            }

            return certifications;

        }

        //Ne servirait plus car le type de Cie est rentré par l'administrateur dans les fichiers de config
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

    }
}
