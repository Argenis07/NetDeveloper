using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ArtistRepository
    {
        private ChinookContext _context;

        public ArtistRepository()
        {
            _context = new ChinookContext();
        }

        public int Count()
        {
            return _context.Artists.Count();
        }

        public IEnumerable<Artist> GetListaArtista()
        {
            return _context.Artists;
        }

        public IEnumerable<Artist> GetListaArtistaStore()
        {
            return _context.Database.SqlQuery<Artist>("GetListaArtista");
        }

        public int InsertArtista(string name)
        {
            var artista = new Artist { Name = name };
            _context.Artists.Add(artista);
            return _context.SaveChanges();
        }

        public int DeleteArtistaPorId(int id)
        {
            var artista = new Artist { Artistid = id };
            _context.Artists.Remove(artista);
            return _context.SaveChanges();
        }

        public Artist GetArtistaPorId(int id)
        {
            //return _context.Artists.FirstOrDefault(artist => artist.Artistid == id);
            return _context.Artists
                .Where(artist => artist.Artistid == id)
                .Take(1)
                .FirstOrDefault();
        }
    }
}
