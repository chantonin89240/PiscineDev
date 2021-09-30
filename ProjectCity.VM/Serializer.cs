using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectCity.VM
{
    public class Serializer
    {
        public static int ToJSon<T>(string filename, T objetASerialiser)
        {
            int result = 0;
            try
            {
                //serialisation
                //on écrit dans le fichier fileName dans lequel on sérialise l'objet
                File.WriteAllText(filename, JsonConvert.SerializeObject(objetASerialiser, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    }));
                result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

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
