using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class ArtistMeta
    {
        [JsonProperty]
        public int ArtistId { get; set; }
        
        [JsonProperty]
        public string Name { get; set; }
    }

    [MetadataType(typeof(ArtistMeta))]
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Artist
    {
    }
}
