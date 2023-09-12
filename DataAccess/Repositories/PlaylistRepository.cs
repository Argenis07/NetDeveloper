using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(ChinookContext context) : base(context)
        {
        }

        public Playlist GetByName(string name)
        {
            return chinookcontext.Playlists.FirstOrDefault(playlist => playlist.Name == name);
        }

        public int Count()
        {
            return chinookcontext.Playlists.Count();
        }

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }
    }
}
