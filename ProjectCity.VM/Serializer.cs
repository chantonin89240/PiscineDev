using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage;
using FileAttributes = System.IO.FileAttributes;

namespace ProjectCity.VM
{
    public class Serializer
    {
        public static void ToJSon<T>(string filename, T objetASerialiser)
        {
            try
            {
                //serialisation
                //on écrit dans le fichier fileName dans lequel on sérialise l'objet

                if (!File.Exists(filename))
                {
                    File.Create(filename);
                }
                File.SetAttributes(filename, FileAttributes.Normal);


                File.WriteAllText(filename, JsonConvert.SerializeObject(objetASerialiser, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public static void SaveUWP<T>(string filename, T objetASerialiser)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore



                };
                string result = JsonConvert.SerializeObject(objetASerialiser, settings);

                StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

                File.WriteAllText(storageFolder.Path + "\\" + filename, result);



            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
