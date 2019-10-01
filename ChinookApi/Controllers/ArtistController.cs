using Chinook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChinookApi.Controllers
{
    public class ArtistController : ApiController
    {
        // GET: api/Artist
        public List<Artist> Get()
        {
            return DataRepository.Artist.Get();
        }

        // GET: api/Artist/5
        public Artist Get(int id)
        {
            return DataRepository.Artist.GetByPK(id);
        }

        // POST: api/Artist
        public void Post(string name)
        {
            Artist artist = new Artist();
            artist.Name = name;

            DataRepository.Artist.Insert(artist);
        }

        // PUT: api/Artist/5
        public void Put(int id, string name)
        {
            Artist artist = DataRepository.Artist.GetByPK(id);
            artist.Name = name;

            DataRepository.Artist.Update(artist);
        }

        // DELETE: api/Artist/5
        public void Delete(int id)
        {
            Artist artist = DataRepository.Artist.GetByPK(id);

            DataRepository.Artist.Delete(artist);
        }
    }
}
