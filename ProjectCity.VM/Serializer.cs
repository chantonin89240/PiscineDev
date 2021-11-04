using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Windows.Storage;
using FileAttributes = System.IO.FileAttributes;

namespace ProjectCity.VM
{
    public class Serializer
    {
        #region ---Ancienne version----
        //public static void ToJSon<T>(string filename, T objetASerialiser)
        //{
        //    try
        //    {
        //        //serialisation
        //        //on écrit dans le fichier fileName dans lequel on sérialise l'objet

        //        if (!File.Exists(filename))
        //        {
        //            File.Create(filename);
        //        }
        //        File.SetAttributes(filename, FileAttributes.Normal);


        //        File.WriteAllText(filename, JsonConvert.SerializeObject(objetASerialiser, Formatting.Indented,
        //            new JsonSerializerSettings
        //            {
        //                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        //                PreserveReferencesHandling = PreserveReferencesHandling.Objects
        //            }));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public static T FromJson<T>(string filename)
        {

            T result = default(T);

            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

            try
            {
                result = JsonConvert.DeserializeObject<T>(File.ReadAllText(storageFolder.Path + "\\" + filename));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

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

                StorageFolder storageFolder =  ApplicationData.Current.LocalFolder;
                File.WriteAllText(storageFolder.Path + "\\" + filename, result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string ObjectToJsonText<T>(T objetASerialiser)
        {
            return JsonConvert.SerializeObject(objetASerialiser, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    });
        }
        

        

        public static T JsonObjectToObject<T>(string json, string jsonProperty)
        {
            JsonDocument document = JsonDocument.Parse(json);
            JsonElement root = document.RootElement;
            JsonElement gamesElement = root.GetProperty(jsonProperty);

            return JsonConvert.DeserializeObject<T>(gamesElement.ToString());
        }

        //public static T FromJson<T>(string filename)
        //{
        //    T result = default(T);

        //    try
        //    {
        //        //deserialisation
        //        //on désérialise l'objet dans le fichier en précisant son type et en lisant le fichier avec read
        //        result = JsonConvert.DeserializeObject<T>(File.ReadAllText(filename));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return result;
        //}
    }
}
