using Chinook.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.ConsoleTest
{
    class Program
    {
        private const string Path = "d:\\a1.txt";

        static void Main(string[] args)
        {
            Serialize();

            Deserialize();
        }

        private static void Deserialize()
        {
            string json = File.ReadAllText(Path);

            Artist artist = JsonConvert.DeserializeObject<Artist>(json);
            Console.WriteLine($"{artist.ArtistId} / {artist.Name}");
        }

        private static void Serialize()
        {
            Artist artist = new Artist();
            artist.ArtistId = 123;
            artist.Name = "Thomas";

            string json = JsonConvert.SerializeObject(artist);

            File.WriteAllText(Path, json);
            // persistence
            // XML / JSON (JavaScript Object NotifiXXX)
        }
    }
}
