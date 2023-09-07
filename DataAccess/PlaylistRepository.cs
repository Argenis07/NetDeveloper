using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class PlaylistRepository
    {
        private ChinookContext _context;

        public PlaylistRepository()
        {
            _context = new ChinookContext();
        }

        public int Count()
        {
            return _context.Playlists.Count();
        }

        public IEnumerable<Playlist> GetListaPlaylist()
        {
            return _context.Playlists;
        }

        public int InsertPlaylist(string name)
        {
            var playlist = new Playlist { Name = name };
            _context.Playlists.Add(playlist);
            return _context.SaveChanges();
        }

        public int DeletePlaylistPorId(int id)
        {
            var playlist = new Playlist { Playlistid = id };
            _context.Playlists.Remove(playlist);
            return _context.SaveChanges();
        }

        public Playlist GetPlaylistPorId(int id)
        {
            return _context.Playlists.FirstOrDefault(playlist => playlist.Playlistid == id);

        }
    }
}
