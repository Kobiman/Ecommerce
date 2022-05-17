using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class DataWriter
    {
        public void WriterData<T>(IList<T> data, string fileName)
        {
            new Thread(async () =>
            {
                try
                {
                    Thread.CurrentThread.IsBackground = true;
                    if (data.Count > 0)
                    {
                        var applicationPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{fileName}");

                        using (var sw = new StreamWriter(applicationPath, true))
                        {
                            var json = new StringBuilder();
                            Parallel.ForEach(data, (d) => json.Append(JsonSerializer.Serialize(d)).Append(','));
                            await sw.WriteAsync(json);
                        }
                    }
                }
                catch
                {
                }
            }).Start();
        }

        //public async Task WriterData<T>(T data, string fileName)
        //{

        //    var applicationPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{fileName}.txt");

        //    using (var sw = new StreamWriter(applicationPath, true))
        //    {
        //        var json = JsonConvert.SerializeObject(data) + ",";
        //        await sw.WriteAsync(json);
        //    }
        //}

        public async Task WriterDataAsync<T>(T data, string fileName)
        {
            try {
            var applicationPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{fileName}.txt");

            using var sw = new StreamWriter(applicationPath, true);
            var json = JsonSerializer.Serialize(data) + ",";
            await sw.WriteAsync(json);
            }
            catch 
            {
            }
        }

        public void WriterData<T>(T data, string fileName)
        {
            new Thread(async () =>
            {
                try
                {
                    Thread.CurrentThread.IsBackground = true;
                    var applicationPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{fileName}.txt");

                    using var sw = new StreamWriter(applicationPath, true);
                    var json = JsonSerializer.Serialize(data) + ",";
                    await sw.WriteAsync(json);
                }
                catch (Exception ex)
                {
                }
            }).Start();
        }

        public void Update<T>(IList<T> data, string fileName)
        {
            new Thread(async() =>
            {
               try
               {
                  Thread.CurrentThread.IsBackground = true;
                  await OverWrite(data, fileName);
                }
               catch
               {
               }
            }).Start();
        }

        private static async Task OverWrite<T>(IList<T> data, string fileName)
        {
            var applicationPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{fileName}.txt");
            var tempfile = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Temp/{fileName}.txt");

            using (Stream sw = File.OpenWrite(tempfile))
            {
                var jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(data);
                await sw.WriteAsync(jsonUtf8Bytes, 1, jsonUtf8Bytes.Length - 2);
                var b = Encoding.ASCII.GetBytes(",");
                await sw.WriteAsync(b, 0, b.Length);
            }

            File.Delete(applicationPath);
            File.Move(tempfile, applicationPath);
            File.Delete(tempfile);
        }

        //public async Task OverWriter<T>(IList<T> data, string fileName)
        //{
        //    var applicationPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{fileName}.txt");
        //    var tempfile = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Temp/{fileName}.txt");

        //    //using (var sw = new StreamWriter(tempfile, true))
        //    //{
        //    //    var json = new StringBuilder();
        //    //    for (var i = 0; i <= 5000000; i++)
        //    //    {
        //    //        Parallel.ForEach(data, (d) => json.Append(Newtonsoft.Json.JsonConvert.SerializeObject(d)).Append(','));
        //    //    }
        //    //    await sw.WriteAsync(json);
        //    //}

        //    using (Stream sw = File.OpenWrite(tempfile))
        //    {
        //        var jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(data);
        //        await sw.WriteAsync(jsonUtf8Bytes, 1, jsonUtf8Bytes.Length - 2);
        //        var b = Encoding.ASCII.GetBytes(",");
        //        await sw.WriteAsync(b, 0, b.Length);
        //    }

        //    File.Delete(applicationPath);
        //    File.Move(tempfile, applicationPath);
        //    File.Delete(tempfile);
        //}
    }
}
