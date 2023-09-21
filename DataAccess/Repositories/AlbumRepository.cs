using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(DbContext context) : base(context)
        {
        }

        public Album GetByTitle(string title)
        {
            return chinookcontext.Album.FirstOrDefault(album => album.Title == title);
        }

        public int Count()
        {
            return chinookcontext.Artists.Count();
        }

        public IEnumerable<Album> GetAlbumsByStore()
        {
            return chinookcontext.Database.SqlQuery<Album>("GetListaAlbum");
        }

        public IEnumerable<Album> GetAlbumsPage(int pageindex, int pagesize)
        {
            var query = chinookcontext.Album
                .OrderBy(a => a.Albumid)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize);
            return query.ToList();
        }

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }
    }
}
