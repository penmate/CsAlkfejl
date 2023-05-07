using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;

namespace CsAlkfejl
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Generikus kollekcio
            List<Torta> tortak = new List<Torta>();

            // Record class peldanyok
            var nagytorta = new Torta
            {
                Color = "white",
                Size = "Large",
                Sugar = 90
            };
            var kistorta = new Torta
            {
                Color = "Orange",
                Size = "Mini",
                Sugar = 50
            };
            var keskenytorta = new Torta
            {
                Color = "Dark",
                Size = "Medium",
                Sugar = 20
            };
            var eskuvoitorta = new Torta
            {
                Color = "white",
                Size = "Large",
                Sugar = 120
            };

            // kollekcio feltoltes
            tortak.Add(nagytorta);
            tortak.Add(kistorta);
            tortak.Add(keskenytorta);
            tortak.Add(eskuvoitorta);

            // Linq
            var results = from tortacska in tortak
                          where tortacska.Sugar > 20
                          orderby tortacska.Size ascending
                          select tortacska;

            foreach (var tortacska in results)
                Console.Write(tortacska.Size + "\n");

            // fajlkezeles - iras
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var jsonString = JsonSerializer.Serialize(nagytorta, options);

            Console.WriteLine("Adj meg egy nevet a fajl mentesehez(pl. asd.txt): ");

            string name = Console.ReadLine() ?? "asd.txt";
            string path = Path.Combine(AppContext.BaseDirectory, name);

            using (FileStream file = File.OpenWrite(path))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    try
                    {
                        writer.WriteLine(nagytorta);

                        writer.WriteLine(jsonString);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Something went wrong!");
                    }
                }
            }
            // Async
            var number = await Reader.ReadFile(path);
            Console.WriteLine(number);
        }
    }
}
