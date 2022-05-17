//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public static class DataReader
    {
        //public IList<T> ReadData<T>(string table)
        //{
        //    string json = "";

        //    var fileStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{table}.txt"), FileMode.Open, FileAccess.Read);
        //    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
        //    {
        //        json = "[" + streamReader.ReadToEnd() + "]";
        //    }

        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<T>>(json);
        //    return data ?? new List<T>();
        //}

        public static IList<T> ReadData<T>(string table)
        {
            var fileStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{table}.txt"), FileMode.Open, FileAccess.Read);
            string json = string.Empty;
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                json = "[" + streamReader.ReadToEnd() + "]";
            }

            var data = JsonSerializer.Deserialize<IList<T>>(json, new JsonSerializerOptions { AllowTrailingCommas = true });
            return data ?? new List<T>();
        }
    }
}
