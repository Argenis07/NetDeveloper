using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class PlaylistRespositoryTest
    {
        private readonly UnitOfWork _unit;

        public PlaylistRespositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void TestEf_Conexion_Playlist_Cantidad()
        {
            var count = _unit.Playlists.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void TestEf_ListaPlaylist()
        {
            var listaplaylist = _unit.Playlists.GetAll();
            Assert.AreEqual(listaplaylist.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_InsertPlaylist()
        {
            var newplaylist = new Playlist
            {
                Name = "Nuevo Playlist desde el Unit of work"
            };
            _unit.Playlists.Add(newplaylist);
            int retorno = _unit.Complete();

            var playlistnuevo = _unit.Playlists.GetByName("Nuevo Playlist desde el Unit of work");
            Assert.AreEqual(playlistnuevo.Playlistid > 0, true);
            Assert.AreEqual(playlistnuevo.Name, "Nuevo Playlist desde el Unit of work");
        }

        [TestMethod]
        public void TestEf_BuscarPorId()
        {
            var playlist = _unit.Playlists.GetById(1);
            var playlistencontrado = new Playlist
            {
                Playlistid = 1,
                Name = "Music"
            };
            Assert.AreEqual(playlistencontrado.Playlistid, playlist.Playlistid);
            Assert.AreEqual(playlistencontrado.Name, playlist.Name);
        }
    }
}
