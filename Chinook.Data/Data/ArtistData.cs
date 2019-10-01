using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class ArtistData : EntityData<Artist>
    {
        public Artist GetByPK(int artistId)
        {
            return GetByPKCore(x => x.ArtistId == artistId);
        }
    }
}
