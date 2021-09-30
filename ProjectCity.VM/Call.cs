using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectCity.VM
{
    public class Call
    {
        public static T FromJson<T>(string filename)
        {
            T result = default(T);

            try
            {
                //deserialisation
                //on désérialise l'objet dans le fichier en précisant son type et en lisant le fichier avec read
                result = JsonConvert.DeserializeObject<T>(File.ReadAllText(filename));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
